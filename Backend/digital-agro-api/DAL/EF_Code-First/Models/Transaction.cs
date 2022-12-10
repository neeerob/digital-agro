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
        [Key]
        public int Id { get; set; }
        [StringLength(35)]
        public string Type { get; set; }
        public int ReceiverId { get; set; }
        public int SenderId { get; set; }

        [Range(1.0, Double.MaxValue)]
        [Required]
        public float Ammount { get; set; }
        [Required]
        public System.DateTime TransactionTime { get; set; }



    }
}
