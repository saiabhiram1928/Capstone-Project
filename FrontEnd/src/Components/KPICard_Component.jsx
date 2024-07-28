import React from 'react'
import {
    Typography,
    Card,
    CardBody,
  } from "@material-tailwind/react";
const KPICard_Component = ({title,
    price,
    icon
   }) => {
  return (
    <Card className="shadow-sm border border-gray-200 !rounded-lg">
    <CardBody className="p-4 font-mono">
      <div className="flex justify-between items-center">
        <Typography
          className="!text-sm text-red-600 font-mono"
        >
          {title}
        </Typography>
        <div className="flex items-center gap-1 text-cyan-400">
            {icon}
        </div>
      </div>
      <Typography
        className="mt-1 font-extrabold text-2xl text-blue-700"
      >
        {price}
      </Typography>
    </CardBody>
  </Card>
  )
}

export default KPICard_Component