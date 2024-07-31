import { Button, Drawer, Input, Tooltip, Typography, Select, Option } from '@material-tailwind/react';
import React, { useState } from 'react';
import Navbar_Component from '../Components/Navbar_Component';
import { Link, useNavigate } from 'react-router-dom';
import { useAuth } from '../Context/AuthAndStateManager';

const Register_Page = () => {
  const {handlerUserRegister} = useAuth()
  const navigate = useNavigate()
  const [openDrawer, setOpenDrawer] = useState(false);
  const [formData, setFormData] = useState({
    firstName: '',
    lastName: '',
    email: '',
    phoneNumber: '',
    password: '',
    confirmPassword: '',
    address: '',
    pincode: '',
    dob: '',
    gender: ''
  });
  const [errors, setErrors] = useState({});
  const [isPasswordValid, setIsPasswordValid] = useState(false);

  const handleOpenDrawer = () => setOpenDrawer(true);
  const handleCloseDrawer = () => setOpenDrawer(false);

  const passwordRegex = /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$/;

  const validateForm = () => {
    const newErrors = {};
    const emailPattern = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
    const phonePattern = /^[0-9]{10}$/;

    if (!formData.firstName) newErrors.firstName = 'First Name is required';
    if (!formData.lastName) newErrors.lastName = 'Last Name is required';
    if (!emailPattern.test(formData.email)) newErrors.email = 'Invalid email format';
    if (!phonePattern.test(formData.phoneNumber)) newErrors.phoneNumber = 'Phone number must be 10 digits';
    if (!formData.password) newErrors.password = 'Password is required';
    if (!passwordRegex.test(formData.password)) newErrors.password = 'Password must be at least 8 characters long, contain an uppercase letter, a lowercase letter, a digit, and a special character';
    if (formData.password !== formData.confirmPassword) newErrors.confirmPassword = 'Passwords do not match';
    if (!formData.address) newErrors.address = 'Address is required';
    if (!formData.pincode && formData.pincode.length >=5 ) newErrors.pincode = 'Pincode is required and length 5 digits';
    if (!formData.dob) newErrors.dob = 'Date of Birth is required';
    if (!formData.gender) newErrors.gender = 'Gender is required';

    setErrors(newErrors);
    return Object.keys(newErrors).length === 0;
  };
  const handleSelectChange = (value) => {
    setFormData({ ...formData, gender: value });
  };
  const handleChange = (e) => {
    const { name, value } = e.target;
    setFormData({ ...formData, [name]: value });
    if (name === 'password') {
      setIsPasswordValid(passwordRegex.test(value));
      const newErrors = {}
      if (!passwordRegex.test(formData.password)) newErrors.password = 'Password must be at least 8 characters long, contain an uppercase letter, a lowercase letter, a digit, and a special character';
      setErrors(newErrors);
    }
  };

  const handleSubmit =  async(e) => {
    e.preventDefault();
    if (validateForm()) {
      try{
        const res = await handlerUserRegister(formData)
        alert("User Created Sucessfully")
        window.location.href = '/'
      }catch(ex){
        alert(ex)
      }       
    }
  };

  return (
    <div className="mx-auto font-mono bg-[#F5FEFD] p-6 font-mono">
      <div className="text-center mb-10">
        <div className='flex items-center justify-center bg-gray-20'>
          <Tooltip>
            <Button onClick={handleOpenDrawer} size='md' className='text-3xl' variant="outlined">CARE</Button>
          </Tooltip>
          <Drawer size={60} placement="top" open={openDrawer} className='grid grid-cols-3 bg-[#FFF8DC]' onClose={handleCloseDrawer}>
            <div className='py-3 underline cursor-pointer'><Link to="/" >Home</Link> </div>
            <div className='py-3 underline cursor-pointer'><Link to="/login">Login</Link> </div>
            <div className='py-3 underline cursor-pointer'><Link to = "/login">Get a Call From Agent</Link> </div>
          </Drawer>
        </div>
        <Typography variant='paragraph' className='font-mono'>Register</Typography>
      </div>

      <form onSubmit={handleSubmit}>
        <div className="grid sm:grid-cols-2 gap-8">
          <div>
          <Input
            name='firstName'
            value={formData.firstName}
            onChange={handleChange}
            label='First Name'
            size="lg"
            placeholder='Enter your First Name'
            required
          />
          {errors.firstName && <Typography className="text-red-800 text-sm">{errors.firstName}</Typography>}
          </div>
          <div>
          <Input
            name='lastName'
            value={formData.lastName}
            onChange={handleChange}
            label='Last Name'
            size='lg'
            placeholder='Enter your Last Name'
            required
          />
          {errors.lastName && <Typography className="text-red-800 text-sm">{errors.lastName}</Typography>}
          </div>
          
          <div>
          <Input
            name='email'
            value={formData.email}
            onChange={handleChange}
            label='Email'
            size='lg'
            type='email'
            placeholder='Enter your Email'
            required
          />
          {errors.email && <Typography className="text-red-800 text-sm">{errors.email}</Typography>}
          </div>
         <div>
         <Input
            name='phoneNumber'
            value={formData.phoneNumber}
            onChange={handleChange}
            label='Phone Number'
            size='lg'
            type='tel'
            placeholder='Enter your Phone Number'
            required
          />
          {errors.phoneNumber && <Typography className="text-red-800 text-sm">{errors.phoneNumber}</Typography>}
         </div>
         <div>
         <Input
            name='password'
            value={formData.password}
            onChange={handleChange}
            label='Password'
            size='lg'
            type='password'
            placeholder='Enter your Password'
            required
          />
          {errors.password && <Typography className="text-red-800 text-sm">{errors.password}</Typography>}
         </div>
          
          <div>
          <Input
            name='confirmPassword'
            value={formData.confirmPassword}
            onChange={handleChange}
            label='Confirm Password'
            size='lg'
            type='password'
            placeholder='Confirm your Password'
            required
            disabled={!isPasswordValid} 
          />
          {errors.confirmPassword && <Typography className="text-red-800 text-sm">{errors.confirmPassword}</Typography>}
          </div>
         
         <div>
         <Input
            name='address'
            value={formData.address}
            onChange={handleChange}
            label='Address'
            size='lg'
            type='text'
            placeholder='Enter your Address'
            required
          />
          {errors.address && <Typography className="text-red-800 text-sm">{errors.address}</Typography>}
         </div>
         
         <div>
         <Input
            name='pincode'
            value={formData.pincode}
            onChange={handleChange}
            label='Pincode'
            size='lg'
            type='text'
            placeholder='Enter your Pincode'
            required
          />
          {errors.pincode && <Typography className="text-red-800 text-sm">{errors.pincode}</Typography>}
         </div>
        
        <div>
        <Input
            name='dob'
            value={formData.dob}
            onChange={handleChange}
            label='DOB'
            size='lg'
            type='date'
            placeholder='Enter your Date of Birth'
            required
          />
          {errors.dob && <Typography className="text-red-800 text-sm">{errors.dob}</Typography>}
        </div>

        <div>
        <Select
            name='gender'
            value={formData.gender}
            onChange={(value) => handleSelectChange(value)}
            size='md'
            label="Select Gender"
          >
            <Option value='Male'>Male</Option>
            <Option value='Female'>Female</Option>
          </Select>
          {errors.gender && <Typography className="text-red-800 text-sm">{errors.gender}</Typography>}
        </div>

        </div>

        <div className="!mt-12">
          <button onClick={handleSubmit} className="py-3.5 px-7 text-sm font-semibold tracking-wider rounded-md text-white bg-blue-600 hover:bg-blue-700 focus:outline-none">
            Sign up
          </button>
        </div>
      </form>
    </div>
  );
};

export default Register_Page;
