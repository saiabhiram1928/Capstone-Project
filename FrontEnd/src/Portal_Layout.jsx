import React from 'react';
import PortalNavbar_Component from './Components/PortalNavbar_Component';
import SideBar_Component from './Components/SideBar_Component';

const Portal_Layout = ({ children }) => {
  return (
    <div className="flex">
      {/* Sidebar for larger screens */}
      <div className="hidden md:flex md:flex-shrink-0 w-64 bg-gray-200 h-screen fixed">
        <SideBar_Component />
      </div>

      {/* Main content area */}
      
      <div className="flex-1 md:ml-64 flex flex-col ml-0">
      <div className="bg-[#FFF8DC] md:hidden block">
          <PortalNavbar_Component />
        </div>
        <main className="flex-1 bg-gray-100 min-h-screen ">
          {children}
        </main>
      </div>
    </div>
  );
};

export default Portal_Layout;
