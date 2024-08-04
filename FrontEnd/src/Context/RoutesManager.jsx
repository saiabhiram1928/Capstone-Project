import React from 'react'
import { useAuth } from './AuthAndStateManager.jsx'
import { Route, Routes } from 'react-router-dom'
import Home_Page from '../Pages/Home_Page'
import Login_Page from '../Pages/Login_Page'
import Layout from '../Layout'
import Register_Page from '../Pages/Register_Page'
import NotFound_Page from '../Pages/NotFound_Page'
import Profile_Page from '../Pages/Profile_Page'
import Schemes_Page from '../Pages/Schemes_Page.jsx'
import SchemesData from '../DATA/Scheme_Data.jsx'
import Scheme_Page from '../Pages/Scheme_Page.jsx'
import Portal_Profile_Page from '../Pages/Portal_Profile_Page.jsx'
import ApplyPolicy_Page from '../Pages/ApplyPolicy_Page.jsx'
import Portal_Layout from '../Portal_Layout.jsx'
import Portal_Policy_Page from '../Pages/Portal_Policy_Page.jsx'
import Portal_Payment_Page from '../Pages/Portal_Payment_Page.jsx'
import ApplyClaimPage from '../Pages/Apply_Claim_Page.jsx'
import Admin_Policy_Page from '../Pages/Admin_Policy_Page.jsx'
import Admin_Claims_Page from '../Pages/Admin_Claims_Page.jsx'
import Admin_ClaimsAndPolicy_Page from '../Pages/Admin_ClaimsAndPolicy_Page.jsx'
import Admin_Payments_Page from '../Pages/Admin_Payments_Page.jsx'
import Admin_Schemes_Page from '../Pages/Admin_Schemes_Page.jsx'
import Admin_Scheme_Page from '../Pages/Admin_Scheme_Page.jsx'
import Admin_AddSchemes_Page from '../Pages/Admin_AddSchemes_Page.jsx'

const RoutesManager = () => {
    const { user , role } = useAuth()
    const schemeData = SchemesData;
  return (
    <Routes>
       <Route path='/' element = {<Layout><Home_Page/></Layout> }/>
       <Route path='/scheme/individual/' element = {<Layout><Schemes_Page data = {schemeData.individual}/></Layout> }/>
       <Route path='/scheme/family/' element = {<Layout><Schemes_Page data = {schemeData.family}/></Layout> }/>
       <Route path='/scheme/corporate/' element = {<Layout><Schemes_Page data = {schemeData.corporate}/></Layout> }/>
       <Route path = '/scheme/individual/:name' element = {<Layout><Scheme_Page/></Layout>}/>
       <Route path = '/scheme/family/:name' element = {<Layout><Scheme_Page/></Layout>}/>
       <Route path = '/scheme/corporate/:name' element = {<Layout><Scheme_Page/></Layout>}/>
       
       
      {
        user ? (<>
         <Route path = '/portal/profile' element = {<Portal_Layout><Portal_Profile_Page role = {role}/></Portal_Layout> } />
        {
          role == "Customer" && (
            <>
        <Route path='/apply-policy/:name' element={<ApplyPolicy_Page/>} />
        <Route path = '/portal/policies' element = {<Portal_Layout> <Portal_Policy_Page/></Portal_Layout> }/>
        <Route path = '/portal/payments' element = {<Portal_Layout> <Portal_Payment_Page/> </Portal_Layout>}/>
        </>
          )}
          {
            role == "Admin" && (
              <>

              <Route path = "/portal/admin/policies" element = {<Portal_Layout><Admin_Policy_Page/></Portal_Layout>}/>
              <Route path = "/portal/admin/claims" element = {<Portal_Layout><Admin_Claims_Page/></Portal_Layout>}/>
              <Route path = "/portal/admin/claims-policy/:id" element = {<Portal_Layout><Admin_ClaimsAndPolicy_Page/></Portal_Layout>}/>
              <Route path = "/portal/admin/payments" element = {<Portal_Layout><Admin_Payments_Page/></Portal_Layout>}/>
              <Route path = "/portal/admin/schemes" element = {<Portal_Layout><Admin_Schemes_Page/></Portal_Layout>}/>
              <Route path = "/portal/admin/scheme/:name" element = {<Portal_Layout><Admin_Scheme_Page/></Portal_Layout>}/>
              <Route path = "/portal/admin/scheme/add" element = {<Portal_Layout><Admin_AddSchemes_Page/></Portal_Layout>}/>
              
              
              </>
            )
          }
        
        </>) : (<>
          <Route path = '/login' element = {<Layout><Login_Page/></Layout>}/>
          <Route path = '/register' element = {<Layout><Register_Page/></Layout>}/>
        </>)
      }
      <Route path = '*' element = {<NotFound_Page/>}/>
      <Route path = '/404-NotFound' element = {<NotFound_Page/>}/>
    </Routes>
  )
}

export default RoutesManager