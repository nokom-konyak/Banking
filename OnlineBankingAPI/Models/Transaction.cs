using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OnlineBankingAPI.Models
{
    public class Transaction
    {
        [Key]
        public int ReferenceId { get; set; }
        [Required]
        public string Mode { get; set; }
        [Required]
        public long? AccountNumber { get; set; }
        [ForeignKey("AccountNumber")]
        public virtual Customer? Customer { get; set; }
        [Required]
        public long AccountTo { get; set; }
        [Required]
        public long Amount { get; set; }
        [Required]
        public DateTime TranDate { get; set; }

        public string Remarks { get; set; }
    }
}
