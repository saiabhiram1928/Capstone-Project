import React, { useEffect, useState } from 'react';
import { Link, useNavigate, useParams } from 'react-router-dom';
import { Button, Dialog, Typography } from "@material-tailwind/react";
import Apply_Claim_Page from './Apply_Claim_Page.jsx';
import { ApplyRenewal, FetchPolicies, fetchPoliciesForAdmin } from '../Context/PolicyManager.jsx';


// Dummy data with claims and payments
// const policies = [
//   {
//     policyId: 1,
//     scheme: { schemeName: 'Family Elite Policy' },
//     policyStartDate: '2024-01-01',
//     policyEndDate: '2025-01-01',
//     premiumAmount: 1000,
//     quoteAmount: 1200,
//     lastPaymentDate: '2024-06-01',
//     nextPaymentDueDate: '2024-07-01',
//     policyExpiryDate: '2025-01-01',
//     renewalStatus: 'Active',
//     familyMembers: [
//       { id: 1, name: 'John Doe' },
//       { id: 2, name: 'Jane Doe' }
//     ],
//     claims: [
//       {
//         claimId: 1,
//         claimAmount: 500,
//         claimStatus: 'Approved',
//         claimedDate: '2024-02-01',
//         acceptedDate: '2024-03-01',
//       }
//     ],
//     payments: [
//       {
//         transactionId: 1,
//         paymentAmount: 250,
//         paymentDate: '2024-01-15',
//         paymentStatus: 'Completed'
//       }
//     ]
//   },
//   {
//     policyId: 2,
//     scheme: { schemeName: 'Corporate Standard Policy' },
//     policyStartDate: '2024-02-01',
//     policyEndDate: '2025-02-01',
//     premiumAmount: 5000,
//     quoteAmount: 6000,
//     lastPaymentDate: '2024-07-01',
//     nextPaymentDueDate: '2024-08-01',
//     policyExpiryDate: '2025-02-01',
//     renewalStatus: 'Pending',
//     corporateMembers: [
//       { id: 1, name: 'Alice Smith' },
//       { id: 2, name: 'Bob Johnson' }
//     ],
//     claims: [
//       {
//         claimId: 2,
//         claimAmount: 2000,
//         claimStatus: 'Pending',
//         claimedDate: '2024-03-01',
//         acceptedDate: 'N/A',
//       }
//     ],
//     payments: [
//       {
//         transactionId: 2,
//         paymentAmount: 1000,
//         paymentDate: '2024-03-15',
//         paymentStatus: 'Pending'
//       }
//     ]
//   }
// ];

const PolicyDetails = ({ policy }) => {
    console.log(policy);
    const noPaymentsMade = policy.payments.length === 0 || policy.lastPaymentDate === "0001-01-01T00:00:00";
  return (
    <div key={policy.policyId} className="border border-gray-200 p-4 rounded-lg bg-white shadow-sm mb-4">
        <div className='flex md:justify-between justify-evenly items-center mb-5'>
        <Typography variant='h4' className='text-blue-500 mb-4'>
        {policy.scheme.schemeName} 
        </Typography>
        <div>
        </div>
        </div>
    
      <div className="grid grid-cols-1 md:grid-cols-2 gap-4">
        <div><strong>Policy ID:</strong> {policy.policyId}</div>
        <div><strong>Start Date:</strong> {new Date(policy.policyStartDate).toLocaleDateString()}</div>
        <div><strong>End Date:</strong> {new Date(policy.policyEndDate).toDateString()}</div>
        <div><strong>Premium Amount:</strong> ${policy.premiumAmount}</div>
        <div><strong>Quote Amount:</strong> ${policy.quoteAmount}</div>
        <div><strong>Last Payment Date:</strong> {noPaymentsMade ? 'No payments made' : new Date(policy.lastPaymentDate).toLocaleDateString()}</div>
        <div><strong>Next Payment Due Date:</strong> {new Date(policy.nextPaymentDueDate).toDateString()}</div>
        <div><strong>Expiry Date:</strong> {new Date(policy.policyExpiryDate).toDateString()}</div>
        <div><strong>Renewal Status:</strong> {policy.renewalStatus}</div>
        <div><strong>Scheme Type:</strong> {policy.scheme.schemeType}</div>
        {policy.familyMembers && policy.familyMembers.length > 0 && (
          <div>
            <strong>Family Members:</strong>
            <ul className="list-disc ml-4">
              {policy.familyMembers.map(member => (
                <li key={member.id}>{member.name}</li>
              ))}
            </ul>
          </div>
        )}
        {policy.corporateMembers && policy.corporateMembers.count > 0 && (
          <div>
            <strong>Corporate Members:</strong>
            <ul className="list-disc ml-4">
              {policy.corporateMembers.map(member => (
                <li key={member.id}>{member.name}</li>
              ))}
            </ul>
          </div>
        )}
      </div>
      {policy.claims && (
        <div className="mt-6">
          <Typography variant='h6' className='text-blue-500 mb-2'>
            Claims
          </Typography>
          {policy.claims.length > 0 ? (
            <div className="bg-gray-100 p-4 rounded-lg shadow-md">
              <table className="min-w-full divide-y divide-gray-300">
                <thead className="bg-gray-200">
                  <tr>
                    <th className="px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider">Claim ID</th>
                    <th className="px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider">Amount</th>
                    <th className="px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider">Status</th>
                    <th className="px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider">Claimed Date</th>
                    <th className="px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider">Accepted Date</th>
                    <th className="px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider">Claim Reason</th>
                  </tr>
                </thead>
                <tbody className="bg-white divide-y divide-gray-300">
                  {policy.claims.map(claim => (
                    <tr key={claim.claimId}>
                      <td className="px-6 py-4 whitespace-nowrap text-sm font-medium text-gray-900">{claim.claimId}</td>
                      <td className="px-6 py-4 whitespace-nowrap text-sm text-gray-500">${claim.claimAmount}</td>
                      <td className="px-6 py-4 whitespace-nowrap text-sm text-gray-500">{claim.claimStatus}</td>
                      <td className="px-6 py-4 whitespace-nowrap text-sm text-gray-500">{new Date(claim.claimedDate).toLocaleDateString()}</td>
                      <td className="px-6 py-4 whitespace-nowrap text-sm text-gray-500">{claim.acceptedDate ===  "0001-01-01T00:00:00" ? "TBA" : new Date(claim.acceptedDate).toLocaleDateString()}</td>
                      <td className="px-6 py-4 whitespace-nowrap text-sm text-gray-500">{claim.claimReason}</td>
                    </tr>
                  ))}
                </tbody>
              </table>
            </div>
          ) : (
            <Typography>No claims available.</Typography>
          )}
        </div>
      )}

      {/* Payments Section */}
      {policy.payments && (
        <div className="mt-6">
          <Typography variant='h6' className='text-blue-500 mb-2'>
            Payments
          </Typography>
          {policy.payments.length > 0 ? (
            <div className="bg-gray-100 p-4 rounded-lg shadow-md">
              <table className="min-w-full divide-y divide-gray-300">
                <thead className="bg-gray-200">
                  <tr>
                    <th className="px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider">Transaction ID</th>
                    <th className="px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider">Amount</th>
                    <th className="px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider">Date</th>
                    <th className="px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider">Status</th>
                  </tr>
                </thead>
                <tbody className="bg-white divide-y divide-gray-300">
                  {policy.payments.map(payment => (
                    <tr key={payment.transactionId}>
                      <td className="px-6 py-4 whitespace-nowrap text-sm font-medium text-gray-900">{payment.transactionId}</td>
                      <td className="px-6 py-4 whitespace-nowrap text-sm text-gray-500">${payment.paymentAmount}</td>
                      <td className="px-6 py-4 whitespace-nowrap text-sm text-gray-500">{new Date(payment.paymentDate).toLocaleDateString()}</td>
                      <td className="px-6 py-4 whitespace-nowrap text-sm text-gray-500">{payment.paymentStatus}</td>
                    </tr>
                  ))}
                </tbody>
              </table>
            </div>
          ) : (
            <Typography>No payments available.</Typography>
          )}
        </div>
      )}

{policy.renewals && (
                <div className="mt-6">
                    <Typography variant='h6' className='text-blue-500 mb-2'>
                        Renewals
                    </Typography>
                    {policy.renewals.length > 0 ? (
                        <div className="bg-gray-100 p-4 rounded-lg shadow-md">
                            <table className="min-w-full divide-y divide-gray-300">
                                <thead className="bg-gray-200">
                                    <tr>
                                        <th className="px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider">Renewal ID</th>
                                        <th className="px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider">Renewal Date</th>
                                        <th className="px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider">Status</th>
                                    </tr>
                                </thead>
                                <tbody className="bg-white divide-y divide-gray-300">
                                    {policy.renewals.map(renewal => (
                                        <tr key={renewal.renewalId}>
                                            <td className="px-6 py-4 whitespace-nowrap text-sm font-medium text-gray-900">{renewal.renewalId}</td>
                                            <td className="px-6 py-4 whitespace-nowrap text-sm text-gray-500">{new Date(renewal.renewalDate).toLocaleDateString()}</td>
                                            <td className="px-6 py-4 whitespace-nowrap text-sm text-gray-500">{renewal.renewalStatus}</td>
                                        </tr>
                                    ))}
                                </tbody>
                            </table>
                        </div>
                    ) : (
                        <Typography>No renewals available.</Typography>
                    )}
                </div>
            )}
    </div>
  );
};

// Main page component
const Portal_Policy_Page = () => {
  const {id} = useParams();
  const navigate = useNavigate();
  const [policies, setPolicies] = useState([]);
  const [loading, setLoading] = useState(false)
  useEffect(()=>{
    const fetchData = async ()=>{
      try{
        setLoading(true);
        const data = await fetchPoliciesForAdmin(parseInt(id));
        setPolicies(data)
      }catch(err){
        alert(err)
        navigate("/404-notfound")
      }finally{
        setLoading(false);
       
      }
    }
    fetchData();
  },[])
  if(loading) return <h1>Loading ....</h1>
  return (
    <div className='container md:py-10 md:px-5 font-mono'>
      <Typography variant='h2' className='text-start my-5'>
        Policies
      </Typography>
      {policies.length > 0 ? (
        policies.map(policy => (
          <PolicyDetails key={policy.policyId} policy={policy} />
        ))
      ) : (
        <Typography>No policies applied. <Link to="/policy-page" className="text-blue-500 underline">Apply for a policy</Link></Typography>
      )}
    </div>
  );
};

export default Portal_Policy_Page;
