import { Typography } from '@material-tailwind/react'
import React from 'react'
import Pricing_Card_Component from '../Components/Pricing_Card_Component'

const Schemes_Page = ({data}) => {
  // console.log(title , question, answer,blockdata);
  return (
    <div>
      <section class="text-gray-600 font-mono">
  <div class="container px-5 py-10 mx-auto ">
    <div class="flex flex-col text-center w-full mb-20">
      <h2 class="text-md text-indigo-500 tracking-widest font-medium title-font mb-1">
       {data.title}</h2>
      <h1 class="sm:text-3xl text-2xl font-medium title-font mb-4 text-gray-900">{data.question} </h1>
      <p class="lg:w-2/3 mx-auto leading-relaxed text-base"> {data.answer} </p>
    </div>
    <Typography variant='h3' className='font-mono mt-2 text-center px-5 mb-5'>Who need to Take it ?</Typography>
    <div class="flex flex-wrap md:justify-between">
      {
       data.blockdata.map((item)=>{
          return (
<div class="md:w-1/3 w-full mx-auto px-4 py-6 border-l-2 border-gray-200 border-opacity-60">
        <h2 class="text-lg text-blue-900 font-medium title-font mb-2 w-full"><span></span>{item.title}</h2>
        <p class="leading-relaxed text-base mb-4">{item.description}</p>
      </div>
          )
        })
      }
    </div>
  </div>
</section>
<section className="py-24 px-8 bg-[#EFF0F4]">
      <div className="container mx-auto">
        <Typography
          color="blue-gray"
          className="mb-4 font-bold text-lg"
        >
          Pricing Plans
        </Typography>
        <Typography
          variant="h1"
          color="blue-gray"
          className="mb-4 !leading-snug lg:!text-4xl !text-2xl max-w-2xl"
        >
          Invest in a plan that&apos;s as ambitious as your corporate goals.
        </Typography>
        <Typography
          variant="lead"
          className="mb-10 font-normal !text-gray-500 max-w-xl"
        >
          Compare the benefits and features of each plan below to find the ideal
          match for your business&apos;s budget and ambitions.
        </Typography>
        <div className="grid gap-y-8 md:grid-cols-1 lg:grid-cols-2 items-center justify-center">

          <Pricing_Card_Component/>
          <Pricing_Card_Component/>
          <Pricing_Card_Component/>
          <Pricing_Card_Component/>
        </div>
      </div>
    </section>
    </div>
  )
}

export default Schemes_Page