using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Health_Insurance_Application.Models
{
    public class FamilyMember
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string AadharId { get; set; }
        public int PolicyId { get; set; }
        [ForeignKey(nameof(PolicyId))]
        [JsonIgnore]
        public Policy Policy { get; set; }
    }
}
