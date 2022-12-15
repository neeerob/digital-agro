using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF_Code_First.Models
{
    public class Admins
    {
        public int Id { get; set; }

        [StringLength(25)]
        [Required]
        public string Name { get; set; }

        [Required]
        [StringLength(14)]
        //[RegularExpression("^(?!0+$)(\\+\\d{1,3}[- ]?)?(?!0+$)\\d{10,15}$", ErrorMessage = "Please enter valid phone no.")]
        public string Phone { get; set; }
        [Required]
        [RegularExpression(@"^[^@\s]+@[^@\s]+\.(com|net|org|gov|edu)$")]
        public string Email { get; set; }
        [Required]
        public System.DateTime Dob { get; set; }
        [Required]
        [StringLength(15)]
        public string Username { get; set; }
        [Required]
        [StringLength(255, MinimumLength = 8)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public virtual List<GovmentOfficial> GovmentOfficial { get; set; }
        public Admins()
        {
            GovmentOfficial = new List<GovmentOfficial>();
        }
    }
}
