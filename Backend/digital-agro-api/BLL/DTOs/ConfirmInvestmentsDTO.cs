using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class ConfirmInvestmentsDTO
    {
        public int Id { get; set; }
        public int LandId { get; set; }
        public int UserId { get; set; }
        public float InvestedAmmount { get; set; }
        public float? ReturnedAmmount { get; set; }
        public string Status { get; set; }
        public System.DateTime InvestTime { get; set; }
    }
}
