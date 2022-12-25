using DAL.EF_Code_First.Models;
using DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repos
{
    internal class UsersRepo : Idb, IRepo<Users, int, Users>, IAuthenticate<Users, Users>, ICritical<int, double>
    {
        public Users Add(Users obj)
        {
            if (obj != null)
            {
                if (obj.Name != null && obj.Name.Length > 5 && obj.Email != null && obj.Phone != null && obj.Phone.Length >= 11)
                {
                    if (db.Users.Where(x => x.Username.Equals(obj.Username)).Count() == 0 && obj.Password.Length >= 8)
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
                else
                    return null;
            }
            return null;
        }

        public Users Authenticate(string username, string password)
        {
            var find = db.Users.Where(x => x.Username == username && x.Password == password).SingleOrDefault();
            if (find != null)
            {
                return find;
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
        public Users Update1(Users obj)
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
                //var creatingTransaction = DataAccessFactory.TransactionDataAccess().Add(transaction);
                db.Entry(ext).CurrentValues.SetValues(obj);
                db.SaveChanges();
                return obj;
            }
            else
                return null;
        }

        public bool Withdraw(int id, double amm)
        {
            var ext = Get(id);
            if (ext != null)
            {
                ext.Wallet = amm;
                db.Entry(ext).CurrentValues.SetValues(ext);
                db.SaveChanges();
                return true;
            }
            else
                return false;
        }
    }
}
