using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.CustumeView
{
    public class CustumeVide_TransactionRecDTO
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public int UserId { get; set; }
        public float Ammount { get; set; }
        public string UserName { get; set; }
        public string UserUsername { get; set; }
        public System.DateTime TransactionTime { get; set; }
    }
}
