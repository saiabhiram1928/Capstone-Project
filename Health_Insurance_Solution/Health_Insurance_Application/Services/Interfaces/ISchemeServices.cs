using Health_Insurance_Application.DTO;

namespace Health_Insurance_Application.Services.Interfaces
{
    public interface ISchemeServices
    {
        public Task<PremiumReturnDTO> CalculatePremiumForTotal(string paymentFrequency, int schemeId);
        public Task<PremiumReturnDTO> CalculatePremiumWithQuote(string paymentFrequency, int schemeId, float quoteCoverageAmount, int quotePaymentTerm);
        public Task<IList<SchemeRoutesDTO>> GetAllSchemeRoutes();
    }
}
