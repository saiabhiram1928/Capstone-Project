using Health_Insurance_Application.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace Health_Insurance_Application.DTO
{
    public class UserRegisterDTO
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [MinLength(8)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$",
        ErrorMessage = "Password must be at least 8 characters long and contain at least one uppercase letter, one lowercase letter, one number, and one special character.")]
        public string Password { get; set; }
        [Required]
        public string Street { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public string Zipcode { get; set; }
        [Required]
        public string MobileNumber { get; set; }

        public DateTime DateOfBirth { get; set; }
        public GenderEnum Gender { get; set; }
        [Phone]
        public string EmergenceyContact { get; set; } =string.Empty;
        public int HosiptalId { get; set; }
        [Phone]
        public string AgentContact { get; set; }  = string.Empty;   

    }
}
