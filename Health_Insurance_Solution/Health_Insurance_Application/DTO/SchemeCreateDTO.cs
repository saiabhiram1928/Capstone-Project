using Health_Insurance_Application.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace Health_Insurance_Application.DTO
{
    public class SchemeCreateDTO
    {
        public string SchemeName { get; set; }
        public string SchemeDescription { get; set; }
        public float CoverageAmount { get; set; }

        public SchemeTypeEnum SchemeType { get; set; }

        public float BasePremiumAmount { get; set; }
        public string RouteTitle { get; set; }

        public string SmallDescription { get; set; }
        public int PaymentTerm { get; set; }    
        public int CoverageYears { get; set; }
        public float BaseCoverageAmount { get; set; } 
    }
}
