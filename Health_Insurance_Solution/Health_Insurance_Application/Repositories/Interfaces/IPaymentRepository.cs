using Health_Insurance_Application.Models;

namespace Health_Insurance_Application.Repositories.Interfaces
{
    public interface IPaymentRepository : IRepository<int,Payment>
    {
        public Task<bool> CheckAnyPaymentPaid(int customerId, float basePremiumAmount);
        public Task<IList<Payment>> GetAllPaymentFromCustomerd(int customerId);
        public Task<DateTime?> GetNextPaymentDueDate(int customerId);
        public Task<Payment> GetPaymentExpriring(int customerId);
        public Task<Payment> GetRecentPayment(int customerId);
    }
}
