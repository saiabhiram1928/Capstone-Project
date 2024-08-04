using Health_Insurance_Application.Context;
using Health_Insurance_Application.Models;
using Health_Insurance_Application.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace Health_Insurance_Application.Repositories
{
    public class ClaimRepository : CRUDRepository<int,Claims>, IClaimRepository 
    {
      public ClaimRepository(HealthInsuranceContext context) : base(context) { }

        public async Task<bool> CanDiscountApply(int customerId)
        {
            var claims = await _context.Claims.Where(c => c.CustomerId == customerId).ToListAsync();

            return claims.Count() == 0;
        }

        public async Task<Claims> GetRecentClaim(int customerId)
        {
            var claim = await _context.Claims.Where(c => c.CustomerId == customerId).OrderByDescending(c => c.ClaimedDate).FirstOrDefaultAsync();
            return claim;
        }
        public async Task<int> ClaimsAppledinMonth()
        {
            var startOfMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            var endOfMonth = startOfMonth.AddMonths(1);

            return await _context.Claims
                .Where(c => c.ClaimedDate >= startOfMonth && c.ClaimedDate < endOfMonth)
                .CountAsync();
        }
    }
}
