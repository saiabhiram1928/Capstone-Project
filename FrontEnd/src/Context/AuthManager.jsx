import React, { createContext, useContext, useState } from 'react'

const AuthContext = createContext()

const useAuth = () => {
    return useContext(AuthContext)
  }


  const AuthProvider = ({ children }) => {
    const [loading, setLoading] = useState(false)


    const user = true;
    const value = {
      user
      }
    
      return (
        <AuthContext.Provider value={value}>
          {
            loading ? (<h1> Loading .... </h1>): children
          }
        </AuthContext.Provider>
      )
  }

export default AuthProvider
export {useAuth}
