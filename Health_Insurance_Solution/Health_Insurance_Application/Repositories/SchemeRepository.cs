using Health_Insurance_Application.Context;
using Health_Insurance_Application.Models;
using Health_Insurance_Application.Repositories.Interfaces;

namespace Health_Insurance_Application.Repositories
{
    public class SchemeRepository : CRUDRepository<int,Scheme> , ISchemeRepository
    {
       public SchemeRepository(HealthInsuranceContext context) : base(context) { }
    }
}
