using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF_Code_First.Models
{
    public class LeaseLands
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Address { get; set; }
        [Required]
        public string District { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public double Landsize { get; set; }
        [Required,StringLength(150)]
        public string Discription { get; set; }
        [Required,StringLength(15)]
        public string Status { get; set; }
        [Required]
        [ForeignKey("Users")]
        public int OwnerId { get; set; }

        [Required]
        public System.DateTime Publishtime { get; set; }
        [ForeignKey("GovmentOfficial")]
        public int? GovmentId { get; set; }
        [Required]
        public int Period { get; set; }
        

        public virtual GovmentOfficial GovmentOfficial { get; set; }
        public virtual Users Users { get; set; }
        public virtual List<ConfirmLease> ConfirmLease { get; set; }

        public LeaseLands()
        {
            ConfirmLease = new List<ConfirmLease>();
        }

    }
}
