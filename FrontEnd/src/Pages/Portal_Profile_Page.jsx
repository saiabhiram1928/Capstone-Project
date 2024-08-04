import React, { useState, useEffect } from 'react';
import { Card, CardBody, Typography, Textarea, Input, Button, Select, Option } from '@material-tailwind/react';
import { FetchUserProfile, UpdateProfile } from '../Context/ProfileManager'; // Adjust import path as needed

const Portal_Profile_Page = () => {
  const [isEditing, setIsEditing] = useState(false);
  const [formData, setFormData] = useState({
    firstName: '',
    lastName: '',
    email: '',
    dateOfBirth: '',
    gender: '',
    address: '',
    zipcode: '',
    mobileNumber: '',
    createdAt: '',
    lastUpdatedAt: '',
  });
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    const fetchProfile = async () => {
      try {
        const data = await FetchUserProfile();
        setFormData({
          firstName: data.firstName || '',
          lastName: data.lastName || '',
          email: data.email || '',
          dateOfBirth: data.dateOfBirth || '',
          gender: data.gender || '',
          address: data.address || '',
          zipcode: data.zipcode || '',
          mobileNumber: data.mobileNumber || '',
          createdAt: data.createdAt || '',
          lastUpdatedAt: data.lastUpdatedAt || '',
        });
      } catch (error) {
        alert(err)
      } finally {
        setLoading(false);
      }
    };

    fetchProfile();
  }, []);

  const handleEditToggle = () => {
    setIsEditing(!isEditing);
  };

  const handleChange = (e) => {
    const { name, value } = e.target;
    setFormData({ ...formData, [name]: value });
  };

  const handleSelectChange = (value) => {
    setFormData({ ...formData, gender: value });
  };

  const handleSubmit = async (e) => {
    e.preventDefault();
   
    try {
      setLoading(true);
      console.log('Updated Profile Data:', formData);
      const data =await UpdateProfile(formData);
      alert(data.message);
      window.location.reload()
    } catch (error) {
      alert(error)
    }finally{
      setLoading(false);
    }
  };

  if (loading) return <div>Loading...</div>;

  return (
    <div className="flex-1 p-4 w-full overflow-hidden">
      <Card className="w-full max-w-4xl mx-auto p-4 overflow-hidden">
        <CardBody>
          <Typography variant="h4" color="blue-gray" className="mb-4">
            Profile Information
          </Typography>
          <form onSubmit={handleSubmit} className="space-y-4">
            <div className="grid grid-cols-1 md:grid-cols-2 gap-4">
              <Input
                label="First Name"
                name="firstName"
                value={formData.firstName || ''}
                onChange={handleChange}
                disabled={!isEditing}
              />
              <Input
                label="Last Name"
                name="lastName"
                value={formData.lastName || ''}
                onChange={handleChange}
                disabled={!isEditing}
              />
              <Input
                label="Email"
                type="email"
                name="email"
                value={formData.email || ''}
                onChange={handleChange}
                disabled
              />
              <Input
                label="Mobile Number"
                name="mobileNumber"
                value={formData.mobileNumber || ''}
                onChange={handleChange}
                disabled
              />
              <Input
                label="Date of Birth"
                type="date"
                name="dateOfBirth"
                value={formData.dateOfBirth || ''}
                onChange={handleChange}
                disabled={!isEditing}
              />
              <Select
                label="Gender"
                name="gender"
                value={formData.gender}
                onChange={handleSelectChange}
                disabled={!isEditing}
              >
                <Option value='Male'>Male</Option>
                <Option value='Female'>Female</Option>
              </Select>
              <Textarea
                label="Address"
                name="address"
                value={formData.address || ''}
                onChange={handleChange}
                disabled={!isEditing}
              />
              <Input
                label="Zipcode"
                name="zipcode"
                value={formData.zipcode || ''}
                onChange={handleChange}
                disabled={!isEditing}
              />
              <div>
                <Typography>Created At</Typography>
                <Input
                  label="Created At"
                  type="date"
                  name="createdAt"
                  value={formData.createdAt || ''}
                  disabled
                />
              </div>
              <div>
                <Typography>Last Updated At</Typography>
                <Input
                  label="Last Updated"
                  type="date"
                  name="lastUpdatedAt"
                  value={formData.lastUpdatedAt || ''}
                  disabled
                />
              </div>
            </div>
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

export default Portal_Profile_Page;
