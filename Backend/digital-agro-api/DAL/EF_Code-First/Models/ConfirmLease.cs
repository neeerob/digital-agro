using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF_Code_First.Models
{
    public class ConfirmLease
    {
        public int Id { get; set; }
        [Required]
        [ForeignKey("LeaseLands")]
        public int LandId { get; set; }
        [Required]
        [ForeignKey("Users")]
        public int UserId { get; set; }
        [Required]
        public DateTime? CreatedDate { get; set; }

        public virtual Users Users { get; set; }
        public virtual LeaseLands LeaseLands { get; set; }

    }
}
