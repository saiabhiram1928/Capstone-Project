using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;

namespace Health_Insurance_Application.Models
{
    public class HospitalAgent
    {
        [Key]
        public int AgentId { get; set; }
        public int Uid { get; set; }
        [ForeignKey(nameof(AgentId))]
        public User User { get; set; }
        [Phone]
        public string AgentContact { get; set; }

        public int HosiptalId {  get; set; }
        [ForeignKey(nameof(HosiptalId))]
        public Hospital Hosiptal { get; set; }
    }
}
