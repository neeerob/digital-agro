using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF_Code_First.Models
{
    public class InvestLands
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Address { get; set; }
        [Required]
        public string WhichCrops { get; set; }
        [Required]
        public double Moneyneed { get; set; }
        [Required]
        public double Estimatedprofit { get; set; }
        [Required]
        public double Landsize { get; set; }
        [Required,StringLength(150)]
        public string Discription { get; set; }
        [Required]
        public string District { get; set; }
        [Required]
        public string Status { get; set; }
        public double Totalinvestedammount { get; set; }
        [Required]
        [ForeignKey("Users")]
        public int OwnerId { get; set; }
        [Required]
        public System.DateTime Publishtime { get; set; }
        [Required]
        public System.DateTime ExpectedCompleteTime { get; set; }
        [ForeignKey("GovmentOfficial")]
        public int? GovmentId { get; set; }

        public virtual GovmentOfficial GovmentOfficial { get; set; }

        public virtual Users Users { get; set; }
        public virtual List<ConfirmInvestments> ConfirmInvestments { get; set; }
        public InvestLands()
        {
            ConfirmInvestments = new List<ConfirmInvestments>();
        }
    }
}
