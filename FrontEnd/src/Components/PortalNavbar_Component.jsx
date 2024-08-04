import React, { useEffect ,useState } from 'react';
import { useAuth } from '../Context/AuthAndStateManager';
import { Navbar, IconButton, Typography, Collapse } from '@material-tailwind/react';
import Notification_Component from './Notification_Component';
import Profile_Component from './Profile_Component';
import routesData from '../DATA/Portal_Navbar_Routes';

const PortalNavbar_Component = () => {
    const {role} = useAuth()
    const [openNav, setOpenNav] = useState(false);
    const handleResize = () => {
        if (window.innerWidth >= 960) {
          setOpenNav(false);
        }
      };
      useEffect(() => {
        window.addEventListener('resize', handleResize);
        return () => {
          window.removeEventListener('resize', handleResize);
        };
      }, []);
      const routes =routesData[role]
    return (
        <Navbar className="mx-auto px-6 py-3 rounded-none bg-[#FFF8DC]">
            <div className="flex items-center justify-between text-blue-gray-900">
                <div className="hidden md:block">
                    <Typography variant='paragraph' className='hover:text-blue-400 cursor-pointer'>
                        Home
                    </Typography>
                </div>
                <Typography
                    as="a"
                    href="#"
                    variant="h6"
                    className="md:mr-4 text-lg md:text-xl cursor-pointer py-1.5"
                >
                    CARE Customer Portal
                </Typography>
                <div className="w-1/3 md:w-1/4">
                    <ul className="my-2 flex justify-center items-center md:gap-5 w-full">
                        <Typography
                            as="li"
                            variant="small"
                            color="blue-gray"
                            className="p-1 font-medium"
                        >
                            <Notification_Component />
                        </Typography>
                        <Typography
                            as="li"
                            variant="small"
                            color="blue-gray"
                            className="p-1 font-medium hidden md:block"
                        >
                            <Profile_Component />
                        </Typography>
                    </ul>
                </div>
                <IconButton
                    variant="text"
                    className="ml-auto h-6 w-6 text-inherit hover:bg-transparent focus:bg-transparent active:bg-transparent lg:hidden"
                    ripple={false}
                    onClick={() => setOpenNav(!openNav)}
                >
                    {openNav ? (
            <svg
              xmlns="http://www.w3.org/2000/svg"
              fill="none"
              className="h-6 w-6"
              viewBox="0 0 24 24"
              stroke="currentColor"
              strokeWidth={2}
            >
              <path
                strokeLinecap="round"
                strokeLinejoin="round"
                d="M6 18L18 6M6 6l12 12"
              />
            </svg>
          ) : (
            <svg
              xmlns="http://www.w3.org/2000/svg"
              className="h-6 w-6"
              fill="none"
              stroke="currentColor"
              strokeWidth={2}
            >
              <path
                strokeLinecap="round"
                strokeLinejoin="round"
                d="M4 6h16M4 12h16M4 18h16"
              />
            </svg>
          )}
                </IconButton>
            </div>
            <Collapse open={openNav}>
        <div className="container mx-auto text-black">
           {
            routes.map((item)=>(
                <Typography className='py-3 flex items-center cursor-pointer'>{item.label}</Typography>
            ))
           }
        </div>
      </Collapse>
        </Navbar>
    );
};

export default PortalNavbar_Component;
