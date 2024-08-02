using Health_Insurance_Application.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Health_Insurance_Application.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        public int Uid { get; set; }
        [ForeignKey(nameof(Uid))]
        public User User { get; set; }
        [Phone]
        public string EmergenceyContact { get; set; }
        [JsonIgnore]
        public IEnumerable<Policy> Policies { get; set; }
        [JsonIgnore]    
        public IEnumerable<Payment> Payments { get; set; }
        [JsonIgnore]
        public IEnumerable<Renewal> Renewals { get; set; }   
        

    }
}
