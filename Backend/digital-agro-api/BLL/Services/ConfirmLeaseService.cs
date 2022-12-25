using BLL.Converter;
using BLL.DTOs;
using DAL;
using DAL.EF_Code_First.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class ConfirmLeaseService:ConverterService
    {
        public static List<ConfirmLeaseDTO> Get()
        {
            var data = DataAccessFactory.ConfirmLeaseDataAccess().Get();
            var list = new List<ConfirmLeaseDTO>();
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
        public static List<CustumeView_ConfirmLeaseDTO> CustumeView_Get()
        {
            var data = DataAccessFactory.ConfirmLeaseDataAccess().Get();
            var list = new List<CustumeView_ConfirmLeaseDTO>();
            foreach(var item in data)
            {
                var leaseLand = DataAccessFactory.LeaseLandsDataAccess().Get(item.LandId);
                var owner = DataAccessFactory.UsersDataAccess().Get(leaseLand.OwnerId);
                var newOwner = DataAccessFactory.UsersDataAccess().Get(item.UserId);
                var time = (DateTime)item.CreatedDate;
                list.Add(new CustumeView_ConfirmLeaseDTO()
                {
                    Id = item.Id,
                    OwnerId = leaseLand.OwnerId,
                    OwnerUsername = owner.Username,
                    OwnerPhone = owner.Phone,
                    OwnerEmail = owner.Email,
                    LandId = item.LandId,
                    NewOwnerId = newOwner.Id,
                    NewOwnerUsername = newOwner.Username,
                    NewOwnerPhone = newOwner.Phone,
                    NewOwnerEmail = newOwner.Email,
                    Price = leaseLand.Price,
                    OwnerName = owner.Name,
                    NewOwnerName = newOwner.Name,
                    LeasedTime = time,
                    ExpareLeaseTime = time.AddMonths(leaseLand.Period),
                    LandAddress = leaseLand.Address,
                    District = leaseLand.District,
                    LandSize = leaseLand.Landsize,
                    LandDiscription = leaseLand.Discription,
                    Status = leaseLand.Status
                }); 
            }
            return list;
        }

        public static List<CustumeView_ConfirmLeaseDTO> CustumeView_Get_byUserId(int id)
        {
            var data = DataAccessFactory.ConfirmLeaseDataAccess().Get();
            var list = new List<CustumeView_ConfirmLeaseDTO>();
            foreach (var item in data)
            {
                if (item.UserId == id)
                {
                    var leaseLand = DataAccessFactory.LeaseLandsDataAccess().Get(item.LandId);
                    var owner = DataAccessFactory.UsersDataAccess().Get(leaseLand.OwnerId);
                    var newOwner = DataAccessFactory.UsersDataAccess().Get(item.UserId);
                    var time = (DateTime)item.CreatedDate;
                    list.Add(new CustumeView_ConfirmLeaseDTO()
                    {
                        Id = item.Id,
                        OwnerId = leaseLand.OwnerId,
                        OwnerUsername = owner.Username,
                        OwnerPhone = owner.Phone,
                        OwnerEmail = owner.Email,
                        LandId = item.LandId,
                        NewOwnerId = newOwner.Id,
                        NewOwnerUsername = newOwner.Username,
                        NewOwnerPhone = newOwner.Phone,
                        NewOwnerEmail = newOwner.Email,
                        Price = leaseLand.Price,
                        OwnerName = owner.Name,
                        NewOwnerName = newOwner.Name,
                        LeasedTime = time,
                        ExpareLeaseTime = time.AddMonths(leaseLand.Period),
                        LandAddress = leaseLand.Address,
                        District = leaseLand.District,
                        LandSize = leaseLand.Landsize,
                        LandDiscription = leaseLand.Discription,
                        Status = leaseLand.Status
                    });
                }
            }
            return list;
        }


        public static CustumeView_ConfirmLeaseDTO CustumeView_Get(int id)
        {
            var item = DataAccessFactory.ConfirmLeaseDataAccess().Get(id);
            if (item != null)
            {
                var leaseLand = DataAccessFactory.LeaseLandsDataAccess().Get(item.LandId);
                var owner = DataAccessFactory.UsersDataAccess().Get(leaseLand.OwnerId);
                var newOwner = DataAccessFactory.UsersDataAccess().Get(item.UserId);
                var time = (DateTime)item.CreatedDate;
                var c_data = new CustumeView_ConfirmLeaseDTO()
                {
                    Id = item.Id,
                    OwnerId = leaseLand.OwnerId,
                    OwnerUsername = owner.Username,
                    OwnerPhone = owner.Phone,
                    OwnerEmail = owner.Email,
                    LandId = item.LandId,
                    NewOwnerId = newOwner.Id,
                    NewOwnerUsername = newOwner.Username,
                    NewOwnerPhone = newOwner.Phone,
                    NewOwnerEmail = newOwner.Email,
                    Price = leaseLand.Price,
                    OwnerName = owner.Name,
                    NewOwnerName = newOwner.Name,
                    LeasedTime = time,
                    ExpareLeaseTime = time.AddMonths(leaseLand.Period),
                    LandAddress = leaseLand.Address,
                    District = leaseLand.District,
                    LandSize = leaseLand.Landsize,
                    LandDiscription = leaseLand.Discription,
                    Status = leaseLand.Status
                };
                return c_data;
            }
            else
                return null;
        }
        public static string Add(ConfirmLeaseDTO dto)
        {
            var res = Convert(dto);
            var leaseLand = DataAccessFactory.LeaseLandsDataAccess().Get(res.LandId);
            var owner = DataAccessFactory.UsersDataAccess().Get(leaseLand.OwnerId);
            var newOwner = DataAccessFactory.UsersDataAccess().Get(res.UserId);
            if (leaseLand != null && owner != null && newOwner != null)
            {
                if (res.UserId != leaseLand.OwnerId)
                {
                    if (newOwner.Wallet >= leaseLand.Price)
                    {
                        if (leaseLand.Status.Equals("Verified") || leaseLand.Status.Equals("Varified"))
                        {
                            if (!leaseLand.Status.Equals("Leased"))
                            {
                                owner.Wallet = owner.Wallet + leaseLand.Price;
                                newOwner.Wallet = newOwner.Wallet - leaseLand.Price;
                                var exe1 = DataAccessFactory.UsersDataAccess().Update1(owner);
                                var exe2 = DataAccessFactory.UsersDataAccess().Update1(newOwner);
                                if (exe1 != null && exe2 != null)
                                {
                                    var result = DataAccessFactory.ConfirmLeaseDataAccess().Add(res);
                                    if (result != null)
                                    {
                                        var transaction = new Transaction()
                                        {
                                            ReceiverId = owner.Id,
                                            SenderId = newOwner.Id,
                                            Ammount = System.Convert.ToSingle(leaseLand.Price),
                                            Type = "Leased land"
                                        };
                                        var creatingTransaction = DataAccessFactory.TransactionDataAccess().Add(transaction);
                                        if (creatingTransaction != null)
                                        {
                                            leaseLand.Status = "Leased";
                                            var changeLand = DataAccessFactory.LeaseLandsDataAccess().Update1(leaseLand);
                                            return "Successfully leased IandId:" + dto.LandId + " from " + owner.Username;
                                        }
                                        else
                                            return "Problem in creating data Transaction table!";

                                    }
                                    else
                                        return "Something wrong in creating data in table";
                                }
                                else
                                    return "Problem in transaction!";
                            }
                            else
                                return "This land is alrady leased";
                        }
                        else
                            return "You can't lease this land because this land is unverified!";
                    }
                    else
                        return "You don't have enough money in your wallet!";
                }
                else
                    return "You can't lease your own land!";
            }
            else
                return "Provide valid details!";
        }
        public static bool Delete(int id)
        {
            var confirmLease = DataAccessFactory.ConfirmLeaseDataAccess().Get(id);
            var leaseLand = DataAccessFactory.LeaseLandsDataAccess().Get(confirmLease.LandId);
            var owner = DataAccessFactory.UsersDataAccess().Get(leaseLand.OwnerId);
            var newOwner = DataAccessFactory.UsersDataAccess().Get(confirmLease.UserId);
            var createTime = confirmLease.CreatedDate;
            var time = (DateTime)confirmLease.CreatedDate;
            if (time.AddMonths(leaseLand.Period) >= DateTime.Now)
            {
                leaseLand.Period = 0;
                leaseLand.Status = "Verified";
                var exe1 = DataAccessFactory.LeaseLandsDataAccess().Update1(leaseLand);
                if (exe1 != null)
                {
                    var exe2 = DataAccessFactory.ConfirmLeaseDataAccess().Delete(id);
                    return true;
                }
                else
                    return false;
            }
            else
                return false;
        }
    }
}
