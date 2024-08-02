using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Health_Insurance_Application.Models.Enums;
using System.Diagnostics.CodeAnalysis;

namespace Health_Insurance_Application.Models
{
    public class Policy
    {
        [Key]
        public int PolicyId { get; set; }
        public int CustomerId { get; set; }
        [ForeignKey(nameof(CustomerId))]
        public Customer Customer { get; set; }
        public int SchemeId { get; set; }
        [ForeignKey(nameof(SchemeId))]
        public Scheme Scheme { get; set; }
        public DateTime PolicyStartDate { get; set; }
        public DateTime PolicyEndDate { get; set; }
        public float PremiumAmount { get; set; }
        public PaymentFrequencyEnum PaymentFrequency { get; set; } 
        public float QuoteAmount { get; set; }
        public int QuotePaymentTerm { get; set; }
        public DateTime LastPaymentDate { get; set; }
        public DateTime NextPaymentDueDate { get; set; }

        public int CoverageYears { get; set; }
        public DateTime PolicyExpiryDate { get; set; }
        public RenewalStatusEnum RenewalStatus { get; set; }
        public IEnumerable<Payment> Payments { get; set; }
        public IEnumerable<Renewal> Renewals { get; set; }  
        public IEnumerable<FamilyMember> FamilyMembers { get; set; }  
        public IEnumerable<CorporateEmployee> CorporateEmployees { get; set; }  
        public IEnumerable<Claims> Claims { get; set; } 
    }
}
