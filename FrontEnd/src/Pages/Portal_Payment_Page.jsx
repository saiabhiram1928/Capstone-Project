import React, { useEffect, useState } from 'react';
import {
  Card,
  CardHeader,
  Typography,
  Button,
  CardBody,
  Chip,
  Tooltip,
  Input
} from "@material-tailwind/react";
import { GetPayments, PremiumPayment } from '../Context/PolicyManager';

const TABLE_HEAD = ["Policy ID", "Payment Amount", "Payment Type", "Due Date", "Status", ""];

export function PortalPaymentPage() {
  const [rows, setRows] = useState([]);
  const [filteredRows, setFilteredRows] = useState([]);
  const [sortConfig, setSortConfig] = useState({ key: null, direction: 'asc' });
  const [loading, setLoading] = useState(true);
  const [searchTerm, setSearchTerm] = useState("");

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

  const handleSearch = (event) => {
    setSearchTerm(event.target.value);
  };

  useEffect(() => {
    const fetchData = async () => {
      try {
        setLoading(true);
        const data = await GetPayments();
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
    const filteredData = rows.filter(row =>
      row.policyId.toString().includes(lowercasedTerm)
    );
    setFilteredRows(filteredData);
  }, [searchTerm, rows]);

  const HandlePayment = async (id) => {
    try {
      setLoading(true);
      const data = await PremiumPayment(id);
      alert(data.message);
      window.location.reload();
    } catch (err) {
      alert(err);
    } finally {
      setLoading(false);
    }
  };

  if (loading) return <h1>Loading ..</h1>;

  return (
    <Card className="h-full w-full p-4">
      <CardHeader floated={false} shadow={false} className="rounded-none pb-4">
        <div className="mb-4 flex flex-col justify-between gap-8 md:flex-row md:items-center">
          <div>
            <Typography variant="h5" color="blue-gray">
              Premium Payments
            </Typography>
            <Typography color="gray" className="mt-1 font-normal">
              List of Premium payments associated with your policies
            </Typography>
            
          </div>
          <Input
            type="text"
            label='Enter Policy Id'
            placeholder="Search by Policy ID"
            value={searchTerm}
            onChange={handleSearch}
            className="w-full "
          />
        </div>
      </CardHeader>
      <CardBody className="px-0">
        <table className="w-full min-w-max table-auto text-left">
          <thead>
            <tr>
              {TABLE_HEAD.map((head, index) => {
                const isSortable = head === "Status" || head === "Due Date";
                const key = head === "Status" ? 'paymentStatus' : (head === "Due Date" ? 'paymentDueDate' : null);

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
                  id,
                  policyId,
                  paymentAmount,
                  paymentType,
                  paymentDueDate,
                  paymentStatus,
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
                        className="font-normal"
                      >
                        #{policyId}
                      </Typography>
                    </td>
                    <td className={classes}>
                      <Typography
                        variant="small"
                        color="blue-gray"
                        className="font-normal"
                      >
                        {paymentAmount}
                      </Typography>
                    </td>
                    <td className={classes}>
                      <Typography
                        variant="small"
                        color="blue-gray"
                        className="font-normal"
                      >
                        {paymentType}
                      </Typography>
                    </td>
                    <td className={classes}>
                      <Typography
                        variant="small"
                        color="blue-gray"
                        className="font-normal"
                      >
                        {new Date(paymentDueDate).toDateString()}
                      </Typography>
                    </td>
                    <td className={classes}>
                      <div className="w-max">
                        <Chip
                          size="sm"
                          variant="ghost"
                          value={ paymentStatus}
                          color={
                            paymentStatus === "Paid"
                              ? "green"
                              : "red"
                          }
                        />
                      </div>
                    </td>
                    <td className={classes}>
                      {paymentStatus === "Pending" && (
                        <Tooltip content="Pay Now">
                          <Button variant="outlined" size="sm" onClick={() => HandlePayment(id)}>
                            Pay
                          </Button>
                        </Tooltip>
                      )}
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

export default PortalPaymentPage;
