using BLL.Converter;
using BLL.DTOs;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BLL.Services
{
    public class AdminService : ConverterService
    {
        public static List<ProtectedAdminDTO> Get()
        {
            var data = DataAccessFactory.AdminDataAccess().Get();
            var list = new List<ProtectedAdminDTO>();
            foreach (var item in data)
            {
                list.Add(ProtectedConvert(item));
            }
            return list;
        }
        public static ProtectedAdminDTO Get(int id)
        {
            var data = DataAccessFactory.AdminDataAccess().Get(id);
            return ProtectedConvert(data);
        }
        public static AdminDTO Add(AdminDTO dto)
        {
            var res = Convert(dto);
            var result = DataAccessFactory.AdminDataAccess().Add(res);
            return Convert(result);
        }
        public static AdminDTO Update(AdminDTO dto)
        {
            var res = Convert(dto);
            var result = DataAccessFactory.AdminDataAccess().Update(res);
            return Convert(result);
        }
        public static bool Delete(int id)
        {
            var res = Get(id);
            if (res != null)
            {
                var dbData = DataAccessFactory.AdminDataAccess().Delete(id);
                return dbData;
            }
            return false;
        }
    }
}
