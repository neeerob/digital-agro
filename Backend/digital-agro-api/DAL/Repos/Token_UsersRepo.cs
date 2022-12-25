using DAL.EF_Code_First.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class Token_UsersRepo : Idb, IRepo<Token_Users, string, Token_Users>
    {
        public Token_Users Add(Token_Users obj)
        {
            if (obj != null)
            {
                var find = db.Users.Where(a => a.Username == obj.Username).FirstOrDefault();
                obj.logId = find.Id;
                db.Token_Users.Add(obj);
                if (db.SaveChanges() > 0)
                    return obj;
                else
                    return null;
            }
            else
                return null;
        }

        public bool Delete(string id)
        {
            var find = db.Token_Users.Find(id);
            if (find != null)
            {
                db.Token_Users.Remove(find);
                return db.SaveChanges() > 0;
            }
            else
                return false;
        }

        public List<Token_Users> Get()
        {
            return db.Token_Users.ToList();
        }

        public Token_Users Get(string id)
        {
            return db.Token_Users.FirstOrDefault(t => t.TKey.Equals(id));
        }

        public Token_Users Update1(Token_Users obj)
        {
            var ext = Get(obj.TKey);
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
