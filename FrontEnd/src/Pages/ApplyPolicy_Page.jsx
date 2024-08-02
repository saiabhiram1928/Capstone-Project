import { Button, Drawer, Tooltip, Typography, Input, Radio, Select, Option } from '@material-tailwind/react';
import React, { useState, useEffect } from 'react';
import { Link, useNavigate, useParams } from 'react-router-dom';
import { fetchSchemeByRoute } from '../Context/ScehmesManager';
import { applyPolicy } from '../Context/PolicyManager';

const ApplyPolicy_Page = () => {
  const [openDrawer, setOpenDrawer] = useState(false);
  const handleOpenDrawer = () => setOpenDrawer(true);
  const handleCloseDrawer = () => setOpenDrawer(false);
  const [paymentFreq, setPaymentFreq] = useState("Monthly");
  const [scheme, setScheme] = useState({});
  const [loading, setLoading] = useState(true);
  const [coverageAmount, setCoverageAmount] = useState('');
  const [paymentTerm, setPaymentTerm] = useState('');
  const [optionType, setOptionType] = useState(null);
  const [familyMembers, setFamilyMembers] = useState([{ name: '', adharId: '' }]);
  const [corporateMembers, setCorporateMembers] = useState(Array(5).fill({ name: '', empId: '' }));
  const [errors, setErrors] = useState({
    coverageAmountError: '',
    paymentTermError: '',
    familyMembersError: '',
    corporateMembersError: ''
  });

  const { name } = useParams();
  const navigate = useNavigate();

  useEffect(() => {
    const fetchData = async () => {
      try {
        const data = await fetchSchemeByRoute(name);
        setScheme(data);
      } catch (err) {
        alert(err);
        navigate('/');
      }
    };
    fetchData().then(() => setLoading(false));
  }, [name]);

  useEffect(() => {
    validateFields();
  }, [coverageAmount, paymentTerm, optionType]);

  const handleSubmit = async () => {
    validateFields();
    const formErrors = {};

    // Validate family members
    if (scheme.schemeType === 'Family') {
      const familyErrors = familyMembers.some(member => !member.name || !member.adharId);
      if (familyErrors) {
        formErrors.familyMembersError = 'All family member fields are required.';
      }
      setCorporateMembers([]);
    }

    // Validate corporate members
    if (scheme.schemeType === 'Corporate') {
      const corporateErrors = corporateMembers.some(member => !member.name || !member.empId);
      if (corporateErrors) {
        formErrors.corporateMembersError = 'All corporate member fields are required.';
      }
      if (corporateMembers.length < 5) {
        formErrors.corporateMembersError = 'At least five corporate members are required.';
      }
      setFamilyMembers([])
    }

    setErrors(prevErrors => ({ ...prevErrors, ...formErrors }));

    if (Object.keys(formErrors).length === 0) {
      console.log('Form Data:', {
        schemeId: scheme.schemeId,
        coverageAmount,
        paymentTerm,
        paymentFreq,
        familyMembers,
        corporateMembers,
        optionType
      });
     
      try{
        setLoading(true);
        const data = await applyPolicy({schemeId: scheme.schemeId,
          coverageAmount,
          paymentTerm,
          paymentFreq,
          familyMembers,
          corporateMembers,
          optionType});
          alert(data.message);
          navigate('/');
      }catch(err){
         alert(err);
      }finally{
        setLoading(false)
      }
    }
  };

  const handleCoverageAmountChange = (event) => {
    const value = event.target.value;
    if (/^\d*\.?\d*$/.test(value)) {
      setCoverageAmount(value);
    } else {
      setCoverageAmount('');
    }
  };

  const handlePaymentTermChange = (event) => {
    const value = event.target.value;
    if (/^\d*$/.test(value)) {
      setPaymentTerm(value);
    } else {
      setPaymentTerm('');
    }
  };

  const handleOptionChange = (event) => {
    setOptionType(event.target.value);
    if (event.target.value === 'normal') {
      setCoverageAmount(scheme.coverageAmount || '');
      setPaymentTerm(scheme.paymentTerm || '');
    } else {
      setCoverageAmount('');
      setPaymentTerm('');
    }
  };

  const validateFields = () => {
    let valid = true;
    let coverageAmountError = '';
    let paymentTermError = '';

    if (optionType === 'quote') {
      if (coverageAmount && parseFloat(coverageAmount) < scheme.baseCoverageAmount) {
        coverageAmountError = `Quoted amount must be at least ${scheme.baseCoverageAmount}`;
        valid = false;
      }
      if (paymentTerm && parseInt(paymentTerm) >= scheme.paymentTerm) {
        paymentTermError = `Quoted payment term must be less than ${scheme.paymentTerm}`;
        valid = false;
      }
      if (coverageAmount && parseFloat(coverageAmount) > scheme.coverageAmount) {
        coverageAmountError = `Quoted Exceed Max Coverage Amount ${scheme.coverageAmount}, Check Other Plan`;
        valid = false;
      }
      if (paymentTerm && parseInt(paymentTerm) <= 0) {
        paymentTermError = `Enter a Valid Payment Term`;
        valid = false;
      }
    }

    setErrors({
      coverageAmountError,
      paymentTermError,
    });
  };

  const handleAddFamilyMember = () => {
    setFamilyMembers([...familyMembers, { name: '', adharId: '' }]);
  };

  const handleRemoveFamilyMember = (index) => {
    const updatedMembers = familyMembers.filter((_, i) => i !== index);
    setFamilyMembers(updatedMembers);
  };

  const handleFamilyMemberChange = (index, field, value) => {
    const updatedMembers = [...familyMembers];
    updatedMembers[index][field] = value;
    setFamilyMembers(updatedMembers);
  };

  const handleAddCorporateMember = () => {
    setCorporateMembers([...corporateMembers, { name: '', empId: '' }]);
  };

  const handleRemoveCorporateMember = (index) => {
    const updatedMembers = corporateMembers.filter((_, i) => i !== index);
    setCorporateMembers(updatedMembers);
  };

  const handleCorporateMemberChange = (index, field, value) => {
    const updatedMembers = [...corporateMembers];
    updatedMembers[index][field] = value;
    setCorporateMembers(updatedMembers);
  };

  if (loading) return <><h1>Loading....</h1></>;

  return (
    <div className="mx-auto font-mono bg-[#F5FEFD] p-6 font-mono min-h-full">
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
        <Typography variant='paragraph' className='font-mono my-3'>Policy Application Page</Typography>
      </div>

      <form>
        <div className="grid sm:grid-cols-2 gap-8">
          <div className='col-span-2'>
            <Input label='Scheme' disabled value={scheme.routeTitle} />
          </div>
          <div className='flex flex-col gap-8 col-span-2'>
            <div className='flex gap-4 '>
              <Radio
                label="Normal"
                checked={optionType === 'normal'}
                onChange={handleOptionChange}
                color='blue'
                value="normal"
              />
              <Radio
                label="Quote"
                value="quote"
                checked={optionType === 'quote'}
                onChange={handleOptionChange}
                color='red'
              />
            </div>
            {optionType && (
              <div className='grid sm:grid-cols-2 gap-8'>
                <div className='flex flex-col gap-3'>
                  {optionType === 'normal' && <Typography variant='small'>Coverage Amount</Typography>}
                  <Input
                    label={optionType === 'normal' ? "Coverage Amount" : "Enter your Quote Amount"}
                    type="text"
                    disabled={optionType === 'normal'}
                    value={coverageAmount}
                    onChange={handleCoverageAmountChange}
                    required
                  />
                  {errors.coverageAmountError && (
                    <Typography
                      variant="small"
                      color="gray"
                      className="mt-2 flex items-center gap-1 font-normal"
                    >
                      <svg
                        xmlns="http://www.w3.org/2000/svg"
                        viewBox="0 0 24 24"
                        fill="currentColor"
                        className="-mt-px h-4 w-4"
                      >
                        <path
                          fillRule="evenodd"
                          d="M2.25 12c0-5.385 4.365-9.75 9.75-9.75s9.75 4.365 9.75 9.75-4.365 9.75-9.75 9.75S2.25 17.385 2.25 12zm8.706-1.442c1.146-.573 2.437.463 2.126 1.706l-.709 2.836.042-.02a.75.75 0 01.67 1.34l-.04.022c-1.147.573-2.438-.463-2.127-1.706l.71-2.836-.042.02a.75.75 0 11-.671-1.34l.041-.022zM12 9a.75.75 0 100-1.5.75.75 0 000 1.5z"
                          clipRule="evenodd"
                        />
                      </svg>
                      {errors.coverageAmountError}
                    </Typography>
                  )}
                </div>
                <div className='flex flex-col gap-3'>
                  {optionType === 'normal' && <Typography variant='small'>Payment Term (Years)</Typography>}
                  <Input
                    type="text"
                    label={optionType === 'normal' ? "Payment Term" : "Enter your Payment Term"}
                    disabled={optionType === 'normal'}
                    value={paymentTerm}
                    onChange={handlePaymentTermChange}
                    required
                  />
                  {errors.paymentTermError && (
                    <Typography
                      variant="small"
                      color="gray"
                      className="mt-2 flex items-center gap-1 font-normal"
                    >
                      <svg
                        xmlns="http://www.w3.org/2000/svg"
                        viewBox="0 0 24 24"
                        fill="currentColor"
                        className="-mt-px h-4 w-4"
                      >
                        <path
                          fillRule="evenodd"
                          d="M2.25 12c0-5.385 4.365-9.75 9.75-9.75s9.75 4.365 9.75 9.75-4.365 9.75-9.75 9.75S2.25 17.385 2.25 12zm8.706-1.442c1.146-.573 2.437.463 2.126 1.706l-.709 2.836.042-.02a.75.75 0 01.67 1.34l-.04.022c-1.147.573-2.438-.463-2.127-1.706l.71-2.836-.042.02a.75.75 0 11-.671-1.34l.041-.022zM12 9a.75.75 0 100-1.5.75.75 0 000 1.5z"
                          clipRule="evenodd"
                        />
                      </svg>
                      {errors.paymentTermError}
                    </Typography>
                  )}
                </div>
                <div className='flex flex-col gap-3'>
                  <Select
                    label="Select Payment Frequency"
                    animate={{
                      mount: { y: 0 },
                      unmount: { y: 25 },
                    }}
                    onChange={(value) => setPaymentFreq(value)}
                    value={paymentFreq}
                  >
                    <Option value="Monthly">Monthly</Option>
                    <Option value="Quarterly">Quarterly</Option>
                    <Option value="Annually">Annually</Option>
                  </Select>
                </div>
              </div>
            )}
          </div>
        </div>

        {scheme.schemeType === 'Family' && (
          <div className="mt-4 ">
            <Button
              variant="outlined"
              onClick={handleAddFamilyMember}
              disabled={familyMembers.length >= 5}
            >
              Add Family Member
            </Button>
            <Typography variant='small' color="gray" className="mt-2 flex items-center gap-1 font-normal" >
              <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24" fill="currentColor" className="-mt-px h-4 w-4">
                <path fillRule="evenodd" d="M2.25 12c0-5.385 4.365-9.75 9.75-9.75s9.75 4.365 9.75 9.75-4.365 9.75-9.75 9.75S2.25 17.385 2.25 12zm8.706-1.442c1.146-.573 2.437.463 2.126 1.706l-.709 2.836.042-.02a.75.75 0 01.67 1.34l-.04.022c-1.147.573-2.438-.463-2.127-1.706l.71-2.836-.042.02a.75.75 0 11-.671-1.34l.041-.022zM12 9a.75.75 0 100-1.5.75.75 0 000 1.5z" clipRule="evenodd"/>
              </svg>
              At Least One Family Member Needed for this scheme  
            </Typography>
            {familyMembers.map((member, index) => (
              <div key={index} className="flex gap-4 mt-4 flex-col sm:flex-row bg-gray-100 p-5">
                <Input
                  label="Name"
                  value={member.name}
                  onChange={(e) => handleFamilyMemberChange(index, 'name', e.target.value)}
                  required
                />
                <Input
                  label="Adhar ID"
                  value={member.adharId}
                  onChange={(e) => handleFamilyMemberChange(index, 'adharId', e.target.value)}
                  required
                />
                <Button
                  variant="outlined"
                  onClick={() => handleRemoveFamilyMember(index)}
                  disabled={familyMembers.length <= 1}
                  size='md'
                >
                  Delete
                </Button>
              </div>
            ))}
            {errors.familyMembersError && (
              <Typography
                variant="small"
                color="gray"
                className="mt-2 flex items-center gap-1 font-normal"
              >
                <svg
                  xmlns="http://www.w3.org/2000/svg"
                  viewBox="0 0 24 24"
                  fill="currentColor"
                  className="-mt-px h-4 w-4"
                >
                  <path
                    fillRule="evenodd"
                    d="M2.25 12c0-5.385 4.365-9.75 9.75-9.75s9.75 4.365 9.75 9.75-4.365 9.75-9.75 9.75S2.25 17.385 2.25 12zm8.706-1.442c1.146-.573 2.437.463 2.126 1.706l-.709 2.836.042-.02a.75.75 0 01.67 1.34l-.04.022c-1.147.573-2.438-.463-2.127-1.706l.71-2.836-.042.02a.75.75 0 11-.671-1.34l.041-.022zM12 9a.75.75 0 100-1.5.75.75 0 000 1.5z"
                    clipRule="evenodd"
                  />
                </svg>
                {errors.familyMembersError}
              </Typography>
            )}
          </div>
        )}

        {scheme.schemeType === 'Corporate' && (
          <div className="mt-4 ">
            <Button
              variant="outlined"
              onClick={handleAddCorporateMember}
              disabled={corporateMembers.length >= 10}
            >
              Add Corporate Member
            </Button>
            {corporateMembers.map((member, index) => (
              <div key={index} className="flex gap-4 mt-4">
                <Input
                  label="Name"
                  value={member.name}
                  onChange={(e) => handleCorporateMemberChange(index, 'name', e.target.value)}
                  required
                />
                <Input
                  label="Emp ID"
                  value={member.empId}
                  onChange={(e) => handleCorporateMemberChange(index, 'empId', e.target.value)}
                  required
                />
                <Typography variant='small' color="gray" className="mt-2 flex items-center gap-1 font-normal" >
                  <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24" fill="currentColor" className="-mt-px h-4 w-4">
                    <path fillRule="evenodd" d="M2.25 12c0-5.385 4.365-9.75 9.75-9.75s9.75 4.365 9.75 9.75-4.365 9.75-9.75 9.75S2.25 17.385 2.25 12zm8.706-1.442c1.146-.573 2.437.463 2.126 1.706l-.709 2.836.042-.02a.75.75 0 01.67 1.34l-.04.022c-1.147.573-2.438-.463-2.127-1.706l.71-2.836-.042.02a.75.75 0 11-.671-1.34l.041-.022zM12 9a.75.75 0 100-1.5.75.75 0 000 1.5z" clipRule="evenodd"/>
                  </svg>
                  At Five Corporate Employee Needed
                </Typography>
                <Button
                  variant="outlined"
                  onClick={() => handleRemoveCorporateMember(index)}
                  disabled={corporateMembers.length <= 5}
                >
                  Delete
                </Button>
              </div>
            ))}
            {errors.corporateMembersError && (
              <Typography
                variant="small"
                color="gray"
                className="mt-2 flex items-center gap-1 font-normal"
              >
                <svg
                  xmlns="http://www.w3.org/2000/svg"
                  viewBox="0 0 24 24"
                  fill="currentColor"
                  className="-mt-px h-4 w-4"
                >
                  <path
                    fillRule="evenodd"
                    d="M2.25 12c0-5.385 4.365-9.75 9.75-9.75s9.75 4.365 9.75 9.75-4.365 9.75-9.75 9.75S2.25 17.385 2.25 12zm8.706-1.442c1.146-.573 2.437.463 2.126 1.706l-.709 2.836.042-.02a.75.75 0 01.67 1.34l-.04.022c-1.147.573-2.438-.463-2.127-1.706l.71-2.836-.042.02a.75.75 0 11-.671-1.34l.041-.022zM12 9a.75.75 0 100-1.5.75.75 0 000 1.5z" clipRule="evenodd"/>
                  </svg>
                  {errors.corporateMembersError}
                </Typography>
            )}
          </div>
        )}

        <div className="!mt-12">
          <Button onClick={handleSubmit} className="py-3.5 px-7 text-sm font-semibold tracking-wider rounded-md text-white bg-blue-600 hover:bg-blue-700 focus:outline-none">
            Apply 
          </Button>
        </div>
      </form>
    </div>
  );
};

export default ApplyPolicy_Page;
