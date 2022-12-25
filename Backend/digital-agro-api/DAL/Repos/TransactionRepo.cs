using DAL.EF_Code_First.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class TransactionRepo : Idb, IRepo<Transaction, int, Transaction>
    {
        public Transaction Add(Transaction obj)
        {
            if (obj != null)
            {
                obj.TransactionTime = DateTime.Now;
                db.Transaction.Add(obj);
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
            var find = db.Transaction.Find(id);
            if (find != null)
            {
                db.Transaction.Remove(find);
                return db.SaveChanges() > 0;
            }
            else
                return false;
        }

        public List<Transaction> Get()
        {
            return db.Transaction.ToList();
        }

        public Transaction Get(int id)
        {
            if (id != 0)
            {
                return db.Transaction.Find(id);
            }
            else
                return null;
        }

        public Transaction Update1(Transaction obj)
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
