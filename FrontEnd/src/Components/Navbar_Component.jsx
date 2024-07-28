import React , {useEffect , useState} from 'react'
import {
  Navbar,
  Typography,
  Button,
  IconButton,
  Collapse,
  Menu,
  MenuHandler,
  MenuList,
  MenuItem,
} from "@material-tailwind/react";
import { useAuth } from '../Context/AuthManager';
import Profile_Component from './Profile_Component';


const Navbar_Component = () => {
  const [openNav, setOpenNav] = React.useState(false);
  const {user} = useAuth()
  console.log(user);
  const navList = (
    <ul className="mt-2 mb-4 flex flex-col gap-2 lg:mb-0 lg:mt-0 lg:flex-row lg:items-center lg:gap-6">
      <li
        className="flex items-center gap-x-1 p-1"
      >
       <Dropdown_1/>
      </li>
      <li
        className="flex items-center gap-x-2 p-1"
      >
       <Dropdown_1/>
      </li>
      <li
        className="flex items-center gap-x-2 p-1"
      >
       <Dropdown_1/>
      </li>
    </ul>
  );
 
  useEffect(() => {
    window.addEventListener(
      "resize",
      () => window.innerWidth >= 960 && setOpenNav(false),
    );
  }, []);
  return (
    <>
    <Navbar className="mx-auto max-w-screen-xl px-4 py-2 lg:px-8 lg:py-4" 
    style={{backgroundColor : '#FFF8DC'}}>
      <div className="container mx-auto flex items-center justify-between text-blue-gray-900" 
      >
        <Typography
          as="a"
          href="#"
          variant='h4'
          className="mr-4 cursor-pointer py-1.5 font-mono font-extrabold hover:font-extralight hover:ease-out"
        >
          CARE
        </Typography>
        <div className="hidden lg:block">{navList}</div>
        <div className="flex items-center gap-x-1">
          {
            !user  ? (<>
              <Button variant="text" size="sm" className="hidden lg:inline-block">
            <span>Log In</span>
          </Button>
          <Button
            variant="gradient"
            size="sm"
            className="hidden lg:inline-block"
          >
            <span>Sign in</span>
          </Button>
            </>) : (<div className='lg:block hidden '><Profile_Component/></div>)
          }
        
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
        <div className="container mx-auto">
          {navList}
          <div className="flex items-center gap-x-1">
            {
              !user ? (<>
                <Button fullWidth variant="text" size="sm" className="">
              <span>Log In</span>
            </Button>
            <Button fullWidth variant="gradient" size="sm" className="">
              <span>Sign in</span>
            </Button>
              </>) :(
                <>
                   <Button fullWidth variant="text" size="sm" className="">
              <span>My Profile</span>
            </Button>
            <Button fullWidth variant="gradient" size="sm" className="">
              <span>Logout</span>
            </Button>
                </>
              )
            }
          
          </div>
        </div>
      </Collapse>
      
    </Navbar>
    
    </>
  )
}

export default Navbar_Component


 const Dropdown_1 = () => {
  const menuItems = [
    "Individual Policy 1",
    "Individual Policy 2",
    "Individual Policy 3"
  ];

  return (
    <Menu
      animate={{
        mount: { y: 0 },
        unmount: { y: 25 },
      }}
      allowHover
    >
      <MenuHandler>
        <Typography variant='paragraph' as="a" href="#"  className='font-mono text-sm font-light flex items-center gap-x-1 p-1 text-black'>
         <span> Individual Plan</span>
        <svg  xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" strokeWidth={1.5} stroke="currentColor" className="w-3 h-3" >
         <path strokeLinecap="round" strokeLinejoin="round" d="m19.5 8.25-7.5 7.5-7.5-7.5" />
        </svg>
        </Typography>
      </MenuHandler>
      <MenuList>
        {
          menuItems.map((item)=>{
            return(
              <MenuItem>{item}</MenuItem>
            )
          })
        }
      </MenuList>
    </Menu>
  )
}
