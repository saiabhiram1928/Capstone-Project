using Health_Insurance_Application.Context;
using Health_Insurance_Application.Models;
using Health_Insurance_Application.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Health_Insurance_Application.Repositories
{
    public class AdminRepository : CRUDRepository<int,Admin> , IAdminRepository
    {
       public AdminRepository(HealthInsuranceContext context) : base(context) { }
        public async Task<bool> CheckUserExistByUid(int uid)
        {
            return await _context.Admins.AnyAsync(item => item.Uid == uid);
        }
    }
}
