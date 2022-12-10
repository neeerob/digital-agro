using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF_Code_First.Models
{
    public class CloseInvest
    {
        public int Id { get; set; }
        [Required]
        public int LandId { get; set; }
        [Required]
        public double? ReturnAmmount { get; set; }
        public string Status { get; set; }
        public DateTime CloseDate { get; set; }

    }
}
