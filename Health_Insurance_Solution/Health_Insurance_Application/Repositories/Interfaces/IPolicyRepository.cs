using Health_Insurance_Application.Models;

namespace Health_Insurance_Application.Repositories.Interfaces
{
    public interface IPolicyRepository : IRepository<int, Policy>
    {
        public  Task<bool> CheckUserAppliedForPolicy(int customerId);
        public Task<IList<Policy>> GetAllPoliciesAsync(int customerId);
        public Task<Policy> GetPolicyById(int policyId);
        public Task<Policy> GetRecentCreatedPolicy(int customerId);
    }
}
