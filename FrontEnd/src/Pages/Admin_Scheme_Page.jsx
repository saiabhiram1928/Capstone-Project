import React, { useState, useEffect } from 'react';
import { Card, CardBody, Typography, Textarea, Input, Button, Select, Option } from '@material-tailwind/react';
import { fetchSchemeByRoute, UpdateScheme } from '../Context/ScehmesManager';
import { useNavigate, useParams } from 'react-router-dom';
// Import your API functions here
// import { FetchSchemeDetails, UpdateScheme } from '../Context/SchemeManager'; 

const dummySchemeData = {
  schemeId: 1,
  schemeName: 'Premium Health Plan',
  schemeDescription: 'Comprehensive health plan with high coverage that includes various medical services and emergency coverage options.',
  coverageAmount: 500000,
  schemeType: 'Individual', // Assuming SchemeTypeEnum corresponds to a string like 'Individual', 'Family', 'Corporate'
  basePremiumAmount: 1500,
  schemeStartedAt: '2024-01-01',
  schemeLastUpdatedAt: '2024-01-15',
  routeTitle: 'premium-health-plan', // No spaces, use dashes
  smallDescription: 'High coverage plan for individuals with extensive benefits and emergency care.',
  isActive: true,
  paymentTerm: 12,
  coverageYears: 1,
  baseCoverageAmount: 500000
};

const AdminSchemePage = () => {
    const {name}  = useParams();
    const navigate = useNavigate()
  const [isEditing, setIsEditing] = useState(false);
  const [schemeData, setSchemeData] = useState({});
  const [errors, setErrors] = useState({});
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    const fetchSchemeDetails = async () => {
      try {
        const data = await fetchSchemeByRoute(name)
        setSchemeData(data);
      } catch (error) {
        alert(error);
        navigate("/portal/admin/schemes")
      }finally{
        setLoading(false);
      }
    };

    fetchSchemeDetails();
  }, []);

  const handleEditToggle = () => {
    setIsEditing(!isEditing);
  };
  const formatDate = (dateString) => {
    const date = new Date(dateString);
    return date.toISOString().split('T')[0]; 
  };
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
    }
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
    
    setErrors(newErrors);
    return Object.keys(newErrors).length === 0;
  };

  const handleSubmit = async (e) => {
    e.preventDefault();

    if (!validateForm()) return;

    try {
      setLoading(true);
      console.log('Updated Scheme Data:', schemeData);
      const data =await UpdateScheme(schemeData , schemeData.schemeId);
      alert(data.message);
      window.location.reload()
    } catch (error) {
      alert(error);
    } finally {
      setLoading(false);
    }
  };console.log(schemeData);

  if (loading) return <div>Loading...</div>;

  return (
    <div className="flex-1 p-4 w-full overflow-hidden">
      <Card className="w-full max-w-4xl mx-auto p-4 overflow-hidden">
        <CardBody>
          <Typography variant="h4" color="blue-gray" className="mb-4">
            Scheme Details
          </Typography>
          <form onSubmit={handleSubmit} className="space-y-4">
            <div className="grid grid-cols-1 md:grid-cols-2 gap-4">
              <Input
                label="Scheme Name"
                name="schemeName"
                value={schemeData.schemeName || ''}
                onChange={handleChange}
                disabled={!isEditing}
                error={errors.schemeName}
              />
              <Input
                label="Coverage Amount"
                type="number"
                name="coverageAmount"
                value={schemeData.coverageAmount || ''}
                onChange={handleChange}
                disabled={!isEditing}
                error={errors.coverageAmount}
              />
              <Input
                label="Base Premium Amount"
                type="number"
                name="basePremiumAmount"
                value={schemeData.basePremiumAmount || ''}
                onChange={handleChange}
                disabled={!isEditing}
                error={errors.basePremiumAmount}
              />
              <Input
                label="Payment Term (Months)"
                type="number"
                name="paymentTerm"
                value={schemeData.paymentTerm || ''}
                onChange={handleChange}
                disabled={!isEditing}
                error={errors.paymentTerm}
              />
              <Input
                label="Coverage Years"
                type="number"
                name="coverageYears"
                value={schemeData.coverageYears || ''}
                onChange={handleChange}
                disabled={!isEditing}
                error={errors.coverageYears}
              />
              <Input
                label="Base Coverage Amount"
                type="number"
                name="baseCoverageAmount"
                value={schemeData.baseCoverageAmount || ''}
                onChange={handleChange}
                disabled={!isEditing}
                error={errors.baseCoverageAmount}
              />
              <Input
                label="Scheme Type"
                name="schemeType"
                value={schemeData.schemeType || ''}
                disabled
              />
              <Input
                label="Route Title"
                name="routeTitle"
                value={schemeData.routeTitle || ''}
                onChange={handleChange}
                disabled={!isEditing}
                error={errors.routeTitle}
              />
              <div>
                <Typography>Started At</Typography>
                <Input
                  label="Started At"
                  type="date"
                  name="schemeStartedAt"
                  value={formatDate(schemeData.schemeStartedAt)}
                  disabled
                />
              </div>
              <div>
                <Typography>Last Updated At</Typography>
                <Input
                  label="Last Updated At"
                  type="date"
                  name="schemeLastUpdatedAt"
                  value={formatDate(schemeData.schemeLastUpdatedAt)}
                  disabled
                />
              </div>
              <Textarea
                label="Small Description"
                name="smallDescription"
                value={schemeData.smallDescription || ''}
                onChange={handleChange}
                disabled={!isEditing}
                maxLength={160} // Approx 20 words
                error={errors.smallDescription}
              />
            </div>
            <Textarea
              label="Scheme Description"
              name="schemeDescription"
              value={schemeData.schemeDescription || ''}
              onChange={handleChange}
              disabled={!isEditing}
            />
            <div className="flex justify-end space-x-4">
              <Button onClick={handleEditToggle} color="blue" variant="outlined">
                {isEditing ? 'Cancel' : 'Edit'}
              </Button>
              {isEditing && (
                <Button type="submit" color="green">
                  Save Changes
                </Button>
              )}
            </div>
          </form>
        </CardBody>
      </Card>
    </div>
  );
};

export default AdminSchemePage;
