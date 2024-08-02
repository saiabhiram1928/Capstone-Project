using Health_Insurance_Application.Context;
using Health_Insurance_Application.Exceptions;
using Health_Insurance_Application.Models;
using Health_Insurance_Application.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Health_Insurance_Application.Repositories
{
    public class PaymentRepository : CRUDRepository<int,Payment> ,IPaymentRepository
    {
       public PaymentRepository(HealthInsuranceContext context) : base(context) { }

       public async Task<bool> CheckAnyPaymentPaid(int customerId, float basePremiumAmount)
        {
            var check = await _context.Payments.AnyAsync(item => item.CustomerId == customerId && item.PaymentAmount == basePremiumAmount && item.PaymentDone == true);
            return check;
        }
        public async Task<IList<Payment>> GetAllPaymentFromCustomerd(int customerId)
        {
            var payments = await _context.Payments.Where(p => p.CustomerId == customerId).ToListAsync();
            return payments;
        }       
        public async Task<DateTime?> GetNextPaymentDueDate(int customerId)
        {
            var payments = await _context.Payments
       .Where(p => p.CustomerId == customerId && !p.PaymentDone)
       .OrderBy(p => p.PaymentDueDate)
       .ToListAsync();
            var nextPayment = payments.FirstOrDefault();
            return nextPayment?.PaymentDueDate;
        }

        public async Task<Payment> GetPaymentExpriring(int customerId)
        {
            var payment = await _context.Payments.Where(p => p.CustomerId == customerId && p.PaymentDone ==false).Where( p => ((p.PaymentDate > DateTime.Now ) || (p.PaymentDate.AddDays(4) == DateTime.Now))).OrderBy(p => p.PaymentDate > DateTime.Now ? 0 : 1) 
          .ThenBy(p => p.PaymentDate)
          .FirstOrDefaultAsync();
            return payment;
        }

        public async Task<Payment> GetRecentPayment(int customerId)
        {
            var payment = await _context.Payments
                        .Where(p => p.CustomerId == customerId && p.PaymentDone == true)
                        .OrderByDescending(p => p.PaymentDate)
                        .FirstOrDefaultAsync();

            return payment;
        }   
    }
}
