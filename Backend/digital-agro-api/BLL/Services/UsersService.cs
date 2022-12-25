using BLL.Converter;
using BLL.DTOs;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class UsersService: ConverterService
    {
        public static List<ProtectedUsersDTO> Get()
        {
            var data = DataAccessFactory.UsersDataAccess().Get();
            var list = new List<ProtectedUsersDTO>();
            foreach (var item in data)
            {
                list.Add(ProtectedConvert(item));
            }
            return list;
        }
        public static ProtectedUsersDTO Get(int id)
        {
            var data = DataAccessFactory.UsersDataAccess().Get(id);
            return ProtectedConvert(data);
        }
        public static ProtectedUsersDTO GetbyUsername(string username)
        {
            var data = DataAccessFactory.UsersDataAccess().Get().Where(x=>x.Username == username).SingleOrDefault();
            return ProtectedConvert(data);
        }
        public static UsersDTO Add(UsersDTO dto)
        {
            var res = Convert(dto);
            var result = DataAccessFactory.UsersDataAccess().Add(res);
            return Convert(result);
        }
        public static UsersDTO Update(UsersDTO dto)
        {
            var res = Convert(dto);
            var exe = DataAccessFactory.UsersDataAccess().Get(dto.Id);
            res.Password = exe.Password;
            res.Username = exe.Username;
            res.Wallet = exe.Wallet;
            res.Dob = exe.Dob;
            if(res.District == null)
            {
                res.District = exe.District;
            }
            if (exe != null) 
            {
                var result = DataAccessFactory.UsersDataAccess().Update1(res);
                return Convert(result);
            }
            else
                return null;
        }
        public static string Update(int id, string password, string old)
        {
            var exe = DataAccessFactory.UsersDataAccess().Get(id);
            if (exe != null)
            {
                if (exe.Password == old) 
                {
                    exe.Password = password;
                    var result = DataAccessFactory.UsersDataAccess().Update1(exe);
                    return "Successfully changed password!";
                }
                else
                    return "Wrong old password!";
            }
            else
                return "Unable to find user";
        }
        public static bool Delete(int id)
        {
            var res = Get(id);
            if (res != null)
            {
                var dbData = DataAccessFactory.UsersDataAccess().Delete(id);
                return dbData;
            }
            return false;
        }

    }
}
