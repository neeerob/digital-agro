using BLL.DTOs;
using BLL.Services;
using digital_agro_api.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace digital_agro_api.Controllers
{
    [EnableCors("*", "*", "*")]
    public class UserController : ApiController
    {
        [Route("api/user")]
        [HttpGet]
        public HttpResponseMessage GetUser()
        {
            try
            {
                var data = UsersService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        [Route("api/user/{id}")]
        [HttpGet]
        public HttpResponseMessage GetUser(int id)
        {
            try
            {
                var data = UsersService.Get(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        [Route("api/user/add")]
        [HttpPost]
        public HttpResponseMessage Add(UsersDTO member)
        {
            var add = UsersService.Add(member);
            if (add != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Inserted", data = member });
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }
        [Route("api/user/delete/{id}")]
        [HttpPost]
        public HttpResponseMessage DeleteUser(int id)
        {
            var extr = UsersService.Delete(id);
            if (extr)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Deleted!", data = extr });
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = "Error While deleting!", data = extr });
            }
        }
        [Route("api/user/update")]
        [HttpPost]
        public HttpResponseMessage UpdateUser(UsersDTO member)
        {
            var extr = UsersService.Update(member);
            if (extr != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Updated!", data = extr });
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = "Error While updating!", data = extr });
            }
        }

        [Route("api/userpass/change/{id}/{password}/{old}")]
        [HttpPost]
        [Logged_Users]
        public HttpResponseMessage UpdateUserPassword(int id, string password, string old)
        {
            var extr = UsersService.Update(id, password, old);
            if (extr != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Changed!", data = extr });
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = "Error While Changing!", data = extr });
            }
        }

    }
}
