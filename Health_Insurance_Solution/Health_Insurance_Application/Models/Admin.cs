using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Health_Insurance_Application.Models
{
    public class Admin
    {
        [Key]
        public int AdminId { get; set; }

        public int Uid { get; set; }
        [ForeignKey(nameof(Uid))]
        public User User { get; set; }


    }
}
