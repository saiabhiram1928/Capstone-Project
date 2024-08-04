import React from 'react'
import { useLocation } from 'react-router-dom';
import Navbar_Component from './Components/Navbar_Component';
import Footer_Component from './Components/Footer_Component';

const Layout = ({children}) => {
    const location = useLocation();
    const hiddenNavbarPaths = ['/login', '/register']
    const isNavbarHidden = hiddenNavbarPaths.includes(location.pathname);
  return (
    <>
    {!isNavbarHidden && <Navbar_Component />}
    <main className="flex-1">{children}</main>
    {!isNavbarHidden && <Footer_Component/>}
    </>
  )
}

export default Layout