namespace Health_Insurance_Application.DTO
{
    public class PremiumCalDTO
    {
        public int SchemeId { get; set; }
        public string PaymentFrequency { get; set; }
        public int QuotedPaymentTerm { get; set; }
        public float QuotedCoverageAmount { get; set; }
    }
}
