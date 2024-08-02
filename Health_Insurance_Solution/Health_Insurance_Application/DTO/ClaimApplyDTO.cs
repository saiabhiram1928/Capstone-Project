namespace Health_Insurance_Application.DTO
{
    public class ClaimApplyDTO
    {
        public float ClaimAmount { get; set; }
        public string ClaimReason { get; set; }
        public int SchemeId { get; set; }
        public int PolicyId { get; set; }   
    }
}
