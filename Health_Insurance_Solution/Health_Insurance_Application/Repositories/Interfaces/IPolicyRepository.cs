using Health_Insurance_Application.Models;

namespace Health_Insurance_Application.Repositories.Interfaces
{
    public interface IPolicyRepository : IRepository<int, Policy>
    {
        public  Task<bool> CheckUserAppliedForPolicy(int customerId , int schemeId);
        public Task<IList<Policy>> GetAllPoliciesAsync(int customerId);
        public Task<Policy> GetPolicyById(int policyId);
        public Task<Policy> GetRecentCreatedPolicy(int customerId);
        public Task<List<int>> GetPoliciesCountByWeek();
        public Task<List<int>> GetPoliciesCountByWeekInMonth();
        public Task<string> GetMostAppliedScheme();
        public Task<int> GetTotalPoliciesThisWeek();
        public  Task<int> GetTotalPoliciesThisMonth();
        public Task<int> GetPolicyCountForASchme(int schemeId);

    }
}
