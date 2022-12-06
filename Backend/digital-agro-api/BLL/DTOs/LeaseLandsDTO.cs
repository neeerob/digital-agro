using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class LeaseLandsDTO
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public string District { get; set; }
        public double Price { get; set; }
        public double Landsize { get; set; }
        public string Discription { get; set; }
        public string Status { get; set; }
        public int OwnerId { get; set; }
        public System.DateTime Publishtime { get; set; }
        public int? GovmentId { get; set; }
        public int Period { get; set; }
    }
}
