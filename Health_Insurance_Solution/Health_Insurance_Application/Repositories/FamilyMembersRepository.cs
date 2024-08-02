using Health_Insurance_Application.Context;
using Health_Insurance_Application.Models;
using Health_Insurance_Application.Repositories.Interfaces;

namespace Health_Insurance_Application.Repositories
{
    public class FamilyMembersRepository : CRUDRepository<int,FamilyMember>,IFamilyMemberRepository
    {
        public FamilyMembersRepository(HealthInsuranceContext context) : base(context) { }
    }
}
