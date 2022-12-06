using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class ProtectedUsersDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public System.DateTime Dob { get; set; }
        public string Username { get; set; }
        public string Address { get; set; }
        public string District { get; set; }
        public double Wallet { get; set; }
    }
}
