import React, { useState, useEffect } from 'react';
import {
  Button,
  Typography,
  Input,
  Card,
  CardBody,
  CardFooter,
  Radio,
  Select,
  Option,
} from "@material-tailwind/react";
import { calulatePremium } from '../Context/ScehmesManager';

const Premium_Calculator_Comp = ({ data }) => {
  const [optionType, setOptionType] = useState(null);
  const [coverageAmount, setCoverageAmount] = useState('');
  const [paymentTerm, setPaymentTerm] = useState('');
  const [paymentFreq, setPaymentFreq] = useState("Monthly");
  const [resData, setResData] = useState(null)
  const [loading, setloading] = useState(false)
  const [errors, setErrors] = useState({
    coverageAmountError: '',
    paymentTermError: '',
  });
  const [isSubmitEnabled, setIsSubmitEnabled] = useState(false);

  const handleOptionChange = (event) => {
    setOptionType(event.target.value);
    if (event.target.value === 'normal') {
      setCoverageAmount(data.coverageAmount || '');
      setPaymentTerm(data.paymentTerm || '');
    } else {
      setCoverageAmount('');
      setPaymentTerm('');
      setResData(null)
    }
  };

  const handleCoverageAmountChange = (event) => {
    const value = event.target.value;
    // Allow empty input or valid floating point numbers
    if (/^\d*\.?\d*$/.test(value)) {
      setCoverageAmount(value)
    } else {
      setCoverageAmount('');
    }
  };

  const handlePaymentTermChange = (event) => {
    const value = event.target.value;
    // Allow empty input or valid integers
    if (/^\d*$/.test(value)) {
      setPaymentTerm(value);
    } else {
      setPaymentTerm('');
    }
  };

  const validateFields = () => {
    let valid = true;
    let coverageAmountError = '';
    let paymentTermError = '';

    if (optionType === 'quote') {
      if (coverageAmount && parseFloat(coverageAmount) < data.baseCoverageAmount) {
        coverageAmountError = `Quoted amount must be at least ${data.baseCoverageAmount}`;
        valid = false;
      }
      if (paymentTerm && parseInt(paymentTerm) >= data.paymentTerm) {
        paymentTermError = `Quoted payment term must be less than ${data.paymentTerm}`;
        valid = false;
      }
      if (coverageAmount && parseFloat(coverageAmount) > data.coverageAmount) {
        coverageAmountError = `Quoted Exceed Max Coverage Amount ${data.coverageAmount}, Check Other Plan`;
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

    setIsSubmitEnabled(valid);
  };

  useEffect(() => {
    validateFields();
  }, [coverageAmount, paymentTerm, optionType]);

  const handleSubmit = async () => {
    if (isSubmitEnabled) {
      try {
        setloading(true)
        const res = await calulatePremium(data.schemeId, optionType, paymentFreq, paymentTerm, parseFloat(coverageAmount));
        console.log(res);
        setResData(res)
      } catch (ex) {
        alert(ex);
      }finally{
        setloading(false)
      }
    }
  };

  return (
    <>
      <Card>
        <Typography variant='h5' className='flex items-center justify-center mt-5 py-5 bg-[#FFF5EE]'>Premium Calculator</Typography>
        <CardBody className="flex flex-col gap-4">
          <div className='relative h-12 w-full'>
            <Input label='Scheme' value={data.routeTitle} disabled />
          </div>
          <div className='flex gap-4'>
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
            <div className='flex flex-col gap-4'>
              <div className='flex flex-col gap-3'>
                {optionType === 'normal' && <Typography variant='small'>Coverage Amount</Typography>}
                <Input
                  label={optionType === 'normal' ? "Coverage Amount" : "Enter your Quote Amount"}
                  type="text"
                  disabled={optionType === 'normal'}
                  value={coverageAmount}
                  onChange={handleCoverageAmountChange}
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
        </CardBody>
        <CardFooter className="pt-0">
          <Button onClick={handleSubmit} variant="gradient" fullWidth disabled={!isSubmitEnabled} loading={loading}>
            Calculate Premium
          </Button>
          
            {
              resData && (
                <>
                 <Typography variant="small" className="flex my-3 font-mono">
                  Premium for {resData.paymentFrequency} = Rs {resData.premium}
                 </Typography>
                <Typography variant="small" className="flex my-3 font-mono text-cyan-800">
                 Coverage Term (in years) for Payment Term of {resData.paymentTerm
                 } (in years) excluding Payment Term = {resData.calCoverageYears} Years
                 </Typography>
                </>
               
              )
            }
        </CardFooter>
      </Card>
    </>
  );
};

export default Premium_Calculator_Comp;
