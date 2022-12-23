using DAL.EF_Code_First.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class CustumeView_CloseInvestDTO
    {
        public int Id { get; set; }
        public int LandId { get; set; }
        public int OwnerId { get; set; }
        public double Profit { get; set; }
        public double Landsize { get; set; }
        public string LandDiscription { get; set; }
        public string LandDistrict { get; set; }
        public string LandStatus { get; set; }
        public string Status { get; set; }
        public double Totalinvestedammount { get; set; }
        public string OwnerUsername { get; set; }
        public string OwnerPhone { get; set; }
        public string OwnerEmail { get; set; }
        public System.DateTime ReturnedTime { get; set; }
        public List<String> Investors = new List<String>();
        public CustumeView_CloseInvestDTO()
        {
            Investors = new List<String>();
        }

    }
}
