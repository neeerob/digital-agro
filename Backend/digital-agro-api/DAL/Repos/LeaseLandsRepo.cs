using DAL.EF_Code_First.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class LeaseLandsRepo : Idb, IRepo<LeaseLands, int, LeaseLands>
    {
        public LeaseLands Add(LeaseLands obj)
        {
            if (obj != null)
            {
                obj.Status = "Unvarified";
                db.LeaseLands.Add(obj);
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
            var find = db.LeaseLands.Find(id);
            if (find != null)
            {
                db.LeaseLands.Remove(find);
                return db.SaveChanges() > 0;
            }
            else
                return false;
        }

        public List<LeaseLands> Get()
        {
            return db.LeaseLands.ToList();
        }

        public LeaseLands Get(int id)
        {
            if (id != 0)
            {
                return db.LeaseLands.Find(id);
            }
            else
                return null;
        }

        public LeaseLands Update1(LeaseLands obj)
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
