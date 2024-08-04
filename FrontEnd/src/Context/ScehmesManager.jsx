import React from 'react'
import { Navigate } from 'react-router-dom'
import { decryptToken, getCookie } from './AuthAndStateManager'


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
export const GetAllSchemesForAdmin = async()=>{
  const token = decryptToken(getCookie('token'));
  const res = await fetch(`${url}/api/Schemes/getAll`,{
      method : "GET",
      headers : {
          "Content-Type": "application/json",
           "Authorization" : `Bearer ${token}`
      },
  }); 
  const data = await res.json();
  if(!res.ok){
    throw new Error(data.message)
  }
  return data;
}

export const UpdateScheme = async (formData, id)=>{
  const bodyData = {
    schemeName : formData.schemeName,
    schemeDescription : formData.schemeDescription,
    coverageAmount :formData.coverageAmount,
    basePremiumAmount : formData.basePremiumAmount,
    schemeType : formData.schemeType,
    routeTitle : formData.routeTitle,
    smallDescription : formData.smallDescription,
    paymentTerm : formData.paymentTerm,
    coverageYears : formData.coverageYears,
    baseCoverageAmount : formData.baseCoverageAmount,
  }
  const token = decryptToken(getCookie('token'));
  const res = await fetch(`${url}/api/Schemes/update?schemeId=${id}`,{
      method : "PUT",
      headers : {
          "Content-Type": "application/json",
           "Authorization" : `Bearer ${token}`
      },
      body : JSON.stringify(bodyData)
  }); 
  const data = await res.json()
  if(!res.ok){
    throw new Error(data.message)
  }
  return data;
}

export const CreateScheme = async(formData)=>{
  const token = decryptToken(getCookie('token'));
  const res = await fetch(`${url}/api/Schemes/add`,{
      method : "POST",
      headers : {
          "Content-Type": "application/json",
           "Authorization" : `Bearer ${token}`
      },
      body : JSON.stringify(formData)
    })
const data = await res.json();
if(!res.ok){
  throw new Error(data.message)
}
return data;

}
export const ChangeSchemeStatus = async(paylod,route) =>{
  const token = decryptToken(getCookie('token'));
  const res = await fetch(`${url}/api/Schemes/activity?payload=${paylod}&route=${route}`,{
      method : "POST",
      headers : {
          "Content-Type": "application/json",
           "Authorization" : `Bearer ${token}`
      },
    })
    const data =await res.json();
    if(!res.ok){
      throw new Error(data.message)
    }
    return data;
}
