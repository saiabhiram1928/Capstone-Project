using Health_Insurance_Application.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Health_Insurance_Application.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        public int Uid { get; set; }
        [ForeignKey(nameof(Uid))]
        public User User { get; set; }

        public DateTime DateOfBirth { get; set; }
        public GenderEnum Gender { get; set; }
        [Phone]
        public string EmergenceyContact { get; set; }
        public IEnumerable<Policy> Policies { get; set; }   
        public IEnumerable<Payment> Payments { get; set; }   
        public IEnumerable<Renewal> Renewals { get; set; }   
        

    }
}
