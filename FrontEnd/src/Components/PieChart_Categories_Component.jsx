import React from 'react';
import Chart from "react-apexcharts";

const PieChartCategories_Component = ({ schemeData }) => {

  const categoryCounts = schemeData.reduce((acc, scheme) => {
    const category = scheme.schemeCategory;
    acc[category] = (acc[category] || 0) + scheme.count;
    return acc;
  }, {});
  const schemeCategories = Object.keys(categoryCounts).map(category => ({
    category,
    count: categoryCounts[category]
  }));

  const pieChartConfigCategories = {
    type: "pie",
    width: 280,
    height: 280,
    series: schemeCategories.map(cat => cat.count),
    options: {
      chart: {
        toolbar: { show: true },
      },
      dataLabels: { enabled: true },
      colors: ["#FF5733", "#33FF57", "#3357FF"],
      labels: schemeCategories.map(cat => cat.category),
      legend: { show: false },
    },
  };

  return <Chart {...pieChartConfigCategories} />;
};

export default PieChartCategories_Component;
