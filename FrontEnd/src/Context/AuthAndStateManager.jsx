import React, { createContext, useContext, useEffect, useState } from 'react'
import Loader_Component from '../Components/Loader_Component'
import CryptoJS from 'crypto-js';

const AuthContext = createContext()

const useAuth = () => {
    return useContext(AuthContext)
  }

  const url = import.meta.env.VITE_BACKEND_URL;
  const secretKey = import.meta.env.VITE_SECRET_KEY
  const AuthProvider = ({ children }) => {
    const user = getCookie('token') ? true : false;
    const role = getCookie('role') && user ? decryptToken(getCookie('role')) : "";
    const [loading, setLoading] = useState(true)

    const fetchRouteTitle = async ()=>{
      try{
          const paylod = "routes"
          const res = await fetch(`${url}/api/Schemes/get?payload=${encodeURIComponent(paylod)}`,{
              method : "GET"
          });
          const data =await res.json();
          if(!res.ok){
            
            throw new Error("Something Went Wrong While Fetching Routes");
          }
          const segData ={
              individual: [],
              corporate: [],
              family: []
          } 
          data.forEach(item => {
              switch (item.schemeType) {
                case 'Individual':
                  segData.individual.push(item);
                  break;
                case 'Corporate':
                  segData.corporate.push(item);
                  break;
                case 'Family':
                  segData.family.push(item);
                  break;
                default:
                  console.warn(`Unknown SchemeType: ${item.schemeType}`);
              }
            });
            sessionStorage.setItem('schemesRoute'  , JSON.stringify( segData) );
      }catch(err){
          console.log(err);
      }
     
      
  }

  const handlerUserRegister = async (arugs)=>{
    const bodyData = {
      firstName : arugs.firstName,
      address : arugs.address,
      zipcode : arugs.pincode,
      lastName : arugs.lastName,
      mobileNumber : arugs.phoneNumber,
      password : arugs.password,
      gender : arugs.gender,
      dateOfBirth :arugs.dob.toISOString,
      email : arugs.email,
      agentContact : "",
      emergenceyContact:arugs.phoneNumber,
      hosiptalId : 0
    }
    const res = await fetch(`${url}/api/UserAuth/register`,{
      method : "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body : JSON.stringify(bodyData)
    })
    const data = await res.json()
    if(!res.ok){
      console.log(data);
      if(data.code == 409){
        throw new Error(data.message)
      }
      throw new Error("Something went wrong while Creating Account , Please try again after some time ");
    }
    setCookie('token' , encryptToken(data.token), 2);
    setCookie('role' , encryptToken(data.role) , 2);
    return data;
     
  }
  const handleUserLogin = async (arugs) =>{
    const bodyData = {
      username : arugs.emailOrPhone,
      password : arugs.password
    }
    const res = await fetch(`${url}/api/UserAuth/login`,{
      method : "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body : JSON.stringify(bodyData)
  })
  const data = await res.json();
  if(!res.ok){
    console.log(data);
    if(data.code == 401 || data.code == 404){
      throw new Error(data.message)
    }
    throw new Error("Something went Wrong While Creating Account , Please Try again after some time");
  }
  setCookie('token' , encryptToken(data.token) , 2)
  setCookie('role' , encryptToken(data.role) , 2);
    return data;
  }
 const handleLogout = () =>{
    removeCookie("token")
    removeCookie("role")
    window.location.href = '/'
 }
  fetchRouteTitle();
  useEffect(()=>{
    fetchRouteTitle().then(()=>setLoading(false))
  } , [])

    
    const value = {
      user,
      loading ,
      setLoading,
      handlerUserRegister,
      handleUserLogin,
      role,
      handleLogout,
      fetchWithAuth
      }

    
      return (
        <AuthContext.Provider value={value}>
          {
            loading ? (<><Loader_Component/></>): children
          }
        </AuthContext.Provider>
      )
  }

export default AuthProvider
export {useAuth}

export const getCookie = (name) => {
  let nameEQ = name + "=";
  let ca = document.cookie.split(';');
  for (let i = 0; i < ca.length; i++) {
      let c = ca[i];
      while (c.charAt(0) == ' ') c = c.substring(1, c.length);
      if (c.indexOf(nameEQ) == 0) return c.substring(nameEQ.length, c.length);
  }
  return null;
 }; 
const setCookie = (name, value, days) => {
  let expires = "";
  if (days) {
      const date = new Date();
      date.setTime(date.getTime() + (days * 24 * 60 * 60 * 1000));
      expires = "; expires=" + date.toUTCString();
  }
  let valueString= name + "=" + (value || "") + expires + "; path=/; secure; SameSite=Strict;"
  // if(name == 'token') valueString+="HttpOnly;"
  document.cookie = valueString;
};
const removeCookie = (name) => {
  document.cookie = name + "=; Max-Age=-99999999; path=/; secure; SameSite=Strict";
};

const fetchWithAuth = async (url, options = {}) => {
  const token = decryptToken(getCookie('token'));
  if (!options.headers) {
      options.headers = {};
  }
  if (token) {
      options.headers['Authorization'] = `Bearer ${token}`;
  }
  const response = await fetch(url, options);

  if (response.status === 401) {
      window.location.href = '/Login.html'; 
  }
  return response;
};

const encryptToken = (token,) => {
  return CryptoJS.AES.encrypt(token, secretKey).toString();
};

export const decryptToken = (encryptedToken) => {
  const bytes = CryptoJS.AES.decrypt(encryptedToken, secretKey);
  return bytes.toString(CryptoJS.enc.Utf8);
};