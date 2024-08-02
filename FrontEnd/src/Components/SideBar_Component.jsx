import React from 'react'
import {
    Card,
    Typography,
    List,
    ListItem,
    ListItemPrefix,
    ListItemSuffix,
    Chip,
    CardFooter,
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
      <Notification_Component/>
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