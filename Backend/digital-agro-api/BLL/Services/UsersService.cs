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
        public static UsersDTO Add(UsersDTO dto)
        {
            var res = Convert(dto);
            var result = DataAccessFactory.UsersDataAccess().Add(res);
            return Convert(result);
        }
        public static UsersDTO Update(UsersDTO dto)
        {
            var res = Convert(dto);
            var result = DataAccessFactory.UsersDataAccess().Update(res);
            return Convert(result);
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
