using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF_Code_First.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        [StringLength(10)]
        public string Type { get; set; }
        [ForeignKey("R_User")]
        public int ReceiverId { get; set; }
        [ForeignKey("S_User")]
        public int SenderId { get; set; }

        [Range(1.0, Double.MaxValue)]
        [Required]
        public float Ammount { get; set; }
        [Required]
        public System.DateTime TransactionTime { get; set; }

        public virtual Users R_User { get; set; }
        public virtual Users S_User { get; set; }


    }
}
