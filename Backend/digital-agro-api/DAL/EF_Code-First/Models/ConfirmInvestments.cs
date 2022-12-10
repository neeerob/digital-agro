using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF_Code_First.Models
{
    public class ConfirmInvestments
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [ForeignKey("InvestLands")]
        public int LandId { get; set; }
        [Required]
        [ForeignKey("Users")]
        public int UserId { get; set; }
        [Required]
        public float InvestedAmmount { get; set; }
        public float? ReturnedAmmount { get; set; }
        [Required]
        [StringLength(10)]
        public string Status { get; set; }
        [Required]
        public System.DateTime InvestTime { get; set; }

        public virtual Users Users { get; set; }
        public virtual InvestLands InvestLands { get; set; }

    }
}
