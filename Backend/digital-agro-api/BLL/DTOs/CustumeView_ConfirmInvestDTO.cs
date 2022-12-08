using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class CustumeView_ConfirmInvestDTO
    {
        public int Id { get; set; }
        public string LandAddress { get; set; }
        public string WhichCrops { get; set; }
        public double TotalMoneyneed { get; set; }
        public double Estimatedprofit { get; set; }
        public double Landsize { get; set; }
        public string LandDiscription { get; set; }
        public string LandDistrict { get; set; }
        public string LandStatus { get; set; }
        public string Status { get; set; }
        public double Totalinvestedammount { get; set; }
        public int OwnerId { get; set; }
        public string OwnerUsername { get; set; }
        public string OwnerPhone { get; set; }
        public string OwnerEmail { get; set; }
        public int InvestorId { get; set; }
        public string InvestorUsername { get; set; }
        public string InvestorPhone { get; set; }
        public string InvestorEmail { get; set; }
        public int LandId { get; set; }
        public System.DateTime InvestTime { get; set; }
        public System.DateTime ExpectedCompleteTime { get; set; }
        public double? ReturnedAmmount { get; set; }
        public double InvestedAmmount { get; set; }

    }
}
