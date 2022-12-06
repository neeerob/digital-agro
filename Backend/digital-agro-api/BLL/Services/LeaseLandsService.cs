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
    public class LeaseLandsService:ConverterService
    {
        public static List<LeaseLandsDTO> Get()
        {
            var data = DataAccessFactory.LeaseLandsDataAccess().Get();
            var list = new List<LeaseLandsDTO>();
            foreach (var item in data)
            {
                list.Add(Convert(item));
            }
            return list;
        }
        public static LeaseLandsDTO Get(int id)
        {
            var data = DataAccessFactory.LeaseLandsDataAccess().Get(id);
            return Convert(data);
        }
        public static LeaseLandsDTO Add(LeaseLandsDTO dto)
        {
            var res = Convert(dto);
            res.Status = "Unvarified";
            res.Publishtime = DateTime.Now;
            var result = DataAccessFactory.LeaseLandsDataAccess().Add(res);
            return Convert(result);
        }
        public static LeaseLandsDTO Update(LeaseLandsDTO dto)
        {
            var res = Convert(dto);
            var result = DataAccessFactory.LeaseLandsDataAccess().Update(res);
            return Convert(result);
        }
        public static bool Delete(int id)
        {
            var res = Get(id);
            if (res != null)
            {
                var dbData = DataAccessFactory.LeaseLandsDataAccess().Delete(id);
                return dbData;
            }
            return false;
        }
    }
}
