import React, { useState } from 'react';
import { Card, CardBody, Typography, Textarea, Input, Button, Select, Option } from '@material-tailwind/react';
import { CreateScheme } from '../Context/ScehmesManager';

const Admin_AddSchemes_Page = () => {
  const [schemeData, setSchemeData] = useState({
    schemeName: '',
    coverageAmount: '',
    basePremiumAmount: '',
    paymentTerm: '',
    coverageYears: '',
    baseCoverageAmount: '',
    schemeType: 'Individual', 
    routeTitle: '',
    smallDescription: '',
    schemeDescription: '',
   
  });
  const [errors, setErrors] = useState({});
  const [loading, setLoading] = useState(false);

  const handleChange = (e) => {
    const { name, value } = e.target;
    if (name === 'routeTitle') {
      const updatedValue = value.replace(/\s+/g, '-').slice(0, 30);
      setSchemeData({ ...schemeData, [name]: updatedValue });
      if (updatedValue.length > 30) {
        setErrors({ ...errors, routeTitle: 'Route Title must be 30 characters or less' });
      } else {
        setErrors({ ...errors, routeTitle: '' });
      }
    } else if (name === 'smallDescription') {
      const wordCount = value.split(/\s+/).length;
      if (wordCount > 20) {
        setErrors({ ...errors, smallDescription: 'Small Description cannot exceed 20 words' });
      } else {
        setErrors({ ...errors, smallDescription: '' });
        setSchemeData({ ...schemeData, [name]: value });
      }
    } else {
      setSchemeData({ ...schemeData, [name]: value });
      // Clear errors when user starts typing
      setErrors((prevErrors) => ({ ...prevErrors, [name]: '' }));
    }
  };

  const handleSelectChange = (value) => {
    setSchemeData({ ...schemeData, schemeType: value });
    setErrors((prevErrors) => ({ ...prevErrors, schemeType: '' }));
  };

  const validateForm = () => {
    const newErrors = {};
    if (!schemeData.schemeName) newErrors.schemeName = 'Scheme Name is required';
    if (schemeData.coverageAmount <= 0) newErrors.coverageAmount = 'Coverage Amount must be a positive number';
    if (schemeData.basePremiumAmount <= 0) newErrors.basePremiumAmount = 'Base Premium Amount must be a positive number';
    if (schemeData.paymentTerm <= 0) newErrors.paymentTerm = 'Payment Term must be a positive number';
    if (schemeData.coverageYears <= 0) newErrors.coverageYears = 'Coverage Years must be a positive number';
    if (schemeData.baseCoverageAmount <= 0) newErrors.baseCoverageAmount = 'Base Coverage Amount must be a positive number';
    if (!schemeData.routeTitle) newErrors.routeTitle = 'Route Title is required';
    if (schemeData.smallDescription.split(/\s+/).length > 20) newErrors.smallDescription = 'Small Description cannot exceed 20 words';
    if (!schemeData.schemeType) newErrors.schemeType = 'Scheme Type is required';
    
    setErrors(newErrors);
    return Object.keys(newErrors).length === 0;
  };

  const handleSubmit = async (e) => {
    e.preventDefault();

    if (!validateForm()) return;

    try {
      setLoading(true);
      const data = await CreateScheme(schemeData); 
      alert(data.message);
      setSchemeData({
        schemeName: '',
        coverageAmount: '',
        basePremiumAmount: '',
        paymentTerm: '',
        coverageYears: '',
        baseCoverageAmount: '',
        schemeType: 'Individual',
        routeTitle: '',
        smallDescription: '',
        schemeDescription: '',
      });
    } catch (error) {
      alert(error);
    } finally {
      setLoading(false);
    }
  };

  if (loading) return <div>Loading...</div>;

  return (
    <div className="flex-1 p-4 w-full overflow-hidden">
      <Card className="w-full max-w-4xl mx-auto p-4 overflow-hidden">
        <CardBody>
          <Typography variant="h4" color="blue-gray" className="mb-4">
            Add New Scheme
          </Typography>
          <form onSubmit={handleSubmit} className="space-y-4">
            <div className="grid grid-cols-1 md:grid-cols-2 gap-4">
              <div className="relative">
                <Input
                  label="Scheme Name"
                  name="schemeName"
                  value={schemeData.schemeName}
                  onChange={handleChange}
                />
                {errors.schemeName && (
                  <Typography variant="small" color="red" className="absolute bottom-0 left-0 text-sm">
                    {errors.schemeName}
                  </Typography>
                )}
              </div>
              <div className="relative">
                <Input
                  label="Coverage Amount"
                  type="number"
                  name="coverageAmount"
                  value={schemeData.coverageAmount}
                  onChange={handleChange}
                />
                {errors.coverageAmount && (
                  <Typography variant="small" color="red" className="absolute bottom-0 left-0 text-sm">
                    {errors.coverageAmount}
                  </Typography>
                )}
              </div>
              <div className="relative">
                <Input
                  label="Base Premium Amount"
                  type="number"
                  name="basePremiumAmount"
                  value={schemeData.basePremiumAmount}
                  onChange={handleChange}
                />
                {errors.basePremiumAmount && (
                  <Typography variant="small" color="red" className="absolute bottom-0 left-0 text-sm">
                    {errors.basePremiumAmount}
                  </Typography>
                )}
              </div>
              <div className="relative">
                <Input
                  label="Payment Term (Months)"
                  type="number"
                  name="paymentTerm"
                  value={schemeData.paymentTerm}
                  onChange={handleChange}
                />
                {errors.paymentTerm && (
                  <Typography variant="small" color="red" className="absolute bottom-0 left-0 text-sm">
                    {errors.paymentTerm}
                  </Typography>
                )}
              </div>
              <div className="relative">
                <Input
                  label="Coverage Years"
                  type="number"
                  name="coverageYears"
                  value={schemeData.coverageYears}
                  onChange={handleChange}
                />
                {errors.coverageYears && (
                  <Typography variant="small" color="red" className="absolute bottom-0 left-0 text-sm">
                    {errors.coverageYears}
                  </Typography>
                )}
              </div>
              <div className="relative">
                <Input
                  label="Base Coverage Amount"
                  type="number"
                  name="baseCoverageAmount"
                  value={schemeData.baseCoverageAmount}
                  onChange={handleChange}
                />
                {errors.baseCoverageAmount && (
                  <Typography variant="small" color="red" className="absolute bottom-0 left-0 text-sm">
                    {errors.baseCoverageAmount}
                  </Typography>
                )}
              </div>
              <div className="relative">
                <Select
                  label="Scheme Type"
                  name="schemeType"
                  value={schemeData.schemeType}
                  onChange={(value) => handleSelectChange(value)}
                >
                  <Option value="Individual">Individual</Option>
                  <Option value="Family">Family</Option>
                  <Option value="Corporate">Corporate</Option>
                </Select>
                {errors.schemeType && (
                  <Typography variant="small" color="red" className="absolute bottom-0 left-0 text-sm">
                    {errors.schemeType}
                  </Typography>
                )}
              </div>
              <div className="relative">
                <Input
                  label="Route Title"
                  name="routeTitle"
                  value={schemeData.routeTitle}
                  onChange={handleChange}
                />
                {errors.routeTitle && (
                  <Typography variant="small" color="red" className="absolute bottom-0 left-0 text-sm">
                    {errors.routeTitle}
                  </Typography>
                )}
              </div>
              <div className="relative">
                <Textarea
                  label="Small Description"
                  name="smallDescription"
                  value={schemeData.smallDescription}
                  onChange={handleChange}
                />
                {errors.smallDescription && (
                  <Typography variant="small" color="red" className="absolute bottom-0 left-0 text-sm">
                    {errors.smallDescription}
                  </Typography>
                )}
              </div>
            </div>
            <Textarea
              label="Scheme Description"
              name="schemeDescription"
              value={schemeData.schemeDescription}
              onChange={handleChange}
            />
            <div className="flex justify-end space-x-4">
              <Button type="submit" color="green">
                Add Scheme
              </Button>
            </div>
          </form>
        </CardBody>
      </Card>
    </div>
  );
};

export default Admin_AddSchemes_Page;
