using DAL.EF_Code_First.Models;
using DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repos
{
    internal class AdminRepo : Idb, IRepo<Admins, int, Admins>, IAuthenticate<Admins, Admins>
    {
        public Admins Add(Admins obj)
        {
            if (obj != null)
            {
                if (obj.Name != null && obj.Name.Length > 5 && obj.Email != null && obj.Phone != null && obj.Phone.Length >=11) {
                    if (db.Admins.Where(x => x.Username.Equals(obj.Username)).Count() == 0 && obj.Password.Length >= 8)
                    {
                        db.Admins.Add(obj);
                        try
                        {
                            var trying = db.SaveChanges() > 0;
                            if (trying)
                                return obj;
                            else
                                return null;
                        }
                        catch
                        {
                            return null;
                        }
                    }
                    return null;
                }
                else
                    return null;
            }
            else
                return null;
        }

        public Admins Authenticate(string username, string password)
        {
            var find = db.Admins.Where(x => x.Username == username && x.Password == password).SingleOrDefault();
            if (find != null)
            {
                return find;
            }
            else
                return null;
        }

        public bool Delete(int id)
        {
            var find = db.Admins.Find(id);
            if (find != null)
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

        public Admins Update1(Admins obj)
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
