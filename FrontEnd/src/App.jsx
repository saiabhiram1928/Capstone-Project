import React from 'react'
import { BrowserRouter } from 'react-router-dom'
import AuthProvider from './Context/AuthManager'
import RoutesManager from './Context/RoutesManager'


const App = () => {
 
  return (
    <BrowserRouter>
   <AuthProvider>
    <RoutesManager/>
   </AuthProvider>
   </BrowserRouter>
  )
}

export default App