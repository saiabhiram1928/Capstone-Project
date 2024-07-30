import React from 'react'

const url = import.meta.env.VITE_BACKEND_URL;
const ScehmesManager = () => {

}
export const fetchRouteTitle = async (schemeTyp)=>{
    try{
        const paylod = "routes"
        const res = await fetch(`${url}/api/Schemes/get?payload=${encodeURIComponent(paylod)}`,{
            method : "GET"
        });
        const data =await res.json();
        if(!res.ok){
          
          throw new Error("Something Went Wrong While Fetching Routes");
        }
        const segData ={
            individual: [],
            corporate: [],
            family: []
        } 
        data.forEach(item => {
            switch (item.schemeType) {
              case 'Individual':
                segData.individual.push(item);
                break;
              case 'Corporate':
                segData.corporate.push(item);
                break;
              case 'Family':
                segData.family.push(item);
                break;
              default:
                console.warn(`Unknown SchemeType: ${item.schemeType}`);
            }
          });
          if(schemeTyp == "All") return segData;
          else if(schemeTyp == "Individual")  return segData.individual;
          else if(schemeTyp == "Corporate") return segData.corporate;
          else if(schemeTyp == "Family") return segData.family;
    }catch(err){
        console.log(err);

    }
   
    
}
export default ScehmesManager