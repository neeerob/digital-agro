using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class InvestLandsDTO
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public string WhichCrops { get; set; }
        public double Moneyneed { get; set; }
        public double Estimatedprofit { get; set; }
        public double Landsize { get; set; }
        public string Discription { get; set; }
        public string District { get; set; }
        public string Status { get; set; }
        public double Totalinvestedammount { get; set; }
        public int OwnerId { get; set; }
        public System.DateTime Publishtime { get; set; }
        public System.DateTime ExpectedCompleteTime { get; set; }
        public int? GovmentId { get; set; }
    }
}
