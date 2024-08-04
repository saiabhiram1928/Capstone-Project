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
} from '@material-tailwind/react';
import { GetAllClaimsForAdmin, UpdateClaimStatus } from '../Context/PolicyManager';
import { Link } from 'react-router-dom';

const TABLE_HEAD = ["Claim ID", "Customer Email", "Claim Applied On", "Claim Amount", "Claim Status", "Actions"];

const claimsData = [
  { claimId: 1, customerEmail: 'john.doe@example.com', claimAppliedOn: '2024-07-15', claimAmount: 500, claimStatus: 'Pending' },
  { claimId: 2, customerEmail: 'jane.smith@example.com', claimAppliedOn: '2024-07-16', claimAmount: 1500, claimStatus: 'Pending' },
  { claimId: 3, customerEmail: 'mark.jones@example.com', claimAppliedOn: '2024-07-17', claimAmount: 3000, claimStatus: 'Pending' },
  { claimId: 4, customerEmail: 'lucy.white@example.com', claimAppliedOn: '2024-07-18', claimAmount: 400, claimStatus: 'Accepted' },
  { claimId: 5, customerEmail: 'ryan.brown@example.com', claimAppliedOn: '2024-07-19', claimAmount: 800, claimStatus: 'Rejected' },
  { claimId: 6, customerEmail: 'susan.green@example.com', claimAppliedOn: '2024-07-20', claimAmount: 200, claimStatus: 'Pending' },
  { claimId: 7, customerEmail: 'david.lee@example.com', claimAppliedOn: '2024-07-21', claimAmount: 2200, claimStatus: 'Pending' },
  { claimId: 8, customerEmail: 'emily.martin@example.com', claimAppliedOn: '2024-07-22', claimAmount: 600, claimStatus: 'Pending' },
  { claimId: 9, customerEmail: 'steve.harris@example.com', claimAppliedOn: '2024-07-23', claimAmount: 1000, claimStatus: 'Pending' },
  { claimId: 10, customerEmail: 'anna.lee@example.com', claimAppliedOn: '2024-07-24', claimAmount: 350, claimStatus: 'Pending' },
];

const AdminClaimsPage = ()=> {
  const [rows, setRows] = useState([]);
  const [filteredRows, setFilteredRows] = useState(claimsData);
  const [sortConfig, setSortConfig] = useState({ key: null, direction: 'asc' });
  const [loading, setLoading] = useState(false);
  const [searchTerm, setSearchTerm] = useState("");

  const handleSort = (key) => {
    let direction = 'asc';
    if (sortConfig.key === key && sortConfig.direction === 'asc') {
      direction = 'desc';
    }
    setSortConfig({ key, direction });

    const sortedRows = [...filteredRows].sort((a, b) => {
      if (a[key] < b[key]) {
        return direction === 'asc' ? -1 : 1;
      }
      if (a[key] > b[key]) {
        return direction === 'asc' ? 1 : -1;
      }
      return 0;
    });
    setFilteredRows(sortedRows);
  };

  const handleSearch = (event) => {
    setSearchTerm(event.target.value);
  };

  useEffect(() => {
    const lowercasedTerm = searchTerm.toLowerCase();
    const filteredData = rows.filter(row =>
      row.claimId.toString().includes(lowercasedTerm) ||
      row.customerEmail.toLowerCase().includes(lowercasedTerm) ||
      row.claimAmount.toString().includes(lowercasedTerm)
    );
    setFilteredRows(filteredData);
  }, [searchTerm, rows]);
useEffect(()=>{
  const fetchData = async()=>{
    try{
      setLoading(true)
      const data = await GetAllClaimsForAdmin();
      setFilteredRows(data);
      setRows(data);
    }catch(err){
      alert(err)
    }finally{
      setLoading(false)
    }
  }
  fetchData()

},[])
  const handleStatusChange = async (claimId, newStatus) => {
    setLoading(true)
    try{
      const data = await UpdateClaimStatus(claimId,newStatus);
      alert(data.message)
      window.location.reload();
    }catch(err){
      alert(err)
    }finally{
      setLoading(false)
    }
  };

  if (loading) return <h1>Loading ..</h1>;

  return (
    <Card className="h-full w-full p-4">
      <CardHeader floated={false} shadow={false} className="rounded-none pb-4">
        <div className="mb-4 flex flex-col justify-between gap-8 md:flex-row md:items-center">
          <div>
            <Typography variant="h5" color="blue-gray">
              Claims Management
            </Typography>
            <Typography color="gray" className="mt-1 font-normal">
              List of claims made by users
            </Typography>
          </div>
          <Input
            type="text"
            label='Enter Claim Id'
            placeholder="Search by Claim ID, Email, or Amount"
            value={searchTerm}
            onChange={handleSearch}
            className="w-full"
          />
        </div>
      </CardHeader>
      <CardBody className="px-0">
        {filteredRows.length === 0 ? (
          <Typography variant="h6" color="blue-gray" className="text-center">
            No claims data available
          </Typography>
        ) : (
          <table className="w-full min-w-max table-auto text-left">
            <thead>
              <tr>
                {TABLE_HEAD.map((head, index) => (
                  <th
                    key={index}
                    className="border-y border-blue-gray-100 bg-blue-gray-50/50 p-4 cursor-pointer"
                    onClick={() => handleSort(
                      head === "Claim Status" ? 'claimStatus' :
                      head === "Claim Amount" ? 'claimAmount' :
                      head === "Claim Applied On" ? 'claimAppliedOn' : 
                      head === "Customer Email" ? 'customerEmail' : 
                      head === "Claim ID" ? 'claimId' : 
                      null)}
                  >
                    <div className="flex items-center justify-between">
                      <Typography
                        variant="small"
                        color="blue-gray"
                        className="font-normal leading-none opacity-70"
                      >
                        {head}
                      </Typography>
                      {sortConfig.key === (head === "Claim Status" ? 'claimStatus' :
                      head === "Claim Amount" ? 'claimAmount' :
                      head === "Claim Applied On" ? 'claimAppliedOn' : 
                      head === "Customer Email" ? 'customerEmail' : 
                      head === "Claim ID" ? 'claimId' : null) && (
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
                ))}
              </tr>
            </thead>
            <tbody>
              {filteredRows.map(
                (
                  {
                    claimId,
                    customerEmail,
                    claimAppliedOn,
                    claimAmount,
                    claimStatus,
                    customerId
                  },
                  index,
                ) => {
                  const isLast = index === filteredRows.length - 1;
                  const classes = isLast
                    ? "p-4"
                    : "p-4 border-b border-blue-gray-50";

                  return (
                    <tr key={claimId}>
                      <td className={classes}>
                        <Typography
                          variant="small"
                          color="blue-gray"
                          className="font-normal"
                        >
                          <Link to = {`/portal/admin/claims-policy/${customerId}`}>
                          #{claimId}
                          </Link>
                        </Typography>
                      </td>
                      <td className={classes}>
                        <Typography
                          variant="small"
                          color="blue-gray"
                          className="font-normal"
                        >
                          <Link to={`/portal/admin/claims-policy/${customerId}`}>
                          {customerEmail}
                          </Link>
                          
                        </Typography>
                      </td>
                      <td className={classes}>
                        <Typography
                          variant="small"
                          color="blue-gray"
                          className="font-normal"
                        >
                          {new Date(claimAppliedOn).toDateString()}
                        </Typography>
                      </td>
                      <td className={classes}>
                        <Typography
                          variant="small"
                          color="blue-gray"
                          className="font-normal"
                        >
                          ₹{claimAmount}
                        </Typography>
                      </td>
                      <td className={classes}>
                        <div className="w-max">
                          <Chip
                            size="sm"
                            variant="ghost"
                            value={claimStatus}
                            color={
                              claimStatus === "Accepted"
                                ? "green"
                                : claimStatus === "Rejected"
                                  ? "red"
                                  : "yellow"
                            }
                          />
                        </div>
                      </td>
                      <td className={classes}>
                        {claimStatus === "UnderReview" && (
                          <>
                            <Tooltip content="Accept Claim">
                              <Button variant="outlined" size="sm" onClick={() => handleStatusChange(claimId, 'Accepted')}>
                                Accept
                              </Button>
                            </Tooltip>
                            <Tooltip content="Reject Claim">
                              <Button variant="outlined" size="sm" onClick={() => handleStatusChange(claimId, 'Rejected')}>
                                Reject
                              </Button>
                            </Tooltip>
                          </>
                        )}
                      </td>
                    </tr>
                  );
                }
              )}
            </tbody>
          </table>
        )}
      </CardBody>
    </Card>
  );
}

export default AdminClaimsPage;
