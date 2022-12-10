using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class CloseInvestDTO
    {
        public int Id { get; set; }
        public int LandId { get; set; }
        public double ReturnAmmount { get; set; }
        public string Status { get; set; }
        public DateTime CloseDate { get; set; }
    }
}
