using Health_Insurance_Application.Context;
using Health_Insurance_Application.Models;
using Health_Insurance_Application.Repositories.Interfaces;

namespace Health_Insurance_Application.Repositories
{
    public class AdminRepository : CRUDRepository<int,Admin> , IAdminRepository
    {
       public AdminRepository(HealthInsuranceContext context) : base(context) { }
    }
}
