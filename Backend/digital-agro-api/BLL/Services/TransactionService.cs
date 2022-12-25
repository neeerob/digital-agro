using BLL.Converter;
using BLL.CustumeView;
using BLL.DTOs;
using DAL;
using DAL.EF_Code_First.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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

        //here
        public static List<CustumeView_TransactionDTO> CustumeView_GetDeposit()
        {
            var data = DataAccessFactory.TransactionDataAccess().Get();
            var list = new List<CustumeView_TransactionDTO>();
            foreach (var item in data)
            {
                if (item.Type.Equals("Deposit")) {
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
            }
            return list;
        }
        public static List<CustumeView_TransactionDTO> CustumeView_GetTransaction()
        {
            var data = DataAccessFactory.TransactionDataAccess().Get();
            var list = new List<CustumeView_TransactionDTO>();
            foreach (var item in data)
            {
                if (item.Type.Equals("Transaction"))
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
            }
            return list;
        }
        public static List<CustumeView_TransactionDTO> CustumeView_GetLeased()
        {
            var data = DataAccessFactory.TransactionDataAccess().Get();
            var list = new List<CustumeView_TransactionDTO>();
            foreach (var item in data)
            {
                if (item.Type.Equals("Leased land"))
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
            }
            return list;
        }
        public static List<CustumeView_TransactionDTO> CustumeView_GetInvest()
        {
            var data = DataAccessFactory.TransactionDataAccess().Get();
            var list = new List<CustumeView_TransactionDTO>();
            foreach (var item in data)
            {
                if (item.Type.Equals("Invest in land"))
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
            }
            return list;
        }
        public static List<CustumeView_TransactionDTO> CustumeView_GetWid()
        {
            var data = DataAccessFactory.TransactionDataAccess().Get();
            var list = new List<CustumeView_TransactionDTO>();
            foreach (var item in data)
            {
                if (item.Type.Equals("Withdrawed"))
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
            }
            return list;
        }
        public static List<CustumeView_TransactionDTO> CustumeView_GetReturningInvestment()
        {
            var data = DataAccessFactory.TransactionDataAccess().Get();
            var list = new List<CustumeView_TransactionDTO>();
            foreach (var item in data)
            {
                if (item.Type.Equals("Returning investment profit"))
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
            }
            return list;
        }

        //tohere


        public static List<CustumeVide_TransactionSendDTO> transactionHistoryUser_Send(int id)
        {
            //will Get rec Info;
            var res = CustumeView_Get();
            var list = new List<CustumeVide_TransactionSendDTO>();
            foreach (var item in res)
            {
                if(item.SenderId == id)
                {
                    list.Add(new CustumeVide_TransactionSendDTO()
                    {
                        Id = item.Id,
                        Type = item.Type,
                        UserName = DataAccessFactory.UsersDataAccess().Get(item.ReceiverId).Name,
                        UserUsername = DataAccessFactory.UsersDataAccess().Get(item.ReceiverId).Username,
                        UserId = item.ReceiverId,
                        Ammount = item.Ammount,
                        TransactionTime = item.TransactionTime
                    });
                }
            }
            return list;
        }
        public static List<CustumeVide_TransactionRecDTO> transactionHistoryUser_Rec(int id)
        {
            //will Get send Info;
            var res = CustumeView_Get();
            var list = new List<CustumeVide_TransactionRecDTO>();
            foreach (var item in res)
            {
                if (item.ReceiverId == id)
                {
                    list.Add(new CustumeVide_TransactionRecDTO()
                    {
                        Id = item.Id,
                        Type = item.Type,
                        UserName = DataAccessFactory.UsersDataAccess().Get(item.SenderId).Name,
                        UserUsername = DataAccessFactory.UsersDataAccess().Get(item.SenderId).Username,
                        UserId = item.SenderId,
                        Ammount = item.Ammount,
                        TransactionTime = item.TransactionTime
                    });
                }
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
        public static string Add(TransactionDTO dto)
        {
            var res = Convert(dto);
            var senderData = DataAccessFactory.UsersDataAccess().Get(res.SenderId);
            var recevierData = DataAccessFactory.UsersDataAccess().Get(res.ReceiverId);
            res.TransactionTime = DateTime.Now;

            if (senderData != null && recevierData != null)
            {
                if (dto.Ammount >= 0)
                {
                    if (res.SenderId == res.ReceiverId)
                    {
                        res.Type = "Deposit";
                        if (res.Type.Equals("Deposit"))
                        {
                            senderData.Wallet = senderData.Wallet + res.Ammount;
                            var exe = DataAccessFactory.UsersDataAccess().Update1(senderData);
                            if (exe != null)
                            {
                                var result = DataAccessFactory.TransactionDataAccess().Add(res);
                                return "Successfully deposited!";
                            }
                            else
                                return "Unsuccess!";
                        }
                        else
                            return "Deposited";
                    }
                    else
                    {
                        res.Type = "Transaction";
                        if (res.Type.Equals("Transaction"))
                        {
                            if (senderData.Wallet >= res.Ammount)
                            {
                                senderData.Wallet = senderData.Wallet - res.Ammount;
                                recevierData.Wallet = recevierData.Wallet + res.Ammount;
                                var exe1 = DataAccessFactory.UsersDataAccess().Update1(senderData);
                                var exe2 = DataAccessFactory.UsersDataAccess().Update1(recevierData);
                                if (exe1 != null && exe2 != null)
                                {
                                    var result = DataAccessFactory.TransactionDataAccess().Add(res);
                                    return "Successfully Transfered to " + recevierData.Username;
                                }
                                else
                                    return "Unsuccess";
                            }
                            else
                                return "Insufficiend balance in your wallet!";
                        }
                        else
                            return "Transfer problem";
                    }
                }
                else
                {
                    return "You can't transfer less then 1tk.";
                }
            }
            else
            {
                return "Invalid information";
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
                        var exe = DataAccessFactory.UsersDataAccess().Update1(senderData);
                        if (exe != null)
                        {
                            var result1 = DataAccessFactory.TransactionDataAccess().Update1(res);
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
                            var exe1 = DataAccessFactory.UsersDataAccess().Update1(senderData);
                            var exe2 = DataAccessFactory.UsersDataAccess().Update1(recevierData);
                            if (exe1 != null && exe2 != null)
                            {
                                var result1 = DataAccessFactory.TransactionDataAccess().Update1(res);
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

        public static string Withdraw(int id, int MyId, double ammount)
        {
            if (id == MyId) {
                var acc = DataAccessFactory.UsersDataAccess().Get(id);
                if (ammount >= 0)
                {
                    if (acc != null)
                    {
                        if (ammount <= acc.Wallet)
                        {
                            var newAmmount = acc.Wallet - ammount;
                            var ex = DataAccessFactory.WithdwarDataAccess().Withdraw(id, newAmmount);
                            if (ex)
                            {
                                var transaction = new Transaction()
                                {
                                    ReceiverId = id,
                                    SenderId = id,
                                    Ammount = (float)ammount,
                                    Type = "Withdrawed"
                                };
                                var creatingTransaction = DataAccessFactory.TransactionDataAccess().Add(transaction);
                                if (creatingTransaction != null)
                                {
                                    return "Successfully Withdrawed";
                                }
                                else 
                                    return "Something went wrong";
                            }
                            else
                                return "Something went wrong";
                        }
                        else
                            return "Insufficiend balance in your wallet";
                    }
                    else
                        return "Unable to find used account";
                }
                else
                    return "You can't withdraw less then 1TK";
            }
            else
                return "You can't withdraw from other account";
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
                                var exe = DataAccessFactory.UsersDataAccess().Update1(senderData);
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
                                var exe1 = DataAccessFactory.UsersDataAccess().Update1(senderData);
                                var exe2 = DataAccessFactory.UsersDataAccess().Update1(recevierData);
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
