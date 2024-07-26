using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Health_Insurance_Application.Models.Enums;

namespace Health_Insurance_Application.Models
{
    public class Renewal
    {
        [Key]
        public int RenewalId { get; set; }

        public int PolicyId { get; set; }
        [ForeignKey(nameof(PolicyId))]
        public Policy Policy { get; set; }
        public int CustomerId { get; set; }
        [ForeignKey(nameof(CustomerId))]
        public Customer Customer { get; set; }
        public DateTime RenewalDate { get; set; }
        public DateTime NewPolicyStartDate { get; set; }
        public float NewPremiumAmount { get; set; }
        public PaymentFrequencyEnum NewPaymentFrequency { get; set; }
        public float DiscountApplied { get; set; }

        public RenewalStatusEnum RenewalStatus { get; set;}
    }
}
