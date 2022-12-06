﻿using AutoMapper;
using BLL.DTOs;
using DAL.EF_Code_First.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AutoMapper.Internal.ExpressionFactory;

namespace BLL.Converter
{
    public class ConverterService
    {
        //For Admin
        public static ProtectedAdminDTO ProtectedConvert(Admins dto)
        {
            var config = new MapperConfiguration(
                cfg => cfg.CreateMap<Admins, ProtectedAdminDTO>()
                );
            var mapper = new Mapper(config);
            var data = mapper.Map<ProtectedAdminDTO>(dto);
            return data;
        }
        public static Admins Convert(AdminDTO dto)
        {
            var config = new MapperConfiguration(
                cfg => cfg.CreateMap<AdminDTO, Admins>()
                );
            var mapper = new Mapper(config);
            var data = mapper.Map<Admins>(dto);
            return data;
        }
        public static AdminDTO Convert(Admins dto)
        {
            var config = new MapperConfiguration(
                cfg => cfg.CreateMap<Admins, AdminDTO>()
                );
            var mapper = new Mapper(config);
            var data = mapper.Map<AdminDTO>(dto);
            return data;
        }
        //FFor USers
        public static ProtectedUsersDTO ProtectedConvert(Users dto)
        {
            var config = new MapperConfiguration(
                cfg => cfg.CreateMap<Users, ProtectedUsersDTO>()
                );
            var mapper = new Mapper(config);
            var data = mapper.Map<ProtectedUsersDTO>(dto);
            return data;
        }
        public static Users Convert(UsersDTO dto)
        {
            var config = new MapperConfiguration(
                cfg => cfg.CreateMap<UsersDTO, Users>()
                );
            var mapper = new Mapper(config);
            var data = mapper.Map<Users>(dto);
            return data;
        }
        public static UsersDTO Convert(Users dto)
        {
            var config = new MapperConfiguration(
                cfg => cfg.CreateMap<Users, UsersDTO>()
                );
            var mapper = new Mapper(config);
            var data = mapper.Map<UsersDTO>(dto);
            return data;
        }
        //FFor Govment
        public static ProtectedGovmentOfficialDTO ProtectedConvert(GovmentOfficial dto)
        {
            var config = new MapperConfiguration(
                cfg => cfg.CreateMap<GovmentOfficial, ProtectedGovmentOfficialDTO>()
                );
            var mapper = new Mapper(config);
            var data = mapper.Map<ProtectedGovmentOfficialDTO>(dto);
            return data;
        }
        public static GovmentOfficial Convert(GovmentOfficialDTO dto)
        {
            var config = new MapperConfiguration(
                cfg => cfg.CreateMap<GovmentOfficialDTO, GovmentOfficial>()
                );
            var mapper = new Mapper(config);
            var data = mapper.Map<GovmentOfficial>(dto);
            return data;
        }
        public static GovmentOfficialDTO Convert(GovmentOfficial dto)
        {
            var config = new MapperConfiguration(
                cfg => cfg.CreateMap<GovmentOfficial, GovmentOfficialDTO>()
                );
            var mapper = new Mapper(config);
            var data = mapper.Map<GovmentOfficialDTO>(dto);
            return data;
        }

        ////////For Confirm Investments
        ///
        public static ConfirmInvestmentsDTO Convert(ConfirmInvestments dto)
        {
            var config = new MapperConfiguration(
                cfg => cfg.CreateMap<ConfirmInvestments, ConfirmInvestmentsDTO>()
                );
            var mapper = new Mapper(config);
            var data = mapper.Map<ConfirmInvestmentsDTO>(dto);
            return data;
        }
        public static ConfirmInvestments Convert(ConfirmInvestmentsDTO dto)
        {
            var config = new MapperConfiguration(
                cfg => cfg.CreateMap<ConfirmInvestmentsDTO, ConfirmInvestments>()
                );
            var mapper = new Mapper(config);
            var data = mapper.Map<ConfirmInvestments>(dto);
            return data;
        }
        /////
        ///




    }
}