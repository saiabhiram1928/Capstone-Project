import React from 'react'
import {
    Card,
    Typography,
    List,
    ListItem,
    ListItemPrefix,
  } from "@material-tailwind/react";
import routesData from '../DATA/Portal_Navbar_Routes';
import { useAuth } from '../Context/AuthAndStateManager';
import Notification_Component from './Notification_Component';
import { Link } from 'react-router-dom';

const SideBar_Component = ({data}) => {
  const {role , handleLogout} = useAuth()
  const routes = routesData[role]
  return (

    <Card className="h-[calc(100vh)] rounded-none w-full max-w-[30rem] p-4 bg shadow-xl shadow-blue-gray-900/5 font-mono bg-[#FFF8DC]">
    <div className="mb-20 mt-5 p-4 flex justify-between items-center">
      <Typography variant="h5" color="blue-gray">
        <span>Care Portal</span>
      </Typography>
      {
        role == "Customer" && <Notification_Component/>
      }
    
    </div>
    <List className='px-5'>
        {
          routes.map((item)=>(
            <>
             <Link to={item.path}>
             <ListItem>
              <ListItemPrefix>
                {item.icon}
              </ListItemPrefix>
              {item.label}
              </ListItem>
              </Link>
            </>
           
          ))
        }
        <hr className="my-2 border-blue-gray-400" />
        <Link to="/">
        <ListItem >
          
          <ListItemPrefix>
          <svg xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" strokeWidth={1.5} stroke="currentColor" className="size-5">
  <path strokeLinecap="round" strokeLinejoin="round" d="m2.25 12 8.954-8.955c.44-.439 1.152-.439 1.591 0L21.75 12M4.5 9.75v10.125c0 .621.504 1.125 1.125 1.125H9.75v-4.875c0-.621.504-1.125 1.125-1.125h2.25c.621 0 1.125.504 1.125 1.125V21h4.125c.621 0 1.125-.504 1.125-1.125V9.75M8.25 21h8.25" />
</svg>

            </ListItemPrefix> 
           Home
        </ListItem>
        </Link>
        <ListItem onClick={handleLogout}>
          <ListItemPrefix><svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24" fill="currentColor" className="size-6">
  <path fillRule="evenodd" d="M12 2.25a.75.75 0 0 1 .75.75v9a.75.75 0 0 1-1.5 0V3a.75.75 0 0 1 .75-.75ZM6.166 5.106a.75.75 0 0 1 0 1.06 8.25 8.25 0 1 0 11.668 0 .75.75 0 1 1 1.06-1.06c3.808 3.807 3.808 9.98 0 13.788-3.807 3.808-9.98 3.808-13.788 0-3.808-3.807-3.808-9.98 0-13.788a.75.75 0 0 1 1.06 0Z" clipRule="evenodd" />
</svg>
</ListItemPrefix> 
           Logout
        </ListItem>
       
    </List>
    

  </Card>
  )
}

export default SideBar_Component