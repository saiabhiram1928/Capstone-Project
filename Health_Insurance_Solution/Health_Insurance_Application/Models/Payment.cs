using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Health_Insurance_Application.Models
{
    public class Payment
    {
        [Key]
        public int Id { get; set; } 
        public int TransactionId { get; set; }

        public int PolicyId { get; set; }
        [ForeignKey(nameof(PolicyId))]
        public Policy Policy { get; set; }
        public int CustomerId { get; set; }
        [ForeignKey(nameof(CustomerId))]
        public Customer Customer { get; set; }
        public DateTime PaymentDate { get; set; }
        public string PaymentStatus { get; set; }
        public string Remarks { get; set; }
        public float PaymentAmount { get; set; }   
        public bool PaymentDone { get; set; }
        public bool PaymentDueDate { get; set; }
    }
}
