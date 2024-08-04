    using Health_Insurance_Application.Models.Enums;
    using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

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

                public DateTime SchemeStartedAt { get; set; }
                public DateTime SchemeLastUpdatedAt {  get; set; }

                public string RouteTitle { get; set; }

                 public string SmallDescription { get; set; }
                 public bool IsActive { get; set; } = true;

                 public int PaymentTerm {  get; set; }    
                public int CoverageYears { get; set; } 
                public float BaseCoverageAmount { get; set; } 
        [JsonIgnore]
               public IList<Policy> Policies { get; set; }
        }
    }
