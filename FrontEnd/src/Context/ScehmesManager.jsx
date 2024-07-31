import React from 'react'
import { Navigate } from 'react-router-dom'


const ScehmesManager = () => {
      
}
export default ScehmesManager
const url = import.meta.env.VITE_BACKEND_URL 


export const fetchSchemeByRoute = async (route) =>{
  const payload = "getByRT"
    const res = await fetch(`${url}/api/Schemes/get?payload=${encodeURIComponent(payload)}&route=${encodeURIComponent(route)}`,{
      method: "GET"
    })
    const data = await res.json();
    if(!res.ok){
      console.log(data);
      if(data.code == 404){
      <Navigate to="404-NotFound"/>
      throw new Error('This Scheme your are trying to get doent present');
      }else if(data.code == 500){
        throw new Error('The Server is down , Please Try again after some time');
      }else{
        throw new Error('Something Went Wrong While Fetching the Scheme, Please Try again after some time');
      }
    }
    return data;
}


export const calulatePremium = async (schemeId, payload, paymentFrequency ,quotedPaymentTerm,quotedCoverageAmount ) => {
  const bodyData = {
    schemeId ,
    paymentFrequency,
    quotedCoverageAmount,
    quotedPaymentTerm
  }
  console.log(bodyData , typeof bodyData.quotedCoverageAmount , payload);
  const res = await fetch(`${url}/api/Schemes/CalPremium?payload=${payload}`, {
    method : "POST",
    headers: {
      "Content-Type": "application/json",
    },
    body : JSON.stringify(bodyData)
  });
  const data = await res.json()
  if(!res.ok){
    console.log(data ,res);
    if(data.code == 404){
      throw new Error('This Scheme your are trying to get doent present');
    }else{
      throw new Error("Something went wrong wile calculating Premium")
    }
  }
  return data
}


