using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class CustumeView_ConfirmLeaseDTO
    {
        public int Id { get; set; }
        public int OwnerId { get; set; }
        public string OwnerUsername { get; set; }
        public string  OwnerPhone { get; set; }
        public string OwnerEmail { get; set; }
        public int LandId { get; set; }
        public int NewOwnerId { get; set; }
        public string NewOwnerUsername { get; set; }
        public string NewOwnerPhone { get; set; }
        public string NewOwnerEmail { get; set; }
        public double Price { get; set; }
        public string OwnerName { get; set; }
        public string NewOwnerName { get; set; }
        public DateTime LeasedTime { get; set; }
        public DateTime ExpareLeaseTime { get; set; }
        public string LandAddress { get; set; }
        public string District { get; set; }
        public double LandSize { get; set; }
        public string LandDiscription { get; set; }
        public string Status { get; set; }

    }
}
