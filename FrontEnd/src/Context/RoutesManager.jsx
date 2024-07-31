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
import Portal_Page from '../Pages/Portal_Page.jsx'
import ApplyPolicy_Page from '../Pages/ApplyPolicy_Page.jsx'

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
        <Route path='/profile' element = {<Profile_Page/> }/>
        <Route path = '/portal' element = {<Portal_Page role = {role}/>} />
         <Route path='/apply-policy' element={<Layout><ApplyPolicy_Page/></Layout>} />
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