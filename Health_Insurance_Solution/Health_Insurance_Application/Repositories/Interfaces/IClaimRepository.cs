using Health_Insurance_Application.Models;

namespace Health_Insurance_Application.Repositories.Interfaces
{
    public interface IClaimRepository : IRepository<int,Claims>
    {
        public Task<bool> CanDiscountApply(int customerId);
        public Task<Claims> GetRecentClaim(int customerId);
    }
}
