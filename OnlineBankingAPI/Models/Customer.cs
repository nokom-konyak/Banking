using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OnlineBankingAPI.Models
{
    public class Customer
    {
        [Key]
        public long AccountNumber { get; set; }
        [Required]
        [StringLength(50)]
        public string Password { get; set; }
        [Required]
        [StringLength(100)]
        public string CustomerName { get; set; }

        [Required]
        [StringLength(100)]
        public string FatherName { get; set; }
        [Required]

        public long MobNo { get; set; }
        [StringLength(100)]
        public string Email { get; set; }
        [Required]
        [StringLength(50)]
        public string AadharNo { get; set; }
        [Required]
        public DateTime DOB { get; set; }
        public string ResAddress { get; set; }
        public string PerAddress { get; set; }
        [Required]
        [StringLength(100)]
        public string OccupationType { get; set; }
        public long Balance { get; set; }

        [Required]
        [StringLength(100)]

        public string IncomeSource { get; set; }
        [Required]
        public long TotalIncome { get; set; }
        [Required]
        public bool Status { get; set; }

        [NotMapped]
        public virtual ICollection<Transaction> Transaction { get; set; }
        [NotMapped]
        public virtual ICollection<Beneficiary> Beneficiary { get; set; }
    }
}
