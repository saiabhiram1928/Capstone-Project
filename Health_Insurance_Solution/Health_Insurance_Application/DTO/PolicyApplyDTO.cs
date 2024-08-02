namespace Health_Insurance_Application.DTO
{
    public class PolicyApplyDTO
    {
        public int schemeId { get; set; }
        public float CoverageAmount { get; set; }
        public int PaymentTerm { get; set; }
        public List<FamilyMemberDTO> FamilyMembers { get; set; }
        public List<CorporateMemberDTO> CorporateMembers { get; set; }
        public string PaymentFrequency { get; set; }  
        public string Opt { get; set; }
    }

    public class FamilyMemberDTO
    {
        public string Name { get; set; }
        public string AdharId { get; set; }
    }

    public class CorporateMemberDTO
    {
        public string Name { get; set; }
        public string EmpId { get; set; }
    }
}
