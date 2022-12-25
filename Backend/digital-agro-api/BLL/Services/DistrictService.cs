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
    public class DistrictService:ConverterService
    {
        public static List<DistrictDTO> Get()
        {
            var data = DataAccessFactory.DistrictDataAccess().Get();
            var list = new List<DistrictDTO>();
            foreach (var item in data)
            {
                list.Add(Convert(item));
            }
            return list;
        }
        public static DistrictDTO Get(int id)
        {
            var data = DataAccessFactory.DistrictDataAccess().Get(id);
            return Convert(data);
        }
        public static DistrictDTO Add(DistrictDTO dto)
        {
            var res = Convert(dto);
            var result = DataAccessFactory.DistrictDataAccess().Add(res);
            return Convert(result);
        }
        public static DistrictDTO Update(DistrictDTO dto)
        {
            var res = Convert(dto);
            var result = DataAccessFactory.DistrictDataAccess().Update1(res);
            return Convert(result);
        }
        public static bool Delete(int id)
        {
            var res = Get(id);
            if (res != null)
            {
                var dbData = DataAccessFactory.DistrictDataAccess().Delete(id);
                return dbData;
            }
            return false;
        }
    }
}
