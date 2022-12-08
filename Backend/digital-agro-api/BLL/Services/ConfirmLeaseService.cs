﻿using BLL.Converter;
using BLL.DTOs;
using DAL;
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

    }
}
