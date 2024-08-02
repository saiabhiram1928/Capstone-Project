using Health_Insurance_Application.Context;
using Health_Insurance_Application.Models;
using Health_Insurance_Application.Repositories.Interfaces;

namespace Health_Insurance_Application.Repositories
{
    public class CorporateEmployeesRepository : CRUDRepository<int,CorporateEmployee>,ICorporateEmployeeRepository
    {
        public CorporateEmployeesRepository(HealthInsuranceContext context) : base(context) { }
    }
}
