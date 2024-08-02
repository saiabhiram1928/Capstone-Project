using Health_Insurance_Application.Models;

namespace Health_Insurance_Application.DTO
    {
        public class PolicyReturnDTO
        {
            public int PolicyId { get; set; }
           public Scheme Scheme { get; set; }
          public DateTime PolicyStartDate {  get; set; }
         public DateTime PolicyEndDate { get; set; }
          public float PremiumAmount { get; set; }
        public float QuoteAmount { get; set; }
        public DateTime LastPaymentDate { get; set; }
        public DateTime NextPaymentDueDate { get; set; }
        public DateTime policyExpiryDate { get; set; }
        public string RenewalStatus { get; set; }
         public IList<FamilyMember> FamilyMembers { get; set; }
         public IList<CorporateEmployee> CorporateEmployees { get; set; }
         public IList<Claims> Claims { get; set; }

        public IList<Payment> Payments { get; set; }    

        public IList<Renewal> Renewals { get; set; }


        }
    }
