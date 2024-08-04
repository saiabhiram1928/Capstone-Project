import React, { useEffect, useState } from 'react';
import {
  Typography,
  Card,
  CardBody,
  CardHeader,
  CardFooter
} from "@material-tailwind/react";
import Chart from "react-apexcharts";
import KPICard_Component from "../Components/KPICard_Component"; // Adjust path as necessary
import PieChartCategories_Component from '../Components/PieChart_Categories_Component';
import PieChartSchemes_Component from '../Components/PieChart_Schemes_Component';
import { fetchPolicyAnalytics } from '../Context/PolicyManager';

// Chart configurations
const createChartConfig = (data, categories) => ({
  type: "line",
  height: 240,
  series: [
    {
      name: "Policies",
      data: data,
    },
  ],
  options: {
    chart: {
      toolbar: {
        show: true,
      },
    },
    dataLabels: {
      enabled: false,
    },
    colors: ["#020617"],
    stroke: {
      lineCap: "round",
      curve: "smooth",
    },
    markers: {
      size: 0,
    },
    xaxis: {
      axisTicks: {
        show: false,
      },
      axisBorder: {
        show: false,
      },
      labels: {
        style: {
          colors: "#616161",
          fontSize: "12px",
          fontFamily: "inherit",
          fontWeight: 400,
        },
      },
      categories: categories,
    },
    yaxis: {
      labels: {
        style: {
          colors: "#616161",
          fontSize: "12px",
          fontFamily: "inherit",
          fontWeight: 400,
        },
      },
    },
    grid: {
      show: true,
      borderColor: "#dddddd",
      strokeDashArray: 5,
      xaxis: {
        lines: {
          show: true,
        },
      },
      padding: {
        top: 5,
        right: 20,
      },
    },
    fill: {
      opacity: 0.8,
    },
    tooltip: {
      theme: "dark",
    },
  },
});



 const Admin_Policy_Page = () =>{
  const [analytics, setAnalytics] = useState({});
  const [loading, setLoading] = useState(true);
  useEffect(()=>{
    const fetchData = async()=>{
      try{
        const data = await fetchPolicyAnalytics();
      setAnalytics(data)
      }catch(err){
        throw new Error(err)
      }finally{
        setLoading(false);
      }
    }
    fetchData()
  },[])
  if(loading )return <h1>Loading.......</h1>
  const getPast7DaysLabels = () => {
    const today = new Date();
    const labels = [];
    for (let i = 6; i >= 0; i--) {
      const date = new Date(today);
      date.setDate(today.getDate() - i);
      labels.push(date.toLocaleDateString('en-GB', { day: '2-digit', month: 'short' }));
    }
    return labels;
  };

  const monthChartConfig = createChartConfig(analytics.monthData || [0, 0, 0, 0], ["Week 1", "Week 2", "Week 3", "Week 4"]);
  const weekChartConfig = createChartConfig(analytics.weekData || [0, 0, 0, 0, 0, 0, 0, 0, 0],getPast7DaysLabels());
  return (
    <div className="p-6">
      <Card className="shadow-lg border-none">
        <CardHeader
          floated={false}
          shadow={false}
          color="transparent"
          className="flex flex-col gap-4 rounded-none md:flex-row md:items-center border-b-2 border-gray-300"
        >
          <div className="flex items-center gap-2">
            <svg
              xmlns="http://www.w3.org/2000/svg"
              fill="none"
              viewBox="0 0 24 24"
              strokeWidth={1.5}
              stroke="currentColor"
              className="w-6 h-6 text-blue-500"
            >
              <path
                strokeLinecap="round"
                strokeLinejoin="round"
                d="M19.5 14.25v-2.625a3.375 3.375 0 0 0-3.375-3.375h-1.5A1.125 1.125 0 0 1 13.5 7.125v-1.5a3.375 3.375 0 0 0-3.375-3.375H8.25m2.25 9h3.75m-4.5 2.625h4.5M12 18.75 9.75 16.5h.375a2.625 2.625 0 0 0 0-5.25H9.75m.75-9H5.625c-.621 0-1.125.504-1.125 1.125v17.25c0 .621.504 1.125 1.125 1.125h12.75c.621 0 1.125-.504 1.125-1.125V11.25a9 9 0 0 0-9-9Z"
              />
            </svg>
            <Typography variant="h5" color="blue-gray">
              Policy Analytics
            </Typography>
          </div>
        </CardHeader>
        <CardBody className="p-6">
          <div className="grid gap-6 mb-6 md:grid-cols-2 lg:grid-cols-4">
            <KPICard_Component
              title="Total Policies This Week"
              price={analytics.policiesAppliedinWeek}
              icon={<svg xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" strokeWidth={1.5} stroke="currentColor" className="size-6">
              <path strokeLinecap="round" strokeLinejoin="round" d="M2.25 18 9 11.25l4.306 4.306a11.95 11.95 0 0 1 5.814-5.518l2.74-1.22m0 0-5.94-2.281m5.94 2.28-2.28 5.941" />
            </svg>
            }
            />
            <KPICard_Component
              title="Total Policies This Month"
              price={analytics.policiesAppliedinMonth}
              icon={<svg xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" strokeWidth={1.5} stroke="currentColor" className="size-6">
              <path strokeLinecap="round" strokeLinejoin="round" d="M2.25 18 9 11.25l4.306 4.306a11.95 11.95 0 0 1 5.814-5.518l2.74-1.22m0 0-5.94-2.281m5.94 2.28-2.28 5.941" />
            </svg>
            }
            />
            <KPICard_Component
              title="Most Applied Scheme"
              price={analytics.mostApplied}
              icon={<svg xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" strokeWidth={1.5} stroke="currentColor" className="size-6">
              <path strokeLinecap="round" strokeLinejoin="round" d="M2.25 18 9 11.25l4.306 4.306a11.95 11.95 0 0 1 5.814-5.518l2.74-1.22m0 0-5.94-2.281m5.94 2.28-2.28 5.941" />
            </svg>
            }
            />
            <KPICard_Component
              title="Total Claims This Month"
              price={analytics.claimsAppledinMonth}
              icon={<svg xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" strokeWidth={1.5} stroke="currentColor" className="size-6">
              <path strokeLinecap="round" strokeLinejoin="round" d="M2.25 18 9 11.25l4.306 4.306a11.95 11.95 0 0 1 5.814-5.518l2.74-1.22m0 0-5.94-2.281m5.94 2.28-2.28 5.941" />
            </svg>
            }
            />
          </div>
          <div className="grid gap-6 md:grid-cols-1 lg:grid-cols-1">
            <div className="p-4">
              <Typography variant="h6" color="blue-gray">
                Policies Applied This Month
              </Typography>
              <Chart {...monthChartConfig} />
            </div>
            <div className="p-4">
              <Typography variant="h6" color="blue-gray">
                Policies Applied for last 7 days
              </Typography>
              <Chart {...weekChartConfig} />
            </div>
          </div>
        </CardBody>
        <CardFooter>
        <div className="flex flex-col ">
            <Card className="shadow-lg border-none">
              <CardHeader className="p-6 border-b-2 border-gray-300 bg-black">
                <Typography variant="h6" color="white">
                  Policies by Scheme
                </Typography>
              </CardHeader>
              <CardBody className="flex justify-center p-6">
                <PieChartSchemes_Component schemeData={analytics.schemesAnalyticsDTOs} />
              </CardBody>
            </Card>
            <Card className="shadow-lg border-none mt-10">
              <CardHeader className="p-6 border-b-2 border-gray-300 bg-black">
                <Typography variant="h6" color="white">
                  Policies by Category
                </Typography>
              </CardHeader>
              <CardBody className="flex justify-center p-6">
                <PieChartCategories_Component schemeData={analytics.schemesAnalyticsDTOs} />
              </CardBody>
            </Card>
          </div>
        </CardFooter>
      </Card>
    </div>
  );
}
export default Admin_Policy_Page
