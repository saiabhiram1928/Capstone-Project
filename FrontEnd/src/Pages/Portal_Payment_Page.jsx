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
  const [loading, setLoading] = useState(true);
  const [searchTerm, setSearchTerm] = useState("");

  const handleSearchChange = (event) => {
    setSearchTerm(event.target.value);
  };

  const handleSearchSubmit = async () => {
    const id = searchTerm.length > 0 ? searchTerm : -1;
    await fetchData(id);
  };

  const fetchData = async (searchValue) => {
    try {
      setLoading(true);
      const data = await GetPayments(searchValue);
      setRows(data);
    } catch (err) {
      alert(err);
    } finally {
      setLoading(false);
    }
  };

  useEffect(() => {
    fetchData(-1);
  }, []);
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
          <div className="flex items-center gap-2">
            <Input
              type="text"
              label='Enter Policy Id'
              placeholder="Search by Policy ID"
              value={searchTerm}
              onChange={handleSearchChange}
              className="w-full "
            />
            <Button variant="filled" onClick={handleSearchSubmit}>
              Search
            </Button>
          </div>
        </div>
      </CardHeader>
      <CardBody className="px-0">
        <table className="w-full min-w-max table-auto text-left">
          <thead>
            <tr>
              {TABLE_HEAD.map((head, index) => (
                <th
                  key={index}
                  className="border-y border-blue-gray-100 bg-blue-gray-50/50 p-4"
                >
                  <Typography
                    variant="small"
                    color="blue-gray"
                    className="font-normal leading-none opacity-70"
                  >
                    {head}
                  </Typography>
                </th>
              ))}
            </tr>
          </thead>
          <tbody>
            {rows.map(
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
                const isLast = index === rows.length - 1;
                const classes = isLast
                  ? "p-4"
                  : "p-4 border-b border-blue-gray-50";

                return (
                  <tr key={index}>
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
