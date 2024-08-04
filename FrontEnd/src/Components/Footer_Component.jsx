import { Typography } from '@material-tailwind/react';
import React from 'react'
import { Link } from 'react-router-dom';

const links = [
   {
  title : "Individual",
  route : "/scheme/individual"
},{
  title : "Family",
  route : "/scheme/family"
},{
  title : "Corporate",
  route : "/scheme/corporate"
}
];
const currentYear = new Date().getFullYear();

const Footer_Component = () => {
  return (
    <footer className="px-8 py-10 sticky bg-[#F3F2ED]">
    <div className="container mx-auto flex flex-col items-center">
      <div className="flex flex-wrap items-center justify-center gap-8 pb-2">
        {links.map((link, index) => (
          <ul key={index}>
            <li>
              <Link to = {link.route} >
              <Typography
                as="a"
                href="#"
                color="white"
                className="font-mono text-black font-extrabold transition-colors hover:text-blue-800 hover:underline"
              >
                {link.title}
              </Typography>
              </Link>
            </li>

          </ul>
        ))}
      </div>
      <Typography
        color="blue-gray"
        className="mt-6 text-lg font-normal text-green-600"
      >
        Copyright &copy; {currentYear} Care Health Insurance
      </Typography>
    </div>
  </footer>
  )
}

export default Footer_Component