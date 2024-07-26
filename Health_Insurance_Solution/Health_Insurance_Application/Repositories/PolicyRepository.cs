using Health_Insurance_Application.Context;
using Health_Insurance_Application.Models;
using Health_Insurance_Application.Repositories.Interfaces;

namespace Health_Insurance_Application.Repositories
{
    public class PolicyRepository : CRUDRepository<int,Policy> , IPolicyRepository
    {
       public PolicyRepository(HealthInsuranceContext context) : base(context) { }
    }
}
