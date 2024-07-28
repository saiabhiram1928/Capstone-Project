import { Button, Typography } from '@material-tailwind/react'
import React from 'react'
import Premium_Calculator_Comp from '../Components/Premium_Calculator_Comp'
import { Navigate, useParams } from 'react-router-dom'
import { SchemeData } from '../DATA/Scheme_Data'

const Scheme_Page = () => {
  const { name } = useParams();
  
  const findScheme = (data) => {
    for (const key in data) {
      const scheme = data[key].find(scheme => scheme.routeTitle === name);
      if (scheme) return scheme;
    }
    return null;
  }
  const trimDescription = (description, wordLimit) => {
    const words = description.split(' ');
    if (words.length <= wordLimit) return description;

    return words.slice(0, wordLimit).join(' ') + '...';
  }
  const scheme = findScheme(SchemeData);
  if(!scheme) <Navigate to = "/404-NotFound" />
  return (
    <>
     <section class="text-gray-600 body-font bg-[#F5F5F5] font-mono">
  <div class="container mx-auto flex md:px-11 px-2 py-24 md:flex-row flex-col items-center">
  <div class="lg:flex-grow md:w-1/2 lg:pr-24 md:pr-16 flex flex-col md:items-start md:text-left mb-5 md:mb-0 items-center text-center">
      <h1 class="title-font sm:text-4xl text-3xl mb-4 font-medium text-gray-900">{scheme.schemeName}
      </h1>
      <p class="mb-8 leading-relaxed">{trimDescription(scheme.schemeDescription, 20)}</p>
      <div class="flex justify-center">
        <Button className='flex items-center bg-blue-500'> Apply Now</Button>
      </div>
    </div>

    <div class="lg:w-1/3 md:w-1/2 w-5/6 ">
    <Premium_Calculator_Comp/>
    </div>
    
  </div>
</section>
<section className='bg-white my-10 py-10'>
  <div className='px-5 font-mono'>
      <Typography variant='h4' className=' my-5'>About the Scheme ?</Typography>
      <p className='leading-loose text-base font-mono'>{scheme.schemeDescription}</p>
  </div>
</section>
    </>
  )
}

export default Scheme_Page