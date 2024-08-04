import React from 'react';
import Chart from "react-apexcharts";

const PieChartSchemes_Component = ({ schemeData }) => {
  // Process the scheme data to get counts for each scheme
  const getSchemeCounts = (data) => {
    const counts = {};
    data.forEach(scheme => {
      const schemeName = scheme.schemeName;
      counts[schemeName] = (counts[schemeName] || 0) + scheme.count;
    });
    return counts;
  };

  // Prepare chart data
  const schemeCounts = getSchemeCounts(schemeData);
  const series = Object.values(schemeCounts);
  const labels = Object.keys(schemeCounts);
  console.log(getSchemeCounts(schemeData));

  const pieChartConfigSchemes = {
    type: "pie",
    width: 280,
    height: 280,
    series: series,
    options: {
      chart: {
        toolbar: { show: false },
      },
      dataLabels: { enabled: false },
      colors: ["#020617", "#ff8f00", "#00897b", "#1e88e5", "#d81b60"],
      labels: labels,
      legend: { show: false },
      annotations: {
        points: labels.map((label, index) => ({
          x: label,
          y: series[index],
          marker: {
            size: 0,
          },
          label: {
            borderColor: "#000",
            textAnchor: 'middle',
            offsetX: 0,
            style: {
              color: "#000",
              background: "#fff",
              fontSize: '12px',
            },
            text: `${label}: ${series[index]}`,
            position: 'right',
            offsetY: 0,
            x: 0,
            y: 0,
          }
        })),
      },
    },
  };

  return <Chart {...pieChartConfigSchemes} />;
};

export default PieChartSchemes_Component;
