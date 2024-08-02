import React from 'react'
import {decryptToken, getCookie, useAuth} from '../Context/AuthAndStateManager';

const PolicyManager = () => {
  
}
const url = import.meta.env.VITE_BACKEND_URL;
export const applyPolicy = async (formData) => {
    const token = decryptToken(getCookie('token'));
 const bodyData = {
    schemeId : formData.schemeId,
    coverageAmount : parseFloat( formData.coverageAmount),
    paymentTerm: parseInt( formData.paymentTerm),
    familyMembers : formData.familyMembers,
    corporateMembers : formData.corporateMembers,
    paymentFrequency : formData.paymentFreq,
    opt : formData.optionType
}
console.log(bodyData);
const res = await fetch(`${url}/api/Policy/apply`,{
    method : "POST",
    headers : {
        "Content-Type": "application/json",
         "Authorization" : `Bearer ${token}`
    },
    body : JSON.stringify(bodyData)
})
const data = await res.json();
if(!res.ok){
    console.log(data);
    if(data.code == 401){
        throw new Error("Your Are Authorized , to perform the operation")
    }
    if(data.code == 409){
        throw new Error(data.message)
    }
    throw new Error("Something Went Wrong , Please Try Again after some time");
}
return data;
}
export const FetchPolicies =async ()=>{
    const token = decryptToken(getCookie('token'));
    const res = await fetch(`${url}/api/Policy/getAll`,{
        method : "GET",
        headers : {
            "Content-Type": "application/json",
             "Authorization" : `Bearer ${token}`
        },
    });
    const data = await res.json();
    console.log(data);
    if(!res.ok){
        throw new Error("Something Went Wrong , Please Try Again after some time");
    }
    return data;
}
export const ApplyClaim = async (bodyData)=>{
    const token = decryptToken(getCookie('token'));
    const res = await fetch(`${url}/api/Policy/add-claim`,{
        method : "POST",
        headers : {
            "Content-Type": "application/json",
             "Authorization" : `Bearer ${token}`
        },
        body : JSON.stringify(bodyData)
    });
    const data = await res.json()
    if(!res.ok){
        throw new Error("Something Went Wrong , Please Try Again after some time");
    }
    return data;
}

export const GetPayments = async ()=>{
    const token = decryptToken(getCookie('token'));
    const res = await fetch(`${url}/api/Policy/get-payments`,{
        method : "GET",
        headers : {
            "Content-Type": "application/json",
             "Authorization" : `Bearer ${token}`
        },
    });
    const data = await res.json()
    if(!res.ok){
        throw new Error("Something Went Wrong , Please Try Again after some time");
    }
    return data;
}
export const PremiumPayment = async (id)=>{
    const token = decryptToken(getCookie('token'));
    const res = await fetch(`${url}/api/Policy/premium-pay?paymentId=${id}`,{
        method : "PUT",
        headers : {
            "Content-Type": "application/json",
             "Authorization" : `Bearer ${token}`
        },
    });
    const data = await res.json()
    if(!res.ok){
        throw new Error("Something Went Wrong , Please Try Again after some time");
    }
    return data;
}
export const ApplyRenewal = async (id)=>{
    const token = decryptToken(getCookie('token'));
    const res = await fetch(`${url}/api/Policy/apply-renewal?policyId=${id}`,{
        method : "PUT",
        headers : {
            "Content-Type": "application/json",
             "Authorization" : `Bearer ${token}`
        },
    });
    const data = await res.json()
    if(!res.ok){
        console.log(data);
        throw new Error("Something Went Wrong , Please Try Again after some time");
    }
    return data;

}

export const fetchNotifications = async()=>{
    const token = decryptToken(getCookie('token'));
    const res = await fetch(`${url}/api/User/notify`,{
        method : "GET",
        headers : {
            "Content-Type": "application/json",
             "Authorization" : `Bearer ${token}`
        },
    });
    const data = await res.json()
    if(!res.ok){
        console.log(data);
        throw new Error("Something Went Wrong , While Fetching Notificaions");
    }
    return data;
}
export default PolicyManager