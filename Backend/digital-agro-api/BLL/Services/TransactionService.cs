﻿using BLL.Converter;
using BLL.DTOs;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class TransactionService : ConverterService
    {
        public static List<TransactionDTO> Get()
        {
            var data = DataAccessFactory.TransactionDataAccess().Get();
            var list = new List<TransactionDTO>();
            foreach (var item in data)
            {
                list.Add(Convert(item));
            }
            return list;
        }

        public static List<CustumeView_TransactionDTO> CustumeView_Get()
        {
            var data = DataAccessFactory.TransactionDataAccess().Get();
            var list = new List<CustumeView_TransactionDTO>();
            foreach(var item in data)
            {
                list.Add(new CustumeView_TransactionDTO()
                {
                    Id = item.Id,
                    Type = item.Type,
                    ReceiverId = item.ReceiverId,
                    SenderId = item.SenderId,
                    Ammount = item.Ammount,
                    ReceiverName = DataAccessFactory.UsersDataAccess().Get(item.ReceiverId).Name,
                    SenderName = DataAccessFactory.UsersDataAccess().Get(item.SenderId).Name,
                    ReceiverUsername = DataAccessFactory.UsersDataAccess().Get(item.ReceiverId).Username,
                    SenderUsername = DataAccessFactory.UsersDataAccess().Get(item.SenderId).Username, 
                    TransactionTime = item.TransactionTime
                });
            }
            return list;
        }
        public static TransactionDTO Get(int id)
        {
            var data = DataAccessFactory.TransactionDataAccess().Get(id);
            return Convert(data);
        }

        public static CustumeView_TransactionDTO CustumeView_Get(int id)
        {
            var data = DataAccessFactory.TransactionDataAccess().Get(id);
            if (data != null)
            {
                var C_data = new CustumeView_TransactionDTO()
                {
                    Id = data.Id,
                    Type = data.Type,
                    ReceiverId = data.ReceiverId,
                    SenderId = data.SenderId,
                    Ammount = data.Ammount,
                    ReceiverName = DataAccessFactory.UsersDataAccess().Get(data.ReceiverId).Name,
                    SenderName = DataAccessFactory.UsersDataAccess().Get(data.SenderId).Name,
                    ReceiverUsername = DataAccessFactory.UsersDataAccess().Get(data.ReceiverId).Username,
                    SenderUsername = DataAccessFactory.UsersDataAccess().Get(data.SenderId).Username,
                    TransactionTime = data.TransactionTime
                };
                return C_data;
            }
            else
                return null;
        }
        public static TransactionDTO Add(TransactionDTO dto)
        {
            var res = Convert(dto);
            var senderData = DataAccessFactory.UsersDataAccess().Get(res.SenderId);
            var recevierData = DataAccessFactory.UsersDataAccess().Get(res.ReceiverId);
            res.TransactionTime = DateTime.Now;

            if (senderData != null && recevierData != null)
            {
                if (res.SenderId == res.ReceiverId)
                {
                    if (res.Type.Equals("Deposit"))
                    {
                        senderData.Wallet = senderData.Wallet + res.Ammount;
                        var exe = DataAccessFactory.UsersDataAccess().Update(senderData);
                        if (exe != null)
                        {
                            var result = DataAccessFactory.TransactionDataAccess().Add(res);
                            return Convert(result);
                        }
                        else
                            return null;
                    }
                    else
                        return null;
                }
                else
                {
                    if (res.Type.Equals("Transaction"))
                    {
                        if(senderData.Wallet >= res.Ammount)
                        {
                            senderData.Wallet = senderData.Wallet - res.Ammount;
                            recevierData.Wallet = recevierData.Wallet + res.Ammount;
                            var exe1 = DataAccessFactory.UsersDataAccess().Update(senderData);
                            var exe2 = DataAccessFactory.UsersDataAccess().Update(recevierData);
                            if (exe1 != null && exe2 != null)
                            {
                                var result = DataAccessFactory.TransactionDataAccess().Add(res);
                                return Convert(result);
                            }
                            else
                                return null; 
                        }
                        else
                            return null;
                    }
                    else
                        return null;
                }
            }
            else
            {
                return null;
            }
        }
        //Update will not used because admin don't have the authority to aulter transfer data;
        public static TransactionDTO Update(TransactionDTO dto)
        {
            var res = Convert(dto);
            var senderData = DataAccessFactory.UsersDataAccess().Get(res.SenderId);
            var recevierData = DataAccessFactory.UsersDataAccess().Get(res.ReceiverId);

            if (senderData != null && recevierData != null)
            {
                if (res.SenderId == res.ReceiverId)
                {
                    if (res.Type.Equals("Deposit"))
                    {
                        senderData.Wallet = senderData.Wallet + res.Ammount;
                        var exe = DataAccessFactory.UsersDataAccess().Update(senderData);
                        if (exe != null)
                        {
                            var result1 = DataAccessFactory.TransactionDataAccess().Update(res);
                            return Convert(result1);
                        }
                        else
                            return null;
                    }
                    else
                        return null;
                }
                else
                {
                    if (res.Type.Equals("Transaction"))
                    {
                        if (senderData.Wallet >= res.Ammount)
                        {
                            senderData.Wallet = senderData.Wallet - res.Ammount;
                            recevierData.Wallet = recevierData.Wallet + res.Ammount;
                            var exe1 = DataAccessFactory.UsersDataAccess().Update(senderData);
                            var exe2 = DataAccessFactory.UsersDataAccess().Update(recevierData);
                            if (exe1 != null && exe2 != null)
                            {
                                var result1 = DataAccessFactory.TransactionDataAccess().Update(res);
                                return Convert(result1);
                            }
                            else
                                return null;
                        }
                        else
                            return null;
                    }
                    else
                        return null;
                }
            }
            else
            {
                return null;
            }
        }

        //Concel Transaction
        public static TransactionDTO Cancel(int id)
        {
            var res = Convert(Get(id));
            var senderData = DataAccessFactory.UsersDataAccess().Get(res.SenderId);
            var recevierData = DataAccessFactory.UsersDataAccess().Get(res.ReceiverId);

            if (res.TransactionTime <= DateTime.Now.AddHours(1.0))
            {
                if (senderData != null && recevierData != null)
                {
                    if (res.SenderId == res.ReceiverId)
                    {
                        if (res.Type.Equals("Deposit"))
                        {
                            if (recevierData.Wallet >= res.Ammount)
                            {
                                senderData.Wallet = senderData.Wallet - res.Ammount;
                                var exe = DataAccessFactory.UsersDataAccess().Update(senderData);
                                if (exe != null)
                                {
                                    var result = DataAccessFactory.TransactionDataAccess().Delete(res.Id);
                                    if (result)
                                    {
                                        return Convert(res);
                                    }
                                    else
                                        return null;
                                }
                                else
                                    return null;
                            }
                            else
                                return null;
                        }
                        else
                            return null;
                    }
                    else
                    {
                        if (res.Type.Equals("Transaction"))
                        {
                            if (senderData.Wallet >= res.Ammount)
                            {
                                senderData.Wallet = senderData.Wallet + res.Ammount;
                                recevierData.Wallet = recevierData.Wallet - res.Ammount;
                                var exe1 = DataAccessFactory.UsersDataAccess().Update(senderData);
                                var exe2 = DataAccessFactory.UsersDataAccess().Update(recevierData);
                                if (exe1 != null && exe2 != null)
                                {
                                    var result = DataAccessFactory.TransactionDataAccess().Delete(res.Id);
                                    if (result)
                                    {
                                        return Convert(res);
                                    }
                                    return null;

                                }
                                else
                                    return null;
                            }
                            else
                                return null;
                        }
                        else
                            return null;
                    }
                }
                else
                    return null;
            }
            else
                return null;

        }
    }
}