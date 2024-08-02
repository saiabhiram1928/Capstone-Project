using Health_Insurance_Application.Context;
using Health_Insurance_Application.Models;
using Health_Insurance_Application.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Health_Insurance_Application.Repositories
{
    public class PolicyRepository : CRUDRepository<int,Policy> , IPolicyRepository
    {
       public PolicyRepository(HealthInsuranceContext context) : base(context) { }

        public async Task<bool> CheckUserAppliedForPolicy(int customerId)
        {
            var res = await _context.Policies.AnyAsync(item => item.CustomerId == customerId);
            return res;

        }
        public async Task<IList<Policy>> GetAllPoliciesAsync(int customerId)
        {
            var res =await _context.Policies.Include(p => p.Payments).Include(p => p.Claims).Include(p =>p.FamilyMembers).Include(p => p.CorporateEmployees).Include(p => p.Scheme).Include(p => p.Renewals)
                .Where(p => p.CustomerId == customerId ).ToListAsync();
            return res;
        }
        public async Task<Policy> GetPolicyById(int policyId)
        {
            var policy = await _context.Policies.Include(p => p.CorporateEmployees).Include(p => p.FamilyMembers).SingleOrDefaultAsync(p => p.PolicyId == policyId);
            if(policy == null)
            {
                throw new NotSupportedException("The with given policyid doent not found");
            }
            return policy;
        }
        public async Task<Policy> GetRecentCreatedPolicy(int customerId)
        {
            var policy = await _context.Policies
            .Where(p => p.CustomerId == customerId && p.PolicyStartDate <= DateTime.Now.AddDays(20))
            .OrderByDescending(p => p.PolicyStartDate)
            .FirstOrDefaultAsync();
            return policy;
        }
    }
}
