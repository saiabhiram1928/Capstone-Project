import { Button, typography, Typography } from '@material-tailwind/react'
import React, { useEffect , useState } from 'react'
import Premium_Calculator_Comp from '../Components/Premium_Calculator_Comp'
import { Navigate, useNavigate, useParams } from 'react-router-dom'
import { SchemeData } from '../DATA/Scheme_Data'
import { fetchSchemeByRoute } from '../Context/ScehmesManager'
import { useAuth } from '../Context/AuthAndStateManager'
import Loader_Component from '../Components/Loader_Component'

const Scheme_Page = () => {
  const { name } = useParams(); 
  const [scheme, setScheme] = useState({})
  const [loading, setLoading] = useState(true)
  const navigate = useNavigate()
  const trimDescription = (description, wordLimit) => {
    const words = description.split(' ');
    if (words.length <= wordLimit) return description;

    return words.slice(0, wordLimit).join(' ') + '...';
  }
  useEffect(()=>{
    const fetchData = async () => {
      try {
        const data = await fetchSchemeByRoute(name);
        setScheme(data);
      } catch (err) {
        alert(err)
        navigate('/')
      }
    };
    fetchData().then(()=> setLoading(false))
    window.scrollTo(0, 0);
  },[name])

   if(loading) return <><h1>Loading....</h1></>
  return (
    <>
    <section class="text-gray-600 body-font bg-[#F5F5F5] font-mono">
     <div class="container mx-auto flex md:px-11 px-2 py-20 md:flex-row flex-col items-center">
  {/* <!-- Premium Calculator Component (shown first on smaller screens) --> */}
  <div class="lg:w-1/3 md:w-1/2 w-5/6 order-1 md:order-2 mb-10 md:mb-0">
    <Premium_Calculator_Comp data={scheme} />
  </div>
  
  {/* <!-- Description Section (shown after Premium Calculator on smaller screens) --> */}
  <div class="lg:flex-grow md:w-1/2 lg:pr-24 md:pr-10 flex flex-col md:items-start md:text-left mb-2 md:mb-0 items-center text-center order-2 md:order-1">
    <h1 class="title-font sm:text-4xl text-3xl mb-4 font-medium text-gray-900">
      {scheme.schemeName}
    </h1>
    <p class="mb-8 leading-relaxed">{trimDescription(scheme.schemeDescription, 20)}</p>
    <div class="flex justify-center">
      <Button className='flex items-center bg-blue-500'>Apply Now</Button>
    </div>
  </div>
</div>
</section>
<section className='bg-white my-10 py-10 px-5 '>
  <div className='font-mono'>
      <Typography variant='h4' className=' my-5'>About the Scheme ?</Typography>
      <p className='leading-loose text-base font-mono'>{scheme.schemeDescription}</p>
  </div>
  <div className='mt-5 font-mono'>
    <Typography variant='h4' className='my-5'>Scheme Details</Typography>
    <table className='border-collapse border border-slate-400 w-full text-sm md:text-lg'>
      <thead >
        <tr>
          <th className='border-2 border-black text-start p-3'>Key Fetaures</th>
          <th className='border-2 border-black p-3 '>Values</th>
        </tr>
      </thead>
      <tbody>
        <tr >
        <td class="border-2 border-black text-start p-3">Coverage Amount</td>
        <td class="border-2 border-black text-center p-3 ">Rs.{scheme.coverageAmount/100000} Lakhs</td>
        </tr>
         <tr>
         <td class="border-2 border-black text-start  p-3">Base Coverage Amount</td>
         <td class="border-2 border-black text-center p-3">Rs.{scheme.baseCoverageAmount/100000} Lakhs</td>
         </tr>
         <tr>
         <td class="border-2 border-black text-start  p-3">Base Premium Amount</td>
         <td class="border-2 border-black text-center p-3">Rs.{scheme.basePremiumAmount}</td>
         </tr>
         
         <tr>
         <td class="border-2 border-black text-start  p-3">Payment Term(in Years)</td>
         <td class="border-2 border-black text-center p-3">{scheme.paymentTerm}</td>
         </tr>
         <tr>
         <td class="border-2 border-black text-start  p-3">Coverage Years(in Years)</td>
         <td class="border-2 border-black text-center p-3">{scheme.coverageYears}</td>
         </tr>
      </tbody>
      
    </table>
  </div>
</section>
    </>
  )
}

export default Scheme_Page