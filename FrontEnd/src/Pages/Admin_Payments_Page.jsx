import React, { useEffect, useState } from 'react';
import {
  Card,
  CardHeader,
  Typography,
  Button,
  CardBody,
  Chip,
  Tooltip,
  Input,
} from "@material-tailwind/react";
import { GetAllPayment } from '../Context/PolicyManager';

const TABLE_HEAD = ["Policy ID", "Transaction ID", "Payment Amount", "Payment Type", "Paid Date", "Status"];

export function AdminPaymentsPage() {
  const [rows, setRows] = useState([]);
  const [filteredRows, setFilteredRows] = useState([]);
  const [sortConfig, setSortConfig] = useState({ key: null, direction: 'asc' });
  const [loading, setLoading] = useState(true);
  const [searchTerm, setSearchTerm] = useState("");
  const [searchDate, setSearchDate] = useState("");

  // Sorting function
  const sortRows = (key) => {
    let sortedRows = [...filteredRows];
    if (key === 'paymentStatus') {
      sortedRows.sort((a, b) => {
        const statusOrder = { 'Pending': 0, 'Paid': 1 };
        if (sortConfig.direction === 'asc') {
          return statusOrder[a[key]] - statusOrder[b[key]];
        } else {
          return statusOrder[b[key]] - statusOrder[a[key]];
        }
      });
    } else if (key === 'paymentDueDate') {
      sortedRows.sort((a, b) => {
        const dateA = new Date(a[key]);
        const dateB = new Date(b[key]);
        if (sortConfig.direction === 'asc') {
          return dateA - dateB;
        } else {
          return dateB - dateA;
        }
      });
    }
    setFilteredRows(sortedRows);
  };

  const handleSort = (key) => {
    let direction = 'asc';
    if (sortConfig.key === key && sortConfig.direction === 'asc') {
      direction = 'desc';
    }
    setSortConfig({ key, direction });
    sortRows(key);
  };

  const handleSearchTermChange = (event) => {
    setSearchTerm(event.target.value);
  };

  const handleSearchDateChange = (event) => {
    setSearchDate(event.target.value);
  };

  useEffect(() => {
    const fetchData = async () => {
      try {
        setLoading(true);
        const data = await GetAllPayment();
        console.log(data);
        setRows(data);
        setFilteredRows(data);
      } catch (err) {
        alert(err);
      } finally {
        setLoading(false);
      }
    };
    fetchData();
  }, []);

  useEffect(() => {
    const lowercasedTerm = searchTerm.toLowerCase();
    const filteredData = rows.filter(row => {
      const dateMatch = searchDate ? new Date(row.paymentDate).toDateString() === new Date(searchDate).toDateString() : true;
      const textMatch = row.policyId.toString().includes(lowercasedTerm) || 
                         row.transactionId.toString().includes(lowercasedTerm) || 
                         row.paymentAmount.toString().includes(lowercasedTerm) || 
                         row.paymentType.toLowerCase().includes(lowercasedTerm) || 
                         row.paymentDate.toLowerCase().includes(lowercasedTerm);

      return dateMatch && textMatch;
    });
    setFilteredRows(filteredData);
  }, [searchTerm, searchDate, rows]);

  if (loading) return <h1>Loading ..</h1>;

  return (
    <Card className="h-full w-full p-4">
      <CardHeader floated={false} shadow={false} className="rounded-none pb-4">
        <div className="mb-4 flex flex-col justify-between gap-8 md:flex-row md:items-center">
          <div>
            <Typography variant="h5" color="blue-gray">
              Completed Payments
            </Typography>
            <Typography color="gray" className="mt-1 font-normal">
              List of completed payments associated with your policies
            </Typography>
          </div>
          <div className="flex flex-col md:flex-row gap-4">
            <Input
              type="text"
              label='Search by Text'
              placeholder="Search by Policy ID, Transaction ID, Amount, Type, or Date"
              value={searchTerm}
              onChange={handleSearchTermChange}
              className="w-full"
            />
            <Input
              type="date"
              label='Search by Due Date'
              placeholder="Search by Due Date"
              value={searchDate}
              onChange={handleSearchDateChange}
              className="w-full"
            />
          </div>
        </div>
      </CardHeader>
      <CardBody className="px-0">
        <table className="w-full min-w-max table-auto text-left">
          <thead>
            <tr>
              {TABLE_HEAD.map((head, index) => {
                const isSortable = head === "Status" || head === "Paid Date";
                const key = head === "Status" ? 'paymentStatus' : (head === "Paid Date" ? 'paymentDate' : null);

                return (
                  <th
                    key={index}
                    className="border-y border-blue-gray-100 bg-blue-gray-50/50 p-4 cursor-pointer"
                    onClick={() => isSortable && handleSort(key)}
                  >
                    <div className="flex items-center justify-between">
                      <Typography
                        variant="small"
                        color="blue-gray"
                        className="font-normal leading-none opacity-70"
                      >
                        {head}
                      </Typography>
                      {isSortable && sortConfig.key === key && (
                        <svg
                          className={`h-4 w-4 ${sortConfig.direction === 'asc' ? 'rotate-180' : ''}`}
                          xmlns="http://www.w3.org/2000/svg"
                          viewBox="0 0 24 24"
                          fill="none"
                          stroke="currentColor"
                          strokeWidth="2"
                          strokeLinecap="round"
                          strokeLinejoin="round"
                        >
                          <line x1="18" y1="15" x2="12" y2="9"></line>
                          <line x1="6" y1="15" x2="12" y2="9"></line>
                        </svg>
                      )}
                    </div>
                  </th>
                );
              })}
            </tr>
          </thead>
          <tbody>
            {filteredRows.map(
              (
                {
                  policyId,
                  paymentAmount,
                  paymentType,
                  paymentDate,
                  paymentStatus,
                  transactionId
                },
                index,
              ) => {
                const isLast = index === filteredRows.length - 1;
                const classes = isLast
                  ? "p-4"
                  : "p-4 border-b border-blue-gray-50";

                return (
                  <tr key={policyId}>
                    <td className={classes}>
                      <Typography
                        variant="small"
                        color="blue-gray"
                        className="font-mono"
                      >
                        #{policyId}
                      </Typography>
                    </td>
                    <td className={classes}>
                      <Typography
                        variant="small"
                        color="blue-gray"
                        className="font-mono"
                      >
                        #{transactionId}
                      </Typography>
                    </td>
                    <td className={classes}>
                      <Typography
                        variant="small"
                        color="blue-gray"
                        className="font-mono"
                      >
                        {paymentAmount}
                      </Typography>
                    </td>
                    <td className={classes}>
                      <Typography
                        variant="small"
                        color="blue-gray"
                        className="font-mono"
                      >
                        {paymentType}
                      </Typography>
                    </td>
                    <td className={classes}>
                      <Typography
                        variant="small"
                        color="blue-gray"
                        className="font-mono"
                      >
                        {new Date(paymentDate).toDateString()}
                      </Typography>
                    </td>
                    <td className={classes}>
                      <div className="w-max">
                        <Chip
                          size="sm"
                          variant="ghost"
                          value={paymentStatus}
                          color={
                            paymentStatus === "Paid"
                              ? "green"
                              : "red"
                          }
                        />
                      </div>
                    </td>
                    <td className={classes}>
                    </td>
                  </tr>
                );
              }
            )}
          </tbody>
        </table>
      </CardBody>
    </Card>
  );
}

export default AdminPaymentsPage;
