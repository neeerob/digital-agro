using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF_Code_First.Models
{
    public class LeaseLands
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Address is required")]
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
    }
}
