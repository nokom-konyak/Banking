using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OnlineBankingAPI.Models
{
    public class InternetBanking
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long AccNo { get; set; }
        [Required]
        [StringLength(50)]
        public string LoginPwd { get; set; }
        [Required]
        [StringLength(50)]
        public string TranPwd { get; set; }
    }
}
