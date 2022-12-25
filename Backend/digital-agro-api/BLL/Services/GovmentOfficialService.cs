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
    public class GovmentOfficialService:ConverterService
    {
        public static List<ProtectedGovmentOfficialDTO> Get()
        {
            var data = DataAccessFactory.GovmentOfficialDataAccess().Get();
            var list = new List<ProtectedGovmentOfficialDTO>();
            foreach (var item in data)
            {
                list.Add(ProtectedConvert(item));
            }
            return list;
        }
        public static ProtectedGovmentOfficialDTO Get(int id)
        {
            var data = DataAccessFactory.GovmentOfficialDataAccess().Get(id);
            return ProtectedConvert(data);
        }
        public static GovmentOfficialDTO Add(GovmentOfficialDTO dto)
        {
            var res = Convert(dto);
            var result = DataAccessFactory.GovmentOfficialDataAccess().Add(res);
            return Convert(result);
        }
        public static GovmentOfficialDTO Update(GovmentOfficialDTO dto)
        {
            var res = Convert(dto);
            var exe = DataAccessFactory.GovmentOfficialDataAccess().Get(res.Id);
            res.Username = exe.Username;
            res.Password = exe.Password;
            res.District = exe.District;
            var result = DataAccessFactory.GovmentOfficialDataAccess().Update1(res);
            return Convert(result);
        }

        public static string Update(int id, string password, string old)
        {
            var exe = DataAccessFactory.GovmentOfficialDataAccess().Get(id);
            if (exe != null)
            {
                if (exe.Password == old)
                {
                    exe.Password = password;
                    var result = DataAccessFactory.GovmentOfficialDataAccess().Update1(exe);
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
                var dbData = DataAccessFactory.GovmentOfficialDataAccess().Delete(id);
                return dbData;
            }
            return false;
        }

    }
}
