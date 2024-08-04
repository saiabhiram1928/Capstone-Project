import React, { useEffect, useState } from 'react';
import { Card, CardHeader, Typography, CardBody, Button } from "@material-tailwind/react";
import { ChangeSchemeStatus, GetAllSchemesForAdmin } from '../Context/ScehmesManager';
import { Link, useNavigate } from 'react-router-dom';

const TABLE_HEAD = ["Scheme Title", "Is Active", "Started At", "Scheme Type","Change Status"];

export function SchemeTable() {
  const [data, setData] = useState([]);
  const [loading, setLoading] = useState(true)

  const handleActiveStatus = async (status,route)=>{
    setLoading(true)
    try{
      const data =await ChangeSchemeStatus(status , route)
      alert(data.message)
      window.location.reload()
    }catch(err){
      alert(err)
    }finally{
      setLoading(false)
    }
  }
  const navigate = useNavigate()
  useEffect(() => {
   const fetchData = async ()=>{
    try{
        const data = await GetAllSchemesForAdmin();
        console.log(data);
        setData(data);
    }catch(err){
        alert(err)
    }finally{
        setLoading(false)
    }
   }
   fetchData();
  }, []);
  if(loading) return <h1>Loading ...</h1>
  return (
    <Card className="h-full w-full p-4">
      <CardHeader floated={false} shadow={false} className="rounded-none pb-4">
        <div className="mb-4 flex flex-col justify-between gap-8 md:flex-row md:items-center">
          <div>
            <Typography variant="h5" color="blue-gray">
              Schemes for Customers
            </Typography>
            <Typography color="gray" className="mt-1 font-normal">
              List of schemes available for customers
            </Typography>
          </div>
        </div>
      </CardHeader>
      <CardBody className="px-0">
        <Button onClick={()=>navigate("/portal/admin/scheme/add")} variant="outlined" className='mb-5 flex items-center justify-between' >
          <span><svg xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" strokeWidth={1.5} stroke="currentColor" className="size-4 mr-2">
  <path strokeLinecap="round" strokeLinejoin="round" d="M12 4.5v15m7.5-7.5h-15" />
</svg>

</span>
          Add Scheme</Button>
        <table className="w-full min-w-max table-auto text-left">
          <thead>
            <tr>
              {TABLE_HEAD.map((head, index) => (
                <th
                  key={index}
                  className="border-y border-blue-gray-100 bg-blue-gray-50/50 p-4"
                >
                  <Typography
                    variant="small"
                    color="blue-gray"
                    className="font-normal leading-none opacity-70"
                  >
                    {head}
                  </Typography>
                </th>
              ))}
            </tr>
          </thead>
          <tbody>
            {data.map((item, index) => {
              const isLast = index === data.length - 1;
              const classes = isLast ? "p-4" : "p-4 border-b border-blue-gray-50";

              return (
                <tr key={index}>
                  <td className={classes}>
                    <Typography variant="small" color="blue-gray" className="font-normal hover:text-blue-500 underline">
                    <Link to ={`/portal/admin/scheme/${item.title}`} >
                      {item.title}
                      </Link>
                    </Typography>
                  </td>
                  <td className={classes}>
                    <Typography variant="small" color="blue-gray" className="font-normal">
                      {item.isActive ? "Active" : "Inactive"}
                    </Typography>
                  </td>
                  <td className={classes}>
                    <Typography variant="small" color="blue-gray" className="font-normal">
                      {new Date(item.startedAt).toDateString()}
                    </Typography>
                  </td>
                  <td className={classes}>
                    <Typography variant="small" color="blue-gray" className="font-normal">
                      {item.type}
                    </Typography>
                  </td>
                  <td className={classes}>
                    
                        {
                            item.isActive ? (<Button className="font-mono" onClick={()=>handleActiveStatus("Deactivate" , item.title)}>Deactivate</Button>) : (
                                <Button className='font-mono' onClick={() =>handleActiveStatus("Activate" , item.title)} >Activiate</Button>
                            )
                        }
                  </td>
                </tr>
              );
            })}
          </tbody>
        </table>
      </CardBody>
    </Card>
  );
}

export default SchemeTable;
