using Health_Insurance_Application.Context;
using Health_Insurance_Application.Models;
using Health_Insurance_Application.Repositories.Interfaces;

namespace Health_Insurance_Application.Repositories
{
    public class RenewalRepository : CRUDRepository<int,Renewal> , IRenewalRepository
    {
      public  RenewalRepository(HealthInsuranceContext context) : base(context) { }
    }
}
