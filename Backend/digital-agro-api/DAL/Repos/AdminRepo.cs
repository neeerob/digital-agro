using DAL.EF_Code_First.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class AdminRepo : Idb, IRepo<Admins, int, Admins>
    {
        public Admins Add(Admins obj)
        {
            if (obj != null)
            {
                if (db.Admins.Where(x=>x.Username.Equals(obj.Username)).Count() == 0) {
                    db.Admins.Add(obj);
                    if (db.SaveChanges() > 0)
                        return obj;
                    else
                        return null;
                }
                return null;
            }
            else
                return null;
        }

        public bool Delete(int id)
        {
            var find = db.Admins.Find(id);
            if(find != null)
            {
                db.Admins.Remove(find);
                return db.SaveChanges() > 0;
            }
            else
                return false;
        }

        public List<Admins> Get()
        {
            return db.Admins.ToList();
        }

        public Admins Get(int id)
        {
            if (id != 0)
            {
                return db.Admins.Find(id);
            }
            else
                return null;
        }

        public Admins Update(Admins obj)
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
