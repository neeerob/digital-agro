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

        public static List<LeaseLandsDTO> GetAvailableLeasedLand()
        {
            var data = DataAccessFactory.LeaseLandsDataAccess().Get();
            var list = new List<LeaseLandsDTO>();
            foreach (var item in data)
            {
                if (item.Status.Equals("Verified") || item.Status.Equals("Verified")) {
                    list.Add(Convert(item));
                }
            }
            return list;
        }
        public static List<LeaseLandsDTO> GetAvailableLeasedLand(int id)
        {
            var data = DataAccessFactory.LeaseLandsDataAccess().Get();
            var list = new List<LeaseLandsDTO>();
            foreach (var item in data)
            {
                if ((item.Status.Equals("Unverified") || item.Status.Equals("Unvarified")) && item.GovmentId == id)
                {
                    list.Add(Convert(item));
                }
            }
            return list;
        }

        public static List<LeaseLandsDTO> AlreadyLeased()
        {
            var data = DataAccessFactory.LeaseLandsDataAccess().Get();
            var list = new List<LeaseLandsDTO>();
            foreach (var item in data)
            {
                if (item.Status.Equals("Leased"))
                {
                    list.Add(Convert(item));
                }
            }
            return list;
        }

        public static List<LeaseLandsDTO> AlreadyLeased(int id)
        {
            var data = DataAccessFactory.LeaseLandsDataAccess().Get();
            var list = new List<LeaseLandsDTO>();
            foreach (var item in data)
            {
                if (item.OwnerId == id)
                {
                    list.Add(Convert(item));
                }
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
        public static LeaseLandsDTO VerifyByGovment(int id, int govId)
        {
            var res = DataAccessFactory.LeaseLandsDataAccess().Get(id);
            if (res.GovmentId == govId && (res.Status.Equals("Unvarified") || res.Status.Equals("Unverified")))
            {
                res.Status = "Verified";
                var result = DataAccessFactory.LeaseLandsDataAccess().Update(res);
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
                var dbData = DataAccessFactory.LeaseLandsDataAccess().Delete(id);
                return dbData;
            }
            return false;
        }

    }
}
