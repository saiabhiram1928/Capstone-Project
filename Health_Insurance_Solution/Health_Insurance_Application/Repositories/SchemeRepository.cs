using Health_Insurance_Application.Context;
using Health_Insurance_Application.Exceptions;
using Health_Insurance_Application.Models;
using Health_Insurance_Application.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Health_Insurance_Application.Repositories
{
    public class SchemeRepository : CRUDRepository<int,Scheme> , ISchemeRepository
    {
       public SchemeRepository(HealthInsuranceContext context) : base(context) { }

        public async Task<Scheme> GetByRouteTitle(string routeTitle)
        {
            var scheme = await _context.Schemes.SingleOrDefaultAsync(item => item.RouteTitle == routeTitle);
            if(scheme == null)
            {
                throw new NoSuchItemInDbException("Please Check the Route title");
            }
            return scheme;
        }
    }
}
