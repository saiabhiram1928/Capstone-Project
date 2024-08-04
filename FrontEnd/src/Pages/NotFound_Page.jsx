import { Button } from '@material-tailwind/react'
import React from 'react'
import { Link } from 'react-router-dom'

const NotFound_Page = () => {
  return (
    <section className="flex items-center h-full p-16">
    <div className="container flex flex-col items-center justify-center px-5 mx-auto my-8 font-mono">
      <div className="max-w-md text-center">
        <h2 className="mb-8 font-extrabold text-9xl ">
          <span className="sr-only">Error</span>404
        </h2>
        <p className="text-2xl font-semibold md:text-3xl">Sorry, we couldn't find this page.</p>
        <Link to = "/">
        <Button className="flex items-center justify-between mt-20">
         
          <span><svg xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" strokeWidth={1.5} stroke="currentColor" className="size-5 mr-3">
  <path strokeLinecap="round" strokeLinejoin="round" d="M6.75 15.75 3 12m0 0 3.75-3.75M3 12h18" />
</svg>
</span>Back to homepage
         </Button>
         </Link>
      </div>
    </div>
  </section>
  )
}

export default NotFound_Page