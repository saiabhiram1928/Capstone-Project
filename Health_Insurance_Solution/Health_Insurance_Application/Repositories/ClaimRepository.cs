using Health_Insurance_Application.Context;
using Health_Insurance_Application.Repositories.Interfaces;
using System.Security.Claims;
using System.Transactions;

namespace Health_Insurance_Application.Repositories
{
    public class ClaimRepository : CRUDRepository<int,Claim>, IClaimRepository 
    {
      public ClaimRepository(HealthInsuranceContext context) : base(context) { }

    }
}
