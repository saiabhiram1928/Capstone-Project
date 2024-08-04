using Health_Insurance_Application.DTO;
using Health_Insurance_Application.Models;

namespace Health_Insurance_Application.Services.Interfaces
{
    public interface IPolicyService
    {
        public Task<MessageDTO> AddPolicy(PolicyApplyDTO policyApplyDTO);
        public Task<IList<PolicyReturnDTO>> FetchPolices();
        public Task<MessageDTO> ApplyClaim(float ClaimAmount, string ClaimReason, int policyId, int schemeId);
        public Task<IList<Payment>> GetAllPayment(int id);
        public Task<MessageDTO> PremiumPayment(int paymentId);
        public Task<MessageDTO> RenewalPolicy(int policyId);
        public Task<PolicyAnalyticsDTO> PolicyAnalytics();
        public  Task<IList<AdminClaimDTO>> GetAllClaimsForCustomer();
        public Task<MessageDTO> ChangeClaimStatus(string status, int claimId);
        public Task<IList<Payment>> GetAllCompletedPaymentsForAdmin();
        public Task<IList<PolicyReturnDTO>> FetchPolicyOfCustomerForAdmin(int customerId);
    }
}
