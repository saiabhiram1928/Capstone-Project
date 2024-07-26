namespace Health_Insurance_Application.Models
{
    public class Hospital
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Street { get; set; }
        public string City { get; set; }    
        public string State { get; set; }
        public int Zipcode { get; set; }
        public string BranchCode { get; set; }

        public IEnumerable<HospitalAgent> Agents { get; set; }
    }
}
