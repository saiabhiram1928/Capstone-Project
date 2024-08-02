using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Health_Insurance_Application.Models
{
    public class CorporateEmployee
    {
        public int Id { get; set; } 
        public string EmployeeName { get; set; }
        public string EmployeeId { get; set; }

        public int PolicyId { get; set; }
        [ForeignKey(nameof(PolicyId))]
        [JsonIgnore]
        public Policy Policy { get; set; }

    }
}
