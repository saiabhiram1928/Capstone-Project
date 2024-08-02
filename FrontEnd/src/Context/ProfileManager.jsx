import React from 'react'
import { decryptToken, getCookie } from './AuthAndStateManager'

const ProfileManager = () => {
    
}
const url = import.meta.env.VITE_BACKEND_URL;
export const FetchUserProfile = async ()=>{
const token = decryptToken(getCookie("token"))
const res = await fetch(`${url}/api/User/profile`,{
    method : "GET",
    headers : {
        "Content-Type": "application/json",
         "Authorization" : `Bearer ${token}`
    },

})
const data = await res.json();
if(!res.ok){
    if(data.code == 401 || data.code == 404){
        throw new Error(data.message)
    }
    throw new Error("Something Went Wrong , Please Try Again After Some Time");
}
const formatDate = (dateString) => {
    const date = new Date(dateString);
    return date.toISOString().split('T')[0];
  };

return {
    ...data,
    dateOfBirth: formatDate(data.dateOfBirth),
    createdAt: formatDate(data.createdAt),
    lastUpdatedAt: formatDate(data.lastUpdatedAt),
};
}
export const UpdateProfile = async (formData) => {
    const token = decryptToken(getCookie("token"));
  
    const formatDateTime = (dateString) => {
      const date = new Date(dateString);
      return date.toISOString(); // ISO 8601 format
    };
  
    const updatedFormData = {
      ...formData,
      dateOfBirth: formatDateTime(formData.dateOfBirth), 
      createdAt: formatDateTime(formData.createdAt), 
      lastUpdatedAt: formatDateTime(formData.lastUpdatedAt),
    };
  
    const res = await fetch(`${url}/api/User/update`, {
      method: "POST", // Use POST for updating data
      headers: {
        "Content-Type": "application/json",
        "Authorization": `Bearer ${token}`,
      },
      body: JSON.stringify(updatedFormData),
    });
  
    const data = await res.json();
    if (!res.ok) {
      if (data.code === 401 || data.code === 404) {
        throw new Error(data.message);
      }
      throw new Error("Something went wrong. Please try again later.");
    }
    return data;
  };
  


export default ProfileManager