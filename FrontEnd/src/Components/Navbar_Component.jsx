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
import { useAuth } from '../Context/AuthAndStateManager.jsx';
import Profile_Component from './Profile_Component';
import { Link, NavLink } from 'react-router-dom';


const Navbar_Component = () => {
  const [openNav, setOpenNav] = useState(false);
  const [schemeRoutes, setSchemeRoutes] = useState({});
  const {user,role , handleLogout} = useAuth()
  const navList = (
    <ul className="mt-2 mb-4 flex flex-col gap-2 lg:mb-0 lg:mt-0 lg:flex-row lg:items-center lg:gap-6">
    {schemeRoutes.individual && (
      <li className="flex items-center gap-x-1 p-1">
        <Dropdown menuItems={schemeRoutes.individual} title="Individual-Schemes"  type = "individual"/>
      </li>
    )}
    {schemeRoutes.family && (
      <li className="flex items-center gap-x-2 p-1">
        <Dropdown menuItems={schemeRoutes.family} title="Family-Schemes" type = "family"  />
      </li>
    )}
    { schemeRoutes.corporate && (
      <li className="flex items-center gap-x-2 p-1">
        <Dropdown menuItems={schemeRoutes.corporate} title="Corporate" type = "corporate" />
      </li>
    )}
  </ul>
  );
  const handleResize = () => {
    if (window.innerWidth >= 960) {
      setOpenNav(false);
    }
  };
  const loadSchemes =  () => {
    const routes = JSON.parse(sessionStorage.getItem('schemesRoute'));
    if (routes) {
      setSchemeRoutes(routes);
    }
  };

  useEffect(() => {
    window.addEventListener('resize', handleResize);
    loadSchemes();
    return () => {
      window.removeEventListener('resize', handleResize);
    };
  }, []);
  return (
    <>
    <Navbar className="mx-auto px-4 py-2 lg:px-8 lg:py-4" 
    style={{backgroundColor : '#FFF8DC'}}>
      <div className="container mx-auto flex items-center justify-between text-blue-gray-900" 
      >
        <Typography
          as="a"
          href="#"
          variant='h4'
          className="mr-4 cursor-pointer py-1.5 font-mono font-extrabold hover:font-extralight hover:ease-out"
        >
          <Link to="/">
          CARE
          </Link>
        </Typography>
        <div className="hidden lg:block">{navList}</div>
        <div className="flex items-center gap-x-1">
          {
            !user  ? (<>
              <Button  size="lg" className="hidden lg:inline-block ">
               <Link to="/login"> Login </Link>
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
               Log In
            </Button>
              </>) :(
                <>
            <Button fullWidth variant="text" size="sm" className="">
              <span><Link to="/portal">{role} Portal </Link> </span>
            </Button>
            <Button onClick={handleLogout} fullWidth variant="gradient" size="sm" className="">
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


 const Dropdown = ({menuItems , title , type }) => {
  if(menuItems == null) return;
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
         <span> {title} </span>
        <svg  xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" strokeWidth={1.5} stroke="currentColor" className="w-3 h-3" >
         <path strokeLinecap="round" strokeLinejoin="round" d="m19.5 8.25-7.5 7.5-7.5-7.5" />
        </svg>
        </Typography>
      </MenuHandler>
      <MenuList>
        <MenuItem> <Link to={`/scheme/${type}`}> All ({menuItems.length})</Link></MenuItem>
        <div className='grid grid-cols-2'>
        {
          menuItems.slice(0, 5).map((item , index)=>{
            return(
              <div className='hover:underline '>
                 <MenuItem key={index}><NavLink to={`/scheme/${type}/${item.schemeRoute}`} >{item.schemeRoute}</NavLink></MenuItem>
              </div>
             
            )
          })
        }
        </div>
      
      </MenuList>
    </Menu>
  )
}
