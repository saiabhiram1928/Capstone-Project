namespace Health_Insurance_Application.DTO
{
    public class AdminClaimDTO
    {
        public int ClaimId { get; set; }    
        public int CustomerId { get; set; }
        public string CustomerEmail { get; set; }
        public DateTime ClaimAppliedOn {  get; set; }
        public float ClaimAmount { get; set; }
        public string ClaimStatus { get; set; }
    }
}
