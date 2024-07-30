import React from 'react'
import {
    Card,
    CardBody,
    CardFooter,
    Typography,
    Button,
  } from "@material-tailwind/react";
import { Link } from 'react-router-dom';

const Pricing_Card_Component = () => {
  return (
//     <Card className="mt-6 w-96 bg-[#F5F5F5] shadow-2xl hover:shadow-[#FFF8DC]">
//     <CardBody>
//       <Typography variant="h5" color="blue-gray" className="mb-2">
//         UI/UX Review Check
//       </Typography>
//       <Typography>
//         The place is close to Barceloneta Beach and bus stop just 2 min by
//         walk and near to &quot;Naviglio&quot; where you can enjoy the main
//         night life in Barcelona.
//       </Typography>
//     </CardBody>
//     <CardFooter className="pt-0">
//       <Button>Read More</Button>
//     </CardFooter>
//   </Card>
<div className='container flex justify-center items-center relative flex-wrap'>
    <div className='water-drop'>
        <div className='water-content'>
            <h5 className='title font-mono lg:text-xl text-lg font-extrabold'>Lorem ipsum dolor sit amet consectetur adipisicing elit. Vitae, commodi! </h5>
            <p className='description text-sm text-gray-700 font-mono'>Lorem ipsum dolor sit amet consectetur, adipisicing elit. Officiis, et aliquid. Nesciunt beatae sapiente similique incidunt perferendis pariatur, laborum officiis sunt asperiores praesentium autem dicta ipsam maxime at unde nostrum rem consequatur repudiandae debitis. Officiis magni laboriosam unde at atque libero, ipsa beatae voluptas veniam exercitationem quasi voluptatum, aliquid sint?</p>
            <button className='read-more'>Know More</button>
        </div>
    </div>

</div>
  )
}

export default Pricing_Card_Component