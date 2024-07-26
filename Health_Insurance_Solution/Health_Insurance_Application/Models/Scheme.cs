using Health_Insurance_Application.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace Health_Insurance_Application.Models
{
    public class Scheme
    {
        [Key]
        public int SchemeId { get; set; }
        public string SchemeName { get; set; }
        public string SchemeDescription { get; set; }
        public float CoverageAmount { get; set; }

        public SchemeTypeEnum SchemeType { get; set; }

        public float BasePremiumAmount { get; set; }
    }
}
