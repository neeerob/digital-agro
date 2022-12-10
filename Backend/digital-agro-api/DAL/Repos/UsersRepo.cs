using DAL.EF_Code_First.Models;
using DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repos
{
    internal class UsersRepo : Idb, IRepo<Users, int, Users>
    {
        public Users Add(Users obj)
        {
            if (obj != null)
            {
                if (db.Users.Where(x => x.Username.Equals(obj.Username)).Count() == 0 && obj.Password.Length > 9)
                {
                    obj.Wallet = 0;
                    db.Users.Add(obj);
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
                var transaction = new Transaction()
                {
                    ReceiverId = obj.Id,
                    SenderId = obj.Id,
                    Ammount = System.Convert.ToSingle(obj.Wallet),
                    Type = "Deposit"
                };
                var creatingTransaction = DataAccessFactory.TransactionDataAccess().Add(transaction);
                db.Entry(ext).CurrentValues.SetValues(obj);
                db.SaveChanges();
                return obj;
            }
            else
                return null;
        }
    }
}
