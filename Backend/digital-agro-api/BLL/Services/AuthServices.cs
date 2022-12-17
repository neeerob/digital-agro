using AutoMapper;
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
    public class AuthServices
    {
        public static Token_AdminDTO Authenticate_Admin(string username, string password)
        {
            var user = DataAccessFactory.AuthenticateDataAccess_Admin().Authenticate(username, password);
            if (user != null)
            {
                Token_Admin t = new Token_Admin();
                t.CreationTime = DateTime.Now;
                t.Username = user.Username;
                t.ExpirationTime = DateTime.Now.AddHours(1); 
                t.TKey = Guid.NewGuid().ToString();
                var rt = DataAccessFactory.TokenDataAccess_Admin().Add(t);
                if (rt != null)
                {
                    var config = new MapperConfiguration(cfg => {
                        cfg.CreateMap<Token_Admin, Token_AdminDTO>();
                    });
                    var mapper = new Mapper(config);
                    var data = mapper.Map<Token_AdminDTO>(rt);
                    return data;
                }
            }
            return null;
        }
        public static bool TokenValidity_Admin(string tkey)
        {
            var token = DataAccessFactory.TokenDataAccess_Admin().Get(tkey);
            if (token != null && token.ExpirationTime > DateTime.Now)
            {
                return true;
            }
            return false;
        }

        public static Token_UsersDTO Authenticate_User(string username, string password)
        {
            var user = DataAccessFactory.AuthenticateDataAccess_User().Authenticate(username, password);
            if (user != null)
            {
                Token_Users t = new Token_Users();
                t.CreationTime = DateTime.Now;
                t.Username = user.Username;
                t.ExpirationTime = DateTime.Now.AddHours(1);
                t.TKey = Guid.NewGuid().ToString();
                var rt = DataAccessFactory.TokenDataAccess_User().Add(t);
                if (rt != null)
                {
                    var config = new MapperConfiguration(cfg => {
                        cfg.CreateMap<Token_Users, Token_UsersDTO>();
                    });
                    var mapper = new Mapper(config);
                    var data = mapper.Map<Token_UsersDTO>(rt);
                    return data;
                }
            }
            return null;
        }
        public static bool TokenValidity_User(string tkey)
        {
            var token = DataAccessFactory.TokenDataAccess_User().Get(tkey);
            if (token != null && token.ExpirationTime > DateTime.Now)
            {
                return true;
            }
            return false;
        }

        public static Token_GovmentDTO Authenticate_Govment(string username, string password)
        {
            var user = DataAccessFactory.AuthenticateDataAccess_Govment().Authenticate(username, password);
            if (user != null)
            {
                Token_Govment t = new Token_Govment();
                t.CreationTime = DateTime.Now;
                t.Username = user.Username;
                t.ExpirationTime = DateTime.Now.AddHours(1);
                t.TKey = Guid.NewGuid().ToString();
                var rt = DataAccessFactory.TokenDataAccess_Govment().Add(t);
                if (rt != null)
                {
                    var config = new MapperConfiguration(cfg => {
                        cfg.CreateMap<Token_Govment, Token_GovmentDTO>();
                    });
                    var mapper = new Mapper(config);
                    var data = mapper.Map<Token_GovmentDTO>(rt);
                    return data;
                }
            }
            return null;
        }
        public static bool TokenValidity_Govment(string tkey)
        {
            var token = DataAccessFactory.TokenDataAccess_Govment().Get(tkey);
            if (token != null && token.ExpirationTime > DateTime.Now)
            {
                return true;
            }
            return false;
        }
    }
}
