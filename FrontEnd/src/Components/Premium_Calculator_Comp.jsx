import React from 'react'
import {
    Button,
    Typography,
    Input,
    Card,
    CardHeader,
    CardBody,
    CardFooter,
    Checkbox,
   
  } from "@material-tailwind/react";

const Premium_Calculator_Comp = () => {
  return (
   <>
   <Card className="">
      <Typography variant='h5' className='flex items-center justify-center mt-5 py-5 bg-[#FFF5EE]'>Premium Calculator</Typography>
      <CardBody className="flex flex-col gap-4">
        <Input label="Email" size="lg" />
        <Input label="Password" size="lg" />
        <div className="-ml-2.5">
          <Checkbox label="Remember Me" />
        </div>
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