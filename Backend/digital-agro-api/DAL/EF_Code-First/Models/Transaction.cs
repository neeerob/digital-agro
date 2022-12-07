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
        [ForeignKey("Receiver")]
        public int ReceiverId { get; set; }
        [ForeignKey("Sender")]
        public int SenderId { get; set; }

        [Range(1.0, Double.MaxValue)]
        public float Ammount { get; set; }


        public virtual Users Receiver { get; set; }
        public virtual Users Sender { get; set; }


    }
}
