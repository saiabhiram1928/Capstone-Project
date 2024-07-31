import React from 'react'
import { Link, NavLink } from 'react-router-dom';

const Pricing_Card_Component = ({title , description , route}) => {
    console.log(route);
  return (
<div className='container flex justify-center items-center relative flex-wrap'>
    <div className='water-drop'>
        <div className='water-content'>
            <h5 className='title font-mono lg:text-xl text-lg font-extrabold'> {title} </h5>
            <p className='description text-sm text-gray-700 font-mono'>{description}</p>
            <button className='read-more'> <NavLink to={route}>Know More</NavLink> </button>
        </div>
    </div>

</div>
  )
}

export default Pricing_Card_Component