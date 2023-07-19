using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OnlineBankingAPI.Models
{
    public class Beneficiary
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long BenAccount { get; set; }

        public long? AccountNumber { get; set; }
        [ForeignKey("AccountNumber")]
        public virtual Customer? Customer { get; set; }

        [Required]
        [StringLength(50)]
        public string BenName { get; set; }

        [StringLength(100)]


        public string BenNickname { get; set; }
    }
}
