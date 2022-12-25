using DAL.EF_Code_First.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class Token_GovmentRepo :Idb, IRepo<Token_Govment, string, Token_Govment>
    {
        public Token_Govment Add(Token_Govment obj)
        {
            var find = db.GovmentOfficial.Where(a => a.Username == obj.Username).FirstOrDefault();
            obj.logId = find.Id;
            if (obj != null)
            {
                db.Token_Govment.Add(obj);
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
            var find = db.Token_Govment.Find(id);
            if (find != null)
            {
                db.Token_Govment.Remove(find);
                return db.SaveChanges() > 0;
            }
            else
                return false;
        }

        public List<Token_Govment> Get()
        {
            return db.Token_Govment.ToList();
        }

        public Token_Govment Get(string id)
        {
            return db.Token_Govment.FirstOrDefault(t => t.TKey.Equals(id));
        }

        public Token_Govment Update1(Token_Govment obj)
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
