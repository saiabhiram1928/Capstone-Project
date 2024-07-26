using Health_Insurance_Application.Context;
using Health_Insurance_Application.Models;
using Health_Insurance_Application.Repositories.Interfaces;

namespace Health_Insurance_Application.Repositories
{
    public class HospitalAgentRepository : CRUDRepository<int, HospitalAgent> , IHospitalAgentRepository
    {
      public  HospitalAgentRepository(HealthInsuranceContext context) : base(context) { }
    }
}
