using Health_Insurance_Application.DTO;
using Health_Insurance_Application.Models;
using Health_Insurance_Application.Models.Enums;
using Health_Insurance_Application.Repositories.Interfaces;
using Health_Insurance_Application.Services.Interfaces;

namespace Health_Insurance_Application.Services
{
    public class SchemeServices : ISchemeServices
    {
        private IPolicyRepository _policyRepo;
        private ISchemeRepository _schemeRepo;
        private IDTOService _dtoService;

        public SchemeServices(IPolicyRepository policyRepository , ISchemeRepository schemeRepository ,IDTOService dTOService) 
        {
            _policyRepo = policyRepository;
            _schemeRepo = schemeRepository;
            _dtoService = dTOService;
        }

        public async Task<PremiumReturnDTO> CalculatePremiumForTotal(string paymentFrequency , int schemeId)
        {
            var scheme = await _schemeRepo.GetById(schemeId);
            float ajustmentFactor =(float) scheme.CoverageAmount/ scheme.BaseCoverageAmount;
            float adjustedYearlyPremium = scheme.BasePremiumAmount * ajustmentFactor;
            int paymentFreq = 1;
            if (paymentFrequency == PaymentFrequencyEnum.Quarterly.ToString()) paymentFreq = 4;
            if (paymentFrequency == PaymentFrequencyEnum.Monthly.ToString()) paymentFreq = 12;

            float premium = adjustedYearlyPremium / paymentFreq;
            PremiumReturnDTO premiumDTO = new PremiumReturnDTO()
            {
                ActCoverageYears = scheme.CoverageYears,
                CoverageAmount = scheme.CoverageAmount,
                BaseCoverageAmount = scheme.BaseCoverageAmount,
                PaymentFrequency = paymentFrequency,
                Premium = premium,
                PaymentTerm = scheme.PaymentTerm
            };
            return premiumDTO;
        }
        public async Task<PremiumReturnDTO> CalculatePremiumWithQuote(string paymentFrequency, int schemeId, float quoteCoverageAmount, int quotePaymentTerm)
        {
            var scheme = await _schemeRepo.GetById(schemeId);
            if(quoteCoverageAmount < scheme.BaseCoverageAmount)
            {
                throw new NotSupportedException("Quote Amount Cant be lower than Base Coverage Amount");
            }
            float adjustmentFactor = (float)quoteCoverageAmount / scheme.BaseCoverageAmount;
            float adjustedYearlyPremium = scheme.BasePremiumAmount * adjustmentFactor;
            int paymentFreq = 1;
            if (paymentFrequency == PaymentFrequencyEnum.Quarterly.ToString()) paymentFreq = 4;
            if (paymentFrequency == PaymentFrequencyEnum.Monthly.ToString()) paymentFreq = 12;
            float premium = adjustedYearlyPremium / paymentFreq;
            float percentPaymentTermDec = (float) quotePaymentTerm / scheme.PaymentTerm;
            int coverageYear =  Convert.ToInt32(percentPaymentTermDec * scheme.CoverageYears);
            PremiumReturnDTO premiumDTO = new PremiumReturnDTO()
            {
                CoverageAmount = scheme.CoverageAmount,
                BaseCoverageAmount = scheme.BaseCoverageAmount,
                PaymentFrequency = paymentFrequency,
                Premium = premium,
                PaymentTerm = scheme.PaymentTerm,
                QuotedPaymentTerm = quotePaymentTerm,
                QuotedCovergaeAmount = quoteCoverageAmount,
                CalCoverageYears = coverageYear,
                ActCoverageYears = scheme.CoverageYears
              };
            return premiumDTO;
        }
        public async Task<IList<SchemeRoutesDTO>> GetAllSchemeRoutes()
        {
            var schemes = await _schemeRepo.GetAll();
            var res = new List<SchemeRoutesDTO>();

            foreach(var scheme in schemes )
            {
                res.Add(_dtoService.MapSchemeToSchemeRouteDTO(scheme));
            }
            return res;
        } 

        public async Task<Scheme> GetSchemeById(int schemeId)
        {
            var scheme = await _schemeRepo.GetById(schemeId);
            return scheme;
        }

    }
}
