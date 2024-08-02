import React, { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import { Button, Input, Select, Option, Typography } from '@material-tailwind/react';
import { ApplyClaim } from '../Context/PolicyManager';

const Apply_Claim_Page = ({ policy }) => {
  const navigate = useNavigate();
  const [formData, setFormData] = useState({
    scheme: policy.scheme.routeTitle || '',
    claimAmount: '',
    reason: ''
  });
  const [errors, setErrors] = useState({});

  const validateForm = (data) => {
    const newErrors = {};
    const claimAmount = parseFloat(data.claimAmount);

    // Check if claimAmount is a positive number
    if (!data.claimAmount || isNaN(claimAmount) || claimAmount <= 0) {
      newErrors.claimAmount = 'Claim amount must be a positive number';
    } 
    // Check if claimAmount exceeds coverageAmount
    else if (claimAmount > policy.coverageAmount) {
      newErrors.claimAmount = `Claim amount cannot exceed the coverage amount of ${policy.coverageAmount}`;
    }
    // Check if claimAmount exceeds quoteAmount
    else if (claimAmount > policy.quoteAmount) {
      newErrors.claimAmount = `Claim amount cannot exceed the quoted amount of ${policy.quoteAmount}`;
    }

    if (!data.reason) {
      newErrors.reason = 'Reason for claim is required';
    }

    setErrors(newErrors);
  };

  const handleChange = (e) => {
    const { name, value } = e.target;
    const updatedData = { ...formData, [name]: value };
    setFormData(updatedData);
    validateForm(updatedData);
  };
  console.log('Claim data:' , policy);
  const handleSubmit = async (e) => {
    e.preventDefault();
    // Validate once more before submitting
    validateForm(formData);
    if (Object.keys(errors).length === 0) {
      const bodyData = {
        claimAmount : parseFloat(formData.claimAmount) ,
        claimReason : formData.reason,
        schemeId : policy.scheme.schemeId,
        policyId : policy.policyId
      }
      try {
        const data = await ApplyClaim(bodyData)
        alert(data.message);
        window.location.reload();
      } catch (error) {
        console.error('Error submitting claim:', error);
        alert('Failed to submit claim');
      }
    }
  };

  return (
    <div className="mx-auto p-6 bg-white rounded-lg shadow-md w-full">
      <div className="text-center mb-6">
        <Typography variant="h4">Apply for Claim</Typography>
      </div>
      <form onSubmit={handleSubmit}>
        <div className="mb-4">
          <Select
            name="scheme"
            value={formData.scheme}
            onChange={(value) => {
              setFormData({ ...formData, scheme: value });
              validateForm({ ...formData, scheme: value });
            }}
            label="Select Scheme"
            disabled
          >
            <Option value={formData.scheme}>{formData.scheme}</Option>
          </Select>
          {errors.scheme && <Typography className="text-red-800 text-sm">{errors.scheme}</Typography>}
        </div>
        
        <div className="mb-4">
          <Input
            name="claimAmount"
            value={formData.claimAmount}
            onChange={handleChange}
            label="Claim Amount"
            size="lg"
            type="number"
            placeholder="Enter claim amount"
            required
          />
          {errors.claimAmount && <Typography className="text-red-800 text-sm">{errors.claimAmount}</Typography>}
        </div>

        <div className="mb-4">
          <Input
            name="reason"
            value={formData.reason}
            onChange={handleChange}
            label="Reason for Claim"
            size="lg"
            type="text"
            placeholder="Enter reason for the claim"
            required
          />
          {errors.reason && <Typography className="text-red-800 text-sm">{errors.reason}</Typography>}
        </div>

        <div className="mt-6">
          <Button
            type="submit"
            className="py-3.5 px-7 text-sm font-semibold tracking-wider rounded-md text-white bg-blue-600 hover:bg-blue-700"
          >
            Submit Claim
          </Button>
        </div>
      </form>
    </div>
  );
};

export default Apply_Claim_Page;
