using Health_Insurance_Application.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace Health_Insurance_Application.Models
{
    public class Claims
    {
        [Key]
        public int ClaimId { get; set; }
        public int PolicyId { get; set; }
        [ForeignKey(nameof(PolicyId))]
        [JsonIgnore]
        public Policy Policy { get; set; }
        public string ClaimReason { get; set; }
        public int CustomerId { get; set; }
        [ForeignKey(nameof(CustomerId))]
        public Customer Customer { get; set; }
        public float AmountClaimed { get; set; }
        public float AmountApproved { get; set; }
        [AllowNull]
        public int? ApprovedBy { get; set; }
        [ForeignKey(nameof(ApprovedBy))]
        public Admin Admin { get; set; }
        public ClaimStatusEnum ClaimStatus { get; set; }

        public DateTime ClaimedDate { get; set; }
        public DateTime AcceptedDate { get; set; }
    }
}
