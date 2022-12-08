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
    public class ConfirmInvestmentsService:ConverterService
    {
        public static List<ConfirmInvestmentsDTO> Get()
        {
            var data = DataAccessFactory.ConfirmInvestmentDataAccess().Get();
            var list = new List<ConfirmInvestmentsDTO>();
            foreach (var item in data)
            {
                list.Add(Convert(item));
            }
            return list;
        }
        public static ConfirmLeaseDTO Get(int id)
        {
            var data = DataAccessFactory.ConfirmLeaseDataAccess().Get(id);
            return Convert(data);
        }
        public static List<CustumeView_ConfirmInvestDTO> CustumeView_Get()
        {
            var data = DataAccessFactory.ConfirmInvestmentDataAccess().Get();
            var list = new List<CustumeView_ConfirmInvestDTO>();
            foreach(var item in data)
            {
                var investLand = DataAccessFactory.InvestLandsDataAccess().Get(item.LandId);
                var owner = DataAccessFactory.UsersDataAccess().Get(investLand.OwnerId);
                var investor = DataAccessFactory.UsersDataAccess().Get(item.UserId);
                var time = (DateTime)item.InvestTime;
                list.Add(new CustumeView_ConfirmInvestDTO()
                {
                    LandAddress = investLand.Address,
                    WhichCrops = investLand.WhichCrops,
                    TotalMoneyneed = investLand.Moneyneed,
                    Estimatedprofit = investLand.Estimatedprofit,
                    Landsize = investLand.Landsize,
                    LandDiscription = investLand.Discription,
                    LandDistrict = investLand.District,
                    LandStatus = investLand.Status,
                    Status = item.Status,
                    Totalinvestedammount = investLand.Totalinvestedammount,
                    OwnerId = owner.Id,
                    OwnerUsername = owner.Username,
                    OwnerPhone = owner.Phone,
                    OwnerEmail = owner.Email,
                    InvestorId = item.UserId,
                    InvestorUsername = investor.Username,
                    InvestorPhone = investor.Phone,
                    InvestorEmail = investor.Email,
                    LandId = item.LandId,
                    InvestTime = item.InvestTime,
                    ExpectedCompleteTime = investLand.ExpectedCompleteTime,
                    ReturnedAmmount = null,
                    InvestedAmmount = item.InvestedAmmount
                }) ;
            }
            return list;
        }
    }
}
