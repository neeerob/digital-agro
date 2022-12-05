using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF_Code_First.Models
{
    public class Users
    {
        public int Id { get; set; }
        [StringLength(25)]
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Mobile no. is required")]
        [StringLength(14)]
        //[RegularExpression("^(?!0+$)(\\+\\d{1,3}[- ]?)?(?!0+$)\\d{10,15}$", ErrorMessage = "Please enter valid phone no.")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [RegularExpression(@"^[^@\s]+@[^@\s]+\.(com|net|org|gov|edu)$", ErrorMessage = "Invalid email.")]
        public string Email { get; set; }
        [Required]
        public System.DateTime Dob { get; set; }
        [Required]
        [StringLength(15)]
        public string Username { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [StringLength(255, ErrorMessage = "Must be between 8 and 255 characters", MinimumLength = 8)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Address is required")]
        [StringLength(50)]
        public string Address { get; set; }
        [Required]
        [StringLength(15)]
        public string District { get; set; }
        [Required]
        public double Wallet { get; set; }

        public virtual List<LeaseLands> LeaseLands { get; set; }
        public virtual List<InvestLands> InvestLands { get; set; }
        public virtual List<ConfirmLease> ConfirmLease { get; set; }
        public virtual List<ConfirmInvestments> ConfirmInvestments { get; set; }

        public Users()
        {
            LeaseLands = new List<LeaseLands>();
            InvestLands = new List<InvestLands>();
            ConfirmInvestments = new List<ConfirmInvestments>();
            ConfirmLease = new List<ConfirmLease>();
        }
    }
}
