namespace Health_Insurance_Application.DTO
{
    public class PolicyAnalyticsDTO
    {
        public List<int> WeekData { get; set; }
        public List<int> MonthData { get; set; }
        public List<SchemesAnalyticsDTO> SchemesAnalyticsDTOs { get; set; } 
        public int PoliciesAppliedinMonth { get; set; }
        public int PoliciesAppliedinWeek { get; set; }
        public string MostApplied { get; set; }
        public int ClaimsAppledinMonth { get; set; }

    }

    public class SchemesAnalyticsDTO
    {
        public string schemeName { get; set; }
        public int schemeId { get; set; }
        public int Count { get; set; }
        public string SchemeCategory { set; get; }
    }
}
