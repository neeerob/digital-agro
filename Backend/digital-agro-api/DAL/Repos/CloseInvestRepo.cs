using DAL.EF_Code_First.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repos
{
    internal class CloseInvestRepo : Idb, IRepo<CloseInvest, int, CloseInvest>
    {
        public CloseInvest Add(CloseInvest obj)
        {
            if (obj != null)
            {
                obj.CloseDate = DateTime.Now;
                db.CloseInvest.Add(obj);
                obj.Status = "In process";
                obj.ReturnAmmount = 0;
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
            var find = db.CloseInvest.Find(id);
            if (find != null)
            {
                db.CloseInvest.Remove(find);
                return db.SaveChanges() > 0;
            }
            else
                return false;
        }

        public List<CloseInvest> Get()
        {
            return db.CloseInvest.ToList();
        }

        public CloseInvest Get(int id)
        {
            if (id != 0)
            {
                return db.CloseInvest.Find(id);
            }
            else
                return null;
        }

        public CloseInvest Update1(CloseInvest obj)
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
