import React from 'react'
import {
    Button,
    Typography,
  } from "@material-tailwind/react";
import Premium_Calculator_Comp from '../Components/Premium_Calculator_Comp';
import KPICard_Component from '../Components/KPICard_Component';
import Hero_Section_Image from '../Assets/Hero_Section_Image.png';
import Hero_Section_Image_2 from '../Assets/Hero_Section_Image_2.png';
const Kpi_data = [
  {
    title: "Total Claim",
    price: "Rs.50,846.90",
    icon : <svg xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" strokeWidth={1.5} stroke="currentColor" className="size-6">
    <path strokeLinecap="round" strokeLinejoin="round" d="M2.25 18 9 11.25l4.306 4.306a11.95 11.95 0 0 1 5.814-5.518l2.74-1.22m0 0-5.94-2.281m5.94 2.28-2.28 5.941" />
  </svg>
   
  },
  {
    title: "Affiliated Hospitals Total",
    percentage: "16%",
    price: "10,342",
    icon : <svg xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" strokeWidth={1.5} stroke="currentColor" className="size-6">
    <path strokeLinecap="round" strokeLinejoin="round" d="M9 12.75 11.25 15 15 9.75m-3-7.036A11.959 11.959 0 0 1 3.598 6 11.99 11.99 0 0 0 3 9.749c0 5.592 3.824 10.29 9 11.623 5.176-1.332 9-6.03 9-11.622 0-1.31-.21-2.571-.598-3.751h-.152c-3.196 0-6.1-1.248-8.25-3.285Z" />
  </svg>
  
   
  },
  {
    title: "Rating",
    price: "4.3/5",
    icon :<svg xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" strokeWidth={1.5} stroke="currentColor" className="size-6">
    <path strokeLinecap="round" strokeLinejoin="round" d="M11.48 3.499a.562.562 0 0 1 1.04 0l2.125 5.111a.563.563 0 0 0 .475.345l5.518.442c.499.04.701.663.321.988l-4.204 3.602a.563.563 0 0 0-.182.557l1.285 5.385a.562.562 0 0 1-.84.61l-4.725-2.885a.562.562 0 0 0-.586 0L6.982 20.54a.562.562 0 0 1-.84-.61l1.285-5.386a.562.562 0 0 0-.182-.557l-4.204-3.602a.562.562 0 0 1 .321-.988l5.518-.442a.563.563 0 0 0 .475-.345L11.48 3.5Z" />
  </svg>
  
  },
  {
    title: "Policies in Our Collection",
    price: "20,000",
    icon :<svg xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" strokeWidth={1.5} stroke="currentColor" className="size-6">
    <path strokeLinecap="round" strokeLinejoin="round" d="M19.5 14.25v-2.625a3.375 3.375 0 0 0-3.375-3.375h-1.5A1.125 1.125 0 0 1 13.5 7.125v-1.5a3.375 3.375 0 0 0-3.375-3.375H8.25M9 16.5v.75m3-3v3M15 12v5.25m-4.5-15H5.625c-.621 0-1.125.504-1.125 1.125v17.25c0 .621.504 1.125 1.125 1.125h12.75c.621 0 1.125-.504 1.125-1.125V11.25a9 9 0 0 0-9-9Z" />
  </svg>
  
  },
];

const Home_Page = () => {
  return (
    <>
  <section class="text-gray-600 body-font bg-[#F5F5F5] font-mono">
  <div class="container mx-auto flex md:px-11 px-2 py-24 md:flex-row flex-col items-center">
  <div class="lg:flex-grow md:w-1/2 lg:pr-24 md:pr-16 flex flex-col md:items-start md:text-left mb-5 md:mb-0 items-center text-center">
      <h1 class="title-font sm:text-4xl text-3xl mb-4 font-medium text-gray-900">CARE HEALTH INSURANCE
        <br class="hidden lg:inline-block"/> <span className='text-blue-800'>#The Worlds Best</span>
      </h1>
      <p class="mb-8 leading-relaxed">Health Insurance has become an inevitable part of securing your health and financial well-being. We ensure your secured future with an array of our Health Insurance Policies.Care Health Insurance offers several benefits to the insured, including quality medical check-ups, coverage for treatment expenses, cashless hospitalisation, and more.</p>
      <div class="flex justify-center">
        <Button variant='outlined' className='flex items-center'>GET A Call From Agent <svg xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" strokeWidth={1.5} stroke="currentColor" className="size-6 ml-2">
  <path strokeLinecap="round" strokeLinejoin="round" d="M17.25 8.25 21 12m0 0-3.75 3.75M21 12H3" />
</svg></Button>
      </div>
    </div>

    <div class="lg:w-1/3 md:w-1/2 w-5/6 ">
    <img src={Hero_Section_Image_2} className='bg-inherit'/>
    </div>
    
  </div>
</section>
    {/* Need to Show Status - total Claim Account , no of hosiptal tie up,Rating , total amount claimed for an year */}
      <header className="bg-[#F5FEFD] p-2">
        <div className="grid min-h-[82vh] w-full lg:h-[30rem] md:h-[34rem] place-items-stretch">
          <div className="container mx-auto px-4 text-center">
          <div className="mt-6 grid lg:grid-cols-4 md:grid-cols-2 grid-cols-1 items-center md:gap-2.5 gap-4">
        {Kpi_data.map((props, key) => (
          <KPICard_Component key={key} {...(props)} />
        ))}
      </div>
            <Typography
              variant="h1"
              color="blue-gray"
              className="mx-auto my-6 w-full leading-snug  !text-2xl lg:max-w-3xl lg:!text-5xl"
            >
              Unlock a new standard of {" "}
              <span className="text-green-500 leading-snug ">
              health coverage
              </span>{" "}
              and{" "}
              <span className="leading-snug text-green-500">
              convenience
              </span>
              .
            </Typography>
            <Typography
              variant="lead"
              className="mx-auto w-full text-teal-400 lg:text-lg text-base"
            >
            We provide the best health insurance policies in India that help individuals with timely support during the complete phase of claim settlement and offer expedient guidance to individuals and families.
            </Typography>
          </div>
        </div>
      </header>
    </>
  )
}

export default Home_Page