using DAL.EF_Code_First.Models;
using DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repos
{
    internal class InvestLandsRepo : Idb, IRepo<InvestLands, int, InvestLands>
    {
        public InvestLands Add(InvestLands obj)
        {
            if (obj != null)
            {
                obj.Status = "Unvarified";
                db.InvestLands.Add(obj);
                obj.Totalinvestedammount = 0;
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
            var find = db.InvestLands.Find(id);
            if (find != null)
            {
                db.InvestLands.Remove(find);
                return db.SaveChanges() > 0;
            }
            else
                return false;
        }

        public List<InvestLands> Get()
        {
            return db.InvestLands.ToList();
        }

        public InvestLands Get(int id)
        {
            if (id != 0)
            {
                return db.InvestLands.Find(id);
            }
            else
                return null;
        }

        public InvestLands Update(InvestLands obj)
        {
            var ext = Get(obj.Id);
            if (ext != null)
            {
                if (ext.Status == "Verified" || ext.Status == "Investable" || ext.Status == "Complete")
                {
                    db.Entry(ext).CurrentValues.SetValues(obj);
                    db.SaveChanges();
                    return obj;
                }
                else
                {
                    obj.Status = ext.Status;
                    obj.Publishtime = ext.Publishtime;
                    obj.Totalinvestedammount = ext.Totalinvestedammount;
                    db.Entry(ext).CurrentValues.SetValues(obj);
                    return obj;
                }
            }
            else
                return null;
        }
        public InvestLands Update1(InvestLands obj)
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
