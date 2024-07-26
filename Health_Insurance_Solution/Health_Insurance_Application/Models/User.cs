using Health_Insurance_Application.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace Health_Insurance_Application.Models
{
    public class User
    {
        [Key]
        public int Uid { get; set; }

        [Required]  
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public byte[] Password { get; set; }
        [Required]
        public byte[] Salt { get; set; }
        public RoleEnum Role { get ; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zipcode { get; set; }
        public string MobileNumber { get; set; }
        public DateTime CreatedAt { get; set; } 
        public DateTime LastUpdated { get; set; }
    }
}
