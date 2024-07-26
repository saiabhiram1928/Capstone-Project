using Health_Insurance_Application.Context;
using Health_Insurance_Application.Models;
using Health_Insurance_Application.Repositories.Interfaces;

namespace Health_Insurance_Application.Repositories
{
    public class PaymentRepository : CRUDRepository<int,Payment> ,IPaymentRepository
    {
       public PaymentRepository(HealthInsuranceContext context) : base(context) { }
    }
}
