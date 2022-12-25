using BLL.Converter;
using BLL.DTOs;
using DAL;
using DAL.EF_Code_First.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

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
        public static List<CustumeView_ConfirmInvestDTO> CustumeView_Get_byUserId(int id)
        {
            var data = DataAccessFactory.ConfirmInvestmentDataAccess().Get();
            var list = new List<CustumeView_ConfirmInvestDTO>();
            foreach (var item in data)
            {
                if (item.UserId == id) {
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
                    });
                }
            }
            return list;
        }
        public static CustumeView_ConfirmInvestDTO CustumeView_Get(int id)
        {
            var item = DataAccessFactory.ConfirmInvestmentDataAccess().Get(id);
            if (item != null)
            {
                var investLand = DataAccessFactory.InvestLandsDataAccess().Get(item.LandId);
                var owner = DataAccessFactory.UsersDataAccess().Get(investLand.OwnerId);
                var investor = DataAccessFactory.UsersDataAccess().Get(item.UserId);
                var time = (DateTime)item.InvestTime;
                var I_data = new CustumeView_ConfirmInvestDTO()
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
                };
                return I_data;
            }
            else
                return null;
        }
        public static string Add(int landId, int UserId, double investedAmmount)
        {
            ConfirmInvestmentsDTO dto = new ConfirmInvestmentsDTO() {
                LandId = landId,
                UserId = UserId,
                InvestedAmmount = (float)investedAmmount,
                Status = "inv",
                InvestTime = DateTime.Now
            };
            var res = Convert(dto);
            var investLand = DataAccessFactory.InvestLandsDataAccess().Get(res.LandId);
            var owner = DataAccessFactory.UsersDataAccess().Get(investLand.OwnerId);
            var investor = DataAccessFactory.UsersDataAccess().Get(res.UserId);
            if (investLand != null && owner != null && investor != null)
            {
                if (investLand.Status.Equals("Investable") || investLand.Status.Equals("Verified"))
                {
                    if (owner.Id != investor.Id)
                    {
                        if (investor.Wallet >= dto.InvestedAmmount)
                        {
                            if (investLand.Totalinvestedammount + res.InvestedAmmount <= investLand.Moneyneed)
                            {
                                if(res.InvestedAmmount >= 0)
                                {
                                    //var result = DataAccessFactory.ConfirmInvestmentDataAccess().Add(res);
                                    bool result = true;
                                    if (result != false)
                                    {
                                        var added = investLand.Totalinvestedammount + res.InvestedAmmount;
                                        investLand.Totalinvestedammount = added;
                                        var exe1 = DataAccessFactory.InvestLandsDataAccess().Update1(investLand);
                                        var xe = DataAccessFactory.InvestLandsDataAccess().Get(investLand.Id);
                                        investLand = exe1;
                                        if (exe1 != null)
                                        {
                                            investor.Wallet = investor.Wallet - res.InvestedAmmount;
                                            owner.Wallet = owner.Wallet + res.InvestedAmmount;
                                            var exe4 = DataAccessFactory.UsersDataAccess().Update1(owner);
                                            var exe2 = DataAccessFactory.UsersDataAccess().Update1(investor);
                                            if (exe2 != null)
                                            {
                                                var transaction = new Transaction()
                                                {
                                                    ReceiverId = owner.Id,
                                                    SenderId = res.UserId,
                                                    Ammount = System.Convert.ToSingle(res.InvestedAmmount),
                                                    Type = "Invest in land"
                                                };
                                                var creatingTransaction = DataAccessFactory.TransactionDataAccess().Add(transaction);
                                                if (creatingTransaction != null)
                                                {
                                                    if(investLand.Totalinvestedammount == investLand.Moneyneed)
                                                    {
                                                        investLand.Status = "Complete";
                                                        var exe3 = DataAccessFactory.InvestLandsDataAccess().Update1(investLand);
                                                        if (exe3 != null)
                                                        {
                                                            res.Status = "Complete";
                                                            var resu = DataAccessFactory.ConfirmInvestmentDataAccess().Add(res);
                                                            var closeInvest = new CloseInvest()
                                                            {
                                                                LandId = res.LandId,
                                                                ReturnAmmount = null,
                                                                Status = "In Progress",
                                                                CloseDate = DateTime.Now
                                                            };
                                                            var resu2 = DataAccessFactory.CloseInvestDataAccess().Add(closeInvest);
                                                            if (resu != null && resu2 != null)
                                                            {
                                                                return "Successfully invested in LandId: " + investLand.Id;
                                                            }
                                                            else
                                                                return "Something went wrong while creating confirm investment table";
                                                        }
                                                        else
                                                            return "Something went wrong while updating status in investland";
                                                    }
                                                    else
                                                    {
                                                        investLand.Status = "Investable";
                                                        res.Status = "Investable";
                                                        var exe3 = DataAccessFactory.InvestLandsDataAccess().Update1(investLand);
                                                        var result2 = DataAccessFactory.ConfirmInvestmentDataAccess().Add(res);
                                                        if (exe3 != null)
                                                        {
                                                            if (exe3 != null)
                                                            {
                                                                return "Successfully invested in LandId: " + investLand.Id;
                                                            }
                                                            else
                                                                return "Something went wrong while creating confirm investment table";
                                                        }
                                                        else
                                                            return "Something went wrong while updating status in investland";
                                                    }
                                                }
                                                else
                                                    return "Something went wrong while creating transaction table";
                                            }
                                            else
                                                return "Something went wrong while updating information in user database";
                                        }
                                        else
                                            return "Something went wrong while updating information in invest land database";
                                    }
                                    else
                                        return "Something went wrong while wring information in confirm invest database";
                                }
                                return "You can't invest less then 1 TAKA!";
                            }
                            else
                                return "You can't invest more then total money need in this investment";
                        }
                        else
                            return "You don't have enoung money in your wallet!";
                    }
                    else
                        return "You can't invest in your own land";
                }
                else
                    return "You can't invest in this land because this land is unverified!";
            }
            else
                return "Prodive valid details!";
        }
        public static string Delete(int id)
        {
            var investLand = DataAccessFactory.InvestLandsDataAccess().Get(id);
            var owner = DataAccessFactory.UsersDataAccess().Get(investLand.OwnerId);
            var investor = DataAccessFactory.ConfirmInvestmentDataAccess().Get(owner.Id);
            var confirmInvest = DataAccessFactory.ConfirmInvestmentDataAccess().Get(id);

            if (investLand != null && owner != null && investor != null)
            {
                if (investLand.Status.Equals("Closed"))
                {
                    
                    if (confirmInvest.ReturnedAmmount != null)
                    {
                        var exe1 = DataAccessFactory.ConfirmInvestmentDataAccess().Delete(id);
                        if (exe1)
                        {
                            return "Deleted!";
                        }
                        else
                            return "Problem while deleting information!";
                    }
                    else
                        return "Something went wrong!";
                }
                else
                {
                    return "This land in still collecting money for investment";
                }
            }
            else
                return "Provide valide details";
        }

    }
}
