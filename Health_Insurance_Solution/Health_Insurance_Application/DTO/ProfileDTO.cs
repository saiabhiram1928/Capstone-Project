using Health_Insurance_Application.Models.Enums;

namespace Health_Insurance_Application.DTO
{
    public class ProfileDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }    
        public string MobileNumber { get; set; }    
        public string Email { get; set; }   
        public string Address { get; set; }
        public string Zipcode { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public DateTime LastUpdatedAt { get; set; }
        public DateTime CreatedAt {  get; set; }    
    }
}
