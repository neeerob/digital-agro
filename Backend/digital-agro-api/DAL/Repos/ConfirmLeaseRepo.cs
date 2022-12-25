using DAL.EF_Code_First.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class ConfirmLeaseRepo : Idb, IRepo<ConfirmLease, int, ConfirmLease>
    {
        public ConfirmLease Add(ConfirmLease obj)
        {
            if (obj != null)
            {
                db.ConfirmLeases.Add(obj);
                obj.CreatedDate = DateTime.Now;
                if (db.SaveChanges() > 0)
                    return obj;
                else
                    return null;
            }
            else
                return null;
        }

        public bool Delete(int id)
        {
            var find = db.ConfirmLeases.Find(id);
            if (find != null)
            {
                db.ConfirmLeases.Remove(find);
                return db.SaveChanges() > 0;
            }
            else
                return false;
        }

        public List<ConfirmLease> Get()
        {
                return db.ConfirmLeases.ToList();
        }

        public ConfirmLease Get(int id)
        {
            if (id != 0)
            {
                return db.ConfirmLeases.Find(id);
            }
            else
                return null;
        }

        public ConfirmLease Update1(ConfirmLease obj)
        {

            var ext = Get(obj.Id);
            if (ext != null)
            {
                db.Entry(ext).CurrentValues.SetValues(obj);
                db.SaveChanges();
                return obj;
            }
            else
                return null;
        }
    }
}
