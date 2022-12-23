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
    public class InvestLandsService:ConverterService
    {
        public static List<InvestLandsDTO> Get()
        {
            var data = DataAccessFactory.InvestLandsDataAccess().Get();
            var list = new List<InvestLandsDTO>();
            foreach (var item in data)
            {
                list.Add(Convert(item));
            }
            return list;
        }
        public static List<InvestLandsDTO> GetAvailableInvest()
        {
            var data = DataAccessFactory.InvestLandsDataAccess().Get();
            var list = new List<InvestLandsDTO>();
            foreach (var item in data)
            {
                if (item.Status.Equals("Verified") || item.Status.Equals("Verified") || item.Status.Equals("Investable")) 
                {
                    list.Add(Convert(item)); 
                }
            }
            return list;
        }
        public static List<InvestLandsDTO> GetCompleted()
        {
            var data = DataAccessFactory.InvestLandsDataAccess().Get();
            var list = new List<InvestLandsDTO>();
            foreach (var item in data)
            {
                if (item.Status.Equals("Complete"))
                {
                    list.Add(Convert(item));
                }
            }
            return list;
        }

        public static InvestLandsDTO Get(int id)
        {
            var data = DataAccessFactory.InvestLandsDataAccess().Get(id);
            return Convert(data);
        }
        public static InvestLandsDTO Add(InvestLandsDTO dto)
        {
            var res = Convert(dto);
            var result = DataAccessFactory.InvestLandsDataAccess().Add(res);
            return Convert(result);
        }
        public static InvestLandsDTO Update(InvestLandsDTO dto)
        {
            var res = Convert(dto);
            var result = DataAccessFactory.InvestLandsDataAccess().Update(res);
            return Convert(result);
        }
        public static bool Delete(int id)
        {
            var res = Get(id);
            if (res != null)
            {
                var dbData = DataAccessFactory.InvestLandsDataAccess().Delete(id);
                return dbData;
            }
            return false;
        }
    }
}
