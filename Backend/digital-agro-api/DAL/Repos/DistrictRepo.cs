using DAL.EF_Code_First.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class DistrictRepo : Idb, IRepo<District, int, District>
    {
        public District Add(District obj)
        {
            if (obj != null)
            {
                db.District.Add(obj);
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
            var find = db.District.Find(id);
            if (find != null)
            {
                db.District.Remove(find);
                return db.SaveChanges() > 0;
            }
            else
                return false;
        }

        public List<District> Get()
        {
            return db.District.ToList();
        }

        public District Get(int id)
        {
            if (id != 0)
            {
                return db.District.Find(id);
            }
            else
                return null;
        }

        public District Update1(District obj)
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
