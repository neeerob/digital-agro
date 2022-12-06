using DAL.EF_Code_First;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    internal class Idb
    {
        protected AgroContext db;
        protected Idb()
        {
            db = new AgroContext();
        }
    }
}
