using DAL.EF_Code_First.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class Token_AdminRepo : Idb, IRepo<Token_Admin, string, Token_Admin>
    {
        public Token_Admin Add(Token_Admin obj)
        {
            if (obj != null)
            {
                var find = db.Admins.Where(a => a.Username == obj.Username).FirstOrDefault();
                obj.logId = find.Id;
                db.Token_Admin.Add(obj);
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
            var find = db.Token_Admin.Find(id);
            if (find != null)
            {
                db.Token_Admin.Remove(find);
                return db.SaveChanges() > 0;
            }
            else
                return false;
        }

        public List<Token_Admin> Get()
        {
            return db.Token_Admin.ToList();
        }

        public Token_Admin Get(string id)
        {
            return db.Token_Admin.FirstOrDefault(t => t.TKey.Equals(id));
        }

        public Token_Admin Update1(Token_Admin obj)
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
