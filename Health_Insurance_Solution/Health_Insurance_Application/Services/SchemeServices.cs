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
                PaymentTerm = scheme.PaymentTerm,
                CalCoverageYears = scheme.CoverageYears,
            };
            return premiumDTO;
        }
        public async Task<PremiumReturnDTO> CalculatePremiumWithQuote(string paymentFrequency, int schemeId, float quoteCoverageAmount, int quotePaymentTerm)
        {
            var scheme = await _schemeRepo.GetById(schemeId);
            if(quoteCoverageAmount < scheme.BaseCoverageAmount || quoteCoverageAmount > scheme.CoverageAmount)
            {
                throw new NotSupportedException("Quote Amount Cant be lower than Base Coverage Amount");
            }
            if(quotePaymentTerm > scheme.PaymentTerm || quotePaymentTerm <=0)
            {
                throw new NotSupportedException($"Quoted Payment Term Cant greater than {scheme.PaymentTerm}");
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
            schemes =schemes.Where(s => s.IsActive ==  true);
            foreach(var scheme in schemes )
            {
                res.Add(_dtoService.MapSchemeToSchemeRouteDTO(scheme));
            }
            return res;
        } 

        public async Task<Scheme> GetSchemeById(int schemeId)
        {
            var scheme = await _schemeRepo.GetById(schemeId);
            if(scheme.IsActive == false)
            {
                throw new NullReferenceException("Scheme Is not Active");
            }
            return scheme;
        }
        public async Task<Scheme> GetByRouteTitle(string routeTitle)
        {
            var scheme =await _schemeRepo.GetByRouteTitle(routeTitle);
            if(scheme.IsActive == false)
            {
                throw new UnauthorizedAccessException("The Scheme is Not Active");
            }
            return scheme;
        }
        public async Task<MessageDTO> CreateScheme(SchemeCreateDTO schemeCreateDTO)
        {
            var scheme = _dtoService.MapSchemeCreateDTOToScheme(schemeCreateDTO);

            await _schemeRepo.Add(scheme);
            return new MessageDTO()
            {
                Message = "Scheme Added Scuesfully",
            };

        }

        public async Task<MessageDTO> UpdateScheme(SchemeCreateDTO schemeCreateDTO, int schemeId)
        {
            var scheme = await _schemeRepo.GetById(schemeId);
            scheme.BaseCoverageAmount = schemeCreateDTO.BaseCoverageAmount;
            scheme.BasePremiumAmount = schemeCreateDTO.BasePremiumAmount;
            scheme.CoverageAmount = schemeCreateDTO.CoverageAmount;
            scheme.CoverageYears = schemeCreateDTO.CoverageYears;
            scheme.PaymentTerm = schemeCreateDTO.PaymentTerm;
            scheme.RouteTitle = schemeCreateDTO.RouteTitle;
            scheme.SchemeDescription = schemeCreateDTO.SchemeDescription;
            scheme.SchemeLastUpdatedAt = DateTime.UtcNow;
            scheme.SchemeName = schemeCreateDTO.SchemeName;
            scheme.SmallDescription = schemeCreateDTO.SmallDescription;
            scheme.SchemeType = schemeCreateDTO.SchemeType;

            await _schemeRepo.Update(scheme);
            return new MessageDTO()
            {
                Message = "Scheme Updated Sucesfully"
            };
        }

        public async Task<IList<SchemesAdminDTO>> GetAllSchemesForAdmin()
        {
            var schemes = await _schemeRepo.GetAll();

            var schemesAdminDTOs =new List<SchemesAdminDTO>();
            foreach(var scheme in schemes)
            {
                var schemeAdminDTO = new SchemesAdminDTO()
                {
                    startedAt = scheme.SchemeStartedAt,
                    isActive = scheme.IsActive,
                    Title = scheme.RouteTitle,
                    Type = scheme.SchemeType.ToString()
                };
                schemesAdminDTOs.Add(schemeAdminDTO);
            }
            return schemesAdminDTOs;

        }

        public async Task<MessageDTO> ChangeSchemeActivity(string payload , string routeTitle)
        {
            var scheme = await _schemeRepo.GetByRouteTitle(routeTitle);
            if(payload == "Deactivate")
            {
                scheme.IsActive = false;
            }
            else
            {
                scheme.IsActive = true;
            }
            await _schemeRepo.Update(scheme);
            return new MessageDTO()
            {
                Message = "Scheme Updated ScuessFully"
            };
        }
    }
}
