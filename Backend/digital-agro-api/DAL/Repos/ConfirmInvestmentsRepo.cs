using DAL.EF_Code_First.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repos
{
    internal class ConfirmInvestmentsRepo : Idb, IRepo<ConfirmInvestments, int, ConfirmInvestments>
    {
        public ConfirmInvestments Add(ConfirmInvestments obj)
        {
            if (obj != null)
            {
                obj.InvestTime = DateTime.Now;
                obj.ReturnedAmmount = 0;
                db.ConfirmInvestments.Add(obj);
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
            var find = db.ConfirmInvestments.Find(id);
            if (find != null)
            {
                db.ConfirmInvestments.Remove(find);
                return db.SaveChanges() > 0;
            }
            else
                return false;
        }

        public List<ConfirmInvestments> Get()
        {
            return db.ConfirmInvestments.ToList();
        }

        public ConfirmInvestments Get(int id)
        {
            if (id != 0)
            {
                return db.ConfirmInvestments.Find(id);
            }
            else
                return null;
        }

        public ConfirmInvestments Update1(ConfirmInvestments obj)
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
