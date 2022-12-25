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
        public static List<InvestLandsDTO> GetAvailableInvest(int id)
        {
            var data = DataAccessFactory.InvestLandsDataAccess().Get();
            var list = new List<InvestLandsDTO>();
            foreach (var item in data)
            {
                if ((item.Status.Equals("Unverified") || item.Status.Equals("Unvarified")) && item.GovmentId == id)
                {
                    list.Add(Convert(item));
                }
            }
            return list;
        }

        //assign gov by admin
        public static List<InvestLandsDTO> GetUnAvailableLeasedLand()
        {
            var data = DataAccessFactory.InvestLandsDataAccess().Get();
            var list = new List<InvestLandsDTO>();
            foreach (var item in data)
            {
                if ((item.Status.Equals("Unerified") || item.Status.Equals("Unerified") || item.Status.Equals("Unverified") || item.Status.Equals("Unvarified")) && item.GovmentId == null)
                {
                    list.Add(Convert(item));
                }
            }
            return list;
        }

        //done verified now view
        public static List<InvestLandsDTO> GetCompletedByGovId(int id)
        {
            var data = DataAccessFactory.InvestLandsDataAccess().Get();
            var list = new List<InvestLandsDTO>();
            foreach (var item in data)
            {
                if ((item.Status.Equals("Verified") || item.Status.Equals("Verified") || item.Status.Equals("Investable")) && item.GovmentId == id)
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

        public static List<InvestLandsDTO> GetCompleted(int id)
        {
            var data = DataAccessFactory.InvestLandsDataAccess().Get();
            var list = new List<InvestLandsDTO>();
            foreach (var item in data)
            {
                if (item.OwnerId == id)
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
            dto.Status = "Unverified";
            dto.Publishtime = DateTime.Now;
            var res = Convert(dto);
            var result = DataAccessFactory.InvestLandsDataAccess().Add(res);
            return Convert(result);
        }
        public static InvestLandsDTO Update(InvestLandsDTO dto)
        {
            var res = Convert(dto);
            var result = DataAccessFactory.InvestLandsDataAccess().Update1(res);
            return Convert(result);
        }

        public static InvestLandsDTO VerifyByGovment(int id, int govId)
        {
            var res = DataAccessFactory.InvestLandsDataAccess().Get(id);
            if (res.GovmentId == govId && (res.Status.Equals("Unvarified") || res.Status.Equals("Unverified")))
            {
                res.Status = "Verified";
                var result = DataAccessFactory.InvestLandsDataAccess().Update1(res);
                return Convert(result);
            }
            else
                return null;
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

        //Assigning gov to land for verifiing by admin
        public static string UpdateVerification(int landId, int govId)
        {
            var ex1 = DataAccessFactory.InvestLandsDataAccess().Get(landId);
            var ex3 = DataAccessFactory.GovmentOfficialDataAccess().Get(govId);
            if (ex1 != null || ex3 != null)
            {
                ex1.GovmentId = ex3.Id;
                var ex2 = DataAccessFactory.InvestLandsDataAccess().Update1(ex1);
                if (ex2 != null)
                {
                    return "Successfully assigned " + ex3.Username + " to invest landId: " + ex1.Id;
                }
                else
                    return "Unsuccessfull";
            }
            return "Unsuccessfull";
        }
    }
}
