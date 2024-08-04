using Health_Insurance_Application.Context;
using Health_Insurance_Application.Models;
using Health_Insurance_Application.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Health_Insurance_Application.Repositories
{
    public class PolicyRepository : CRUDRepository<int,Policy> , IPolicyRepository
    {
       public PolicyRepository(HealthInsuranceContext context) : base(context) { }

        public async Task<bool> CheckUserAppliedForPolicy(int customerId , int shcemeId)
        {
            var res = await _context.Policies.AnyAsync(item => item.CustomerId == customerId && item.SchemeId == shcemeId );
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
        public async Task<List<int>> GetPoliciesCountByWeek()
        {
            DateTime today = DateTime.Now;
            DateTime lastWeek = today.AddDays(-7);

            var policies = await _context.Policies
                .Where(p =>  p.PolicyStartDate >= lastWeek && p.PolicyStartDate <= today)
                .ToListAsync();

            List<int> policiesByDay = Enumerable.Repeat(0, 7).ToList();

            foreach (var policy in policies)
            {
                int dayIndex = (policy.PolicyStartDate.Date - lastWeek).Days;
                policiesByDay[dayIndex]++;
            }

            return policiesByDay;
        }
        public async Task<List<int>> GetPoliciesCountByWeekInMonth()
        {
            DateTime today = DateTime.Today;
            DateTime firstDayOfMonth = new DateTime(today.Year, today.Month, 1);
            DateTime firstDayOfNextMonth = firstDayOfMonth.AddMonths(1);

            var policies = await _context.Policies
                .Where(p => p.PolicyStartDate >= firstDayOfMonth && p.PolicyStartDate < firstDayOfNextMonth)
                .ToListAsync();

            List<int> policiesByWeek = new List<int> { 0, 0, 0, 0 };

            foreach (var policy in policies)
            {
                int weekIndex = (policy.PolicyStartDate.Day - 1) / 7;
                policiesByWeek[weekIndex]++;
            }

            return policiesByWeek;
        }
        public async Task<string> GetMostAppliedScheme()
        {
            var policiesWithSchemes = await _context.Policies
                .Select(p => new { p.SchemeId, p.Scheme.RouteTitle })
                .ToListAsync();

            var mostAppliedScheme = policiesWithSchemes
                .GroupBy(p => p.SchemeId)
                .Select(g => new
                {
                    SchemeId = g.Key,
                    ApplicationCount = g.Count(),
                    RouteTitle = g.FirstOrDefault()?.RouteTitle
                })
                .OrderByDescending(g => g.ApplicationCount)
                .FirstOrDefault();
            return mostAppliedScheme?.RouteTitle ?? "";
        }
        public async Task<int> GetTotalPoliciesThisWeek()
        {

            DateTime today = DateTime.Now;
            int diff = today.DayOfWeek - DayOfWeek.Monday;
            if (diff < 0) diff += 7;
            DateTime startOfWeek = today.AddDays(-1 * diff).Date;

            DateTime endOfWeek = startOfWeek.AddDays(7).AddTicks(-1);

            var totalPolicies = await _context.Policies
                .Where(p => p.PolicyStartDate >= startOfWeek && p.PolicyStartDate <= endOfWeek)
                .CountAsync();

            return totalPolicies;
        }

        public async Task<int> GetTotalPoliciesThisMonth()
        {
            var startOfMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1); 
            var endOfMonth = startOfMonth.AddMonths(1).AddTicks(-1);

            var totalPolicies = await _context.Policies
                .Where(p => p.PolicyStartDate >= startOfMonth && p.PolicyStartDate <= endOfMonth)
                .CountAsync();

            return totalPolicies;
        }

        public async Task<int> GetPolicyCountForASchme(int schemeId)
        {
            var count = await _context.Policies.Where(p =>p.SchemeId == schemeId).CountAsync();
            return count;
        } 
    }
}
