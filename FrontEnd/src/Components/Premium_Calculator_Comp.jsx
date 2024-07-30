import React , {useState} from 'react'
import {
    Button,
    Typography,
    Input,
    Card,
    CardBody,
    CardFooter,
    Checkbox,
    Select,
    Radio,
   
  } from "@material-tailwind/react";
import { SchemeData } from '../DATA/Scheme_Data';

const Premium_Calculator_Comp = () => {
  const schemeData = SchemeData;
 
    const allSchemes = [
      ...schemeData.individual,
      ...schemeData.corporate,
      ...schemeData.family
    ];    
    const [selectedSchemeId, setSelectedSchemeId] = useState(allSchemes[0].schemeId);
    const [optionType, setOptionType] = useState(null);
    const [coverageAmount, setCoverageAmount] = useState('');
    const [paymentTerm, setPaymentTerm] = useState('');
  
    const selectedScheme = allSchemes.find(scheme => scheme.schemeId === selectedSchemeId);
  
    const handleSchemeChange = (event) => {
      setSelectedSchemeId(Number(event.target.value));
    };
  
    const handleOptionChange = (event) => {
      setOptionType(event.target.value);
      if (event.target.value === 'normal') {
      
        setCoverageAmount(selectedScheme?.coverageAmount || '');
        setPaymentTerm(selectedScheme?.paymentTerm || '');
      }
    };
  return (
   <>
   <Card>
      <Typography variant='h5' className='flex items-center justify-center mt-5 py-5 bg-[#FFF5EE]'>Premium Calculator </Typography>
      <CardBody className="flex flex-col gap-4">
        <div className='relative h-12 w-full' >
        <select className='peer h-full w-full rounded-[7px] border border-blue-gray-200 border-t-transparent bg-transparent px-3 py-2.5 font-sans text-sm font-normal text-blue-gray-700 outline outline-0 transition-all placeholder-shown:border placeholder-shown:border-blue-gray-200 placeholder-shown:border-t-blue-gray-200 empty:!bg-gray-900 focus:border-2 focus:border-gray-900 focus:border-t-transparent focus:outline-0 disabled:border-0 disabled:bg-blue-gray-50' 
        onChange={handleSchemeChange}
        value={selectedSchemeId}
        >
        {allSchemes.map((item) => (
          <option key={item.schemeId} value={item.schemeId} className="flex items-center gap-2 opacity-100 px-5 py-10 pointer-events-none">
            {item.routeTitle}
          </option>
        ))}
      </select>
      <label
    class="before:content[' '] after:content[' '] pointer-events-none absolute left-0 -top-1.5 flex h-full w-full select-none text-[11px] font-normal leading-tight text-blue-gray-400 transition-all before:pointer-events-none before:mt-[6.5px] before:mr-1 before:box-border before:block before:h-1.5 before:w-2.5 before:rounded-tl-md before:border-t before:border-l before:border-blue-gray-200 before:transition-all after:pointer-events-none after:mt-[6.5px] after:ml-1 after:box-border after:block after:h-1.5 after:w-2.5 after:flex-grow after:rounded-tr-md after:border-t after:border-r after:border-blue-gray-200 after:transition-all peer-placeholder-shown:text-sm peer-placeholder-shown:leading-[3.75] peer-placeholder-shown:text-blue-gray-500 peer-placeholder-shown:before:border-transparent peer-placeholder-shown:after:border-transparent peer-focus:text-[11px] peer-focus:leading-tight peer-focus:text-gray-900 peer-focus:before:border-t-2 peer-focus:before:border-l-2 peer-focus:before:border-gray-900 peer-focus:after:border-t-2 peer-focus:after:border-r-2 peer-focus:after:border-gray-900 peer-disabled:text-transparent peer-disabled:before:border-transparent peer-disabled:after:border-transparent peer-disabled:peer-placeholder-shown:text-blue-gray-500">
    Select Scheme
  </label>
        </div>
        <div className='flex gap-4'>
              <Radio label = "Normal"
                checked={optionType === 'normal'}
                onChange={handleOptionChange}
                color='blue'
                value="normal"
              />
              <Radio
                label = "Quote"
                value="quote"
                checked={optionType === 'quote'}
                onChange={handleOptionChange}
                color='red'
              />
          </div>
          {optionType && (
            <div className='flex flex-col gap-4'>
              <div className='flex flex-col gap-3'>
                { optionType == 'normal' && <Typography variant='small'>Coverage Amount</Typography>}
                <Input
                label={optionType == 'normal' ? "Coverage Amount" : "Enter your Quote Amount"}
                  type="text"
                  disabled={optionType === 'normal'}
                  value={optionType === 'normal' ? selectedScheme?.coverageAmount : coverageAmount}
                  onChange={(e) => setCoverageAmount(e.target.value)}
                />
              </div>
              <div className='flex flex-col gap-3'>
                {optionType=='normal' && <Typography variant='small'>Payment Term (Years)</Typography>}
                <Input
                  type="text"
                  disabled={optionType === 'normal'}
                  value={optionType === 'normal' ? selectedScheme?.paymentTerm : paymentTerm}
                  onChange={(e) => setPaymentTerm(e.target.value)}
                />
              </div>
            </div>
          )}
      </CardBody>
      <CardFooter className="pt-0">
        <Button variant="gradient" fullWidth>
          Sign In
        </Button>
        <Typography variant="small" className="mt-6 flex justify-center">
          Don&apos;t have an account?
          <Typography
            as="a"
            href="#signup"
            variant="small"
            color="blue-gray"
            className="ml-1 font-bold"
          >
            Sign up
          </Typography>
        </Typography>
      </CardFooter>
    </Card>
   </>
  )
}

export default Premium_Calculator_Comp