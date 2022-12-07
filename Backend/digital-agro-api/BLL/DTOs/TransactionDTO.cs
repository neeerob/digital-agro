using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class TransactionDTO
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public int ReceiverId { get; set; }
        public int SenderId { get; set; }
        public float Ammount { get; set; }
        public System.DateTime TransactionTime { get; set; }
    }
}
