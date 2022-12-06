using DAL.EF_Code_First.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class UsersRepo : Idb, IRepo<Users, int, Users>
    {
        public Users Add(Users obj)
        {
            if (obj != null)
            {
                db.Users.Add(obj);
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
            var find = db.Users.Find(id);
            if (find != null)
            {
                db.Users.Remove(find);
                return db.SaveChanges() > 0;
            }
            else
                return false;
        }
        public List<Users> Get()
        {
            return db.Users.ToList();
        }
        public Users Get(int id)
        {
            if (id != 0)
            {
                return db.Users.Find(id);
            }
            else
                return null;
        }
        public Users Update(Users obj)
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
