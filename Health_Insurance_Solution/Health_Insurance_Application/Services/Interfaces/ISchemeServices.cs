using Health_Insurance_Application.DTO;
using Health_Insurance_Application.Models;

namespace Health_Insurance_Application.Services.Interfaces
{
    public interface ISchemeServices
    {
        public Task<PremiumReturnDTO> CalculatePremiumForTotal(string paymentFrequency, int schemeId);
        public Task<PremiumReturnDTO> CalculatePremiumWithQuote(string paymentFrequency, int schemeId, float quoteCoverageAmount, int quotePaymentTerm);
        public Task<IList<SchemeRoutesDTO>> GetAllSchemeRoutes();
        public Task<Scheme> GetSchemeById(int schemeId);
        public Task<Scheme> GetByRouteTitle(string routeTitle);
        public Task<IList<SchemesAdminDTO>> GetAllSchemesForAdmin();
        public Task<MessageDTO> UpdateScheme(SchemeCreateDTO schemeCreateDTO, int schemeId);
        public Task<MessageDTO> CreateScheme(SchemeCreateDTO schemeCreateDTO);
        public Task<MessageDTO> ChangeSchemeActivity(string payload, string routeTitle);
    }
}
