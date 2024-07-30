using Microsoft.AspNetCore.Mvc;

namespace Health_Insurance_Application.DTO
{
    public class PremiumReturnDTO
    {
       public float CoverageAmount { get; set; }
        public float BaseCoverageAmount { get; set; }
        public int PaymentTerm { get; set; }
        public float QuotedCovergaeAmount { get; set; }
        public int QuotedPaymentTerm { get; set; }
        public float Premium { get; set; }
        public string PaymentFrequency { get; set; }

        public int  CalCoverageYears { get; set; }
        public int ActCoverageYears {  get; set; }
    }
}
