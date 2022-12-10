using BLL.Converter;
using BLL.DTOs;
using DAL;
using DAL.EF_Code_First.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class CloseInvestService : ConverterService
    {
        public static List<CloseInvestDTO> Get()
        {
            var data = DataAccessFactory.CloseInvestDataAccess().Get();
            var list = new List<CloseInvestDTO>();
            foreach (var item in data)
            {
                list.Add(Convert(item));
            }
            return list;
        }
        public static CloseInvestDTO Get(int id)
        {
            var data = DataAccessFactory.CloseInvestDataAccess().Get(id);
            return Convert(data);
        }
        public static List<CustumeView_CloseInvestDTO> CustumeView_Get()
        {
            var data = DataAccessFactory.CloseInvestDataAccess().Get();
            var list = new List<CustumeView_CloseInvestDTO>();
            foreach (var item in data)
            {
                var investLand = DataAccessFactory.InvestLandsDataAccess().Get(item.LandId);
                var owner = DataAccessFactory.UsersDataAccess().Get(investLand.OwnerId);
                //var newOwner = DataAccessFactory.UsersDataAccess().Get(item.UserId);
                //var time = (DateTime)item.CloseDate;
                var confirmInvest = DataAccessFactory.ConfirmInvestmentDataAccess().Get().Where(x => x.LandId == item.LandId).ToList();
                var res = confirmInvest.Select(x => x.UserId).ToList();
                var investors = new List<Users>();
                foreach(var i in res)
                {
                    var investor = DataAccessFactory.UsersDataAccess().Get(i);
                    investors.Add(investor);
                }
                list.Add(new CustumeView_CloseInvestDTO()
                {
                    LandId = item.LandId,
                    OwnerId = owner.Id,
                    Profit = (double)item.ReturnAmmount,
                    Landsize = investLand.Landsize,
                    LandDiscription = investLand.Discription,
                    LandDistrict = investLand.District,
                    Status = item.Status,
                    Totalinvestedammount = investLand.Totalinvestedammount,
                    OwnerUsername = owner.Username,
                    OwnerPhone = owner.Phone,
                    OwnerEmail = owner.Email,
                    ReturnedTime = item.CloseDate,
                    Investors = investors
                });
            }
            return list;
        }
        public static CustumeView_CloseInvestDTO CustumeView_Get(int id)
        {
            var data = DataAccessFactory.CloseInvestDataAccess().Get(id);
            if (data != null)
            {
                var investLand = DataAccessFactory.InvestLandsDataAccess().Get(data.LandId);
                var owner = DataAccessFactory.UsersDataAccess().Get(investLand.OwnerId);
                var confirmInvest = DataAccessFactory.ConfirmInvestmentDataAccess().Get().Where(x => x.LandId == data.LandId).ToList();
                var res = confirmInvest.Select(x => x.UserId).ToList();
                var investors = new List<Users>();
                foreach (var i in res)
                {
                    var investor = DataAccessFactory.UsersDataAccess().Get(i);
                    investors.Add(investor);
                }
                var c_data = new CustumeView_CloseInvestDTO()
                {
                    LandId = data.LandId,
                    OwnerId = owner.Id,
                    Profit = (double)data.ReturnAmmount,
                    Landsize = investLand.Landsize,
                    LandDiscription = investLand.Discription,
                    LandDistrict = investLand.District,
                    Status = data.Status,
                    Totalinvestedammount = investLand.Totalinvestedammount,
                    OwnerUsername = owner.Username,
                    OwnerPhone = owner.Phone,
                    OwnerEmail = owner.Email,
                    ReturnedTime = data.CloseDate,
                    Investors = investors
                };
                return c_data;
            }
            else
                return null;
        }
        public static string Update(CloseInvestDTO dto)
        {
            var find = DataAccessFactory.CloseInvestDataAccess().Get(dto.Id);
            if (find != null)
            {
                dto.LandId = find.LandId;
                dto.Status = "Paid;";
                dto.CloseDate = DateTime.Now;
                var investLand = DataAccessFactory.InvestLandsDataAccess().Get(find.LandId);
                var owner = DataAccessFactory.UsersDataAccess().Get(investLand.OwnerId);
                var confirmInvest = DataAccessFactory.ConfirmInvestmentDataAccess().Get().Where(x => x.LandId == find.LandId).ToList();
                var res = confirmInvest.Select(x => x.UserId).ToList();
                var investors = new List<Users>();
                if (dto.ReturnAmmount >= 0)
                {
                    if (owner.Wallet >= dto.ReturnAmmount)
                    {
                        //Calclution
                        var net_profit = dto.ReturnAmmount - investLand.Totalinvestedammount;
                        foreach (var i in confirmInvest)
                        {
                            var rInvestors = DataAccessFactory.UsersDataAccess().Get(i.UserId);
                            var recAmmount = ((net_profit / i.InvestedAmmount) * i.InvestedAmmount);
                            rInvestors.Wallet = rInvestors.Wallet + recAmmount;
                            owner.Wallet = owner.Wallet - recAmmount;
                            var ex1 = DataAccessFactory.UsersDataAccess().Update(owner);
                            var ex2 = DataAccessFactory.UsersDataAccess().Update(rInvestors);
                            var transaction = new Transaction()
                            {
                                ReceiverId = rInvestors.Id,
                                SenderId = owner.Id,
                                Ammount = (float)recAmmount,
                                Type = "Returning investment profit"
                            };
                            var creatingTransaction = DataAccessFactory.TransactionDataAccess().Add(transaction);
                            var con = new CloseInvest()
                            {
                                Id = dto.Id,
                                LandId = dto.LandId,
                                Status = dto.Status,
                                CloseDate = dto.CloseDate,
                                ReturnAmmount = dto.ReturnAmmount
                            };
                            var cr = DataAccessFactory.CloseInvestDataAccess().Update(con);
                        }
                        investLand.Status = "Verified";
                        var ex3 = DataAccessFactory.InvestLandsDataAccess().Update(investLand);
                        return "Complete!";
                    }
                    else
                        return "You don't have enough money to clear this land!";

                }
                else
                    return "Return ammount is less then 0";

            }
            else
                return "Invalid id";
        }
    }
}
