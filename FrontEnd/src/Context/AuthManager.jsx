import React, { createContext, useContext, useState } from 'react'

const AuthContext = createContext()

const useAuth = () => {
    return useContext(AuthContext)
  }


  const AuthProvider = ({ children }) => {
    const [loading, setLoading] = useState(false)
    const value = {
      }
    
      return (
        <AuthContext.Provider value={value}>
          {
            loading ? (<h1> Loading .... </h1>): children
          }
        </AuthContext.Provider>
      )
  }

