using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace digital_agro_api.Controllers
{
    public class TestController : ApiController
    {
        [Route("api/admin")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            var data = AdminService.Get();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [Route("api/admin/{id}")]
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            var data = AdminService.Get(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [Route("api/admin/add")]
        [HttpPost]
        public HttpResponseMessage Post(AdminDTO member)
        {
            var add = AdminService.Add(member);
            if (add != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Inserted", data = member });
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }
        [Route("api/admin/delete/{id}")]
        [HttpPost]
        public HttpResponseMessage Delete(int id)
        {
            var extr = AdminService.Delete(id);
            if (extr)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Deleted!", data = extr });
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = "Error While deleting!", data = extr });
            }
        }
        [Route("api/admin/update")]
        [HttpPost]
        public HttpResponseMessage Update(AdminDTO member)
        {
            var extr = AdminService.Update(member);
            if (extr != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Updated!", data = extr });
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = "Error While updating!", data = extr });
            }
        }


        //For User
        [Route("api/user")]
        [HttpGet]
        public HttpResponseMessage GetUser()
        {
            var data = UsersService.Get();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [Route("api/user/{id}")]
        [HttpGet]
        public HttpResponseMessage GetUser(int id)
        {
            var data = UsersService.Get(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
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


        //Govment Official
        [Route("api/gov")]
        [HttpGet]
        public HttpResponseMessage Getgov()
        {
            var data = GovmentOfficialService.Get();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [Route("api/gov/{id}")]
        [HttpGet]
        public HttpResponseMessage Getgov(int id)
        {
            var data = GovmentOfficialService.Get(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [Route("api/gov/add")]
        [HttpPost]
        public HttpResponseMessage Addgov(GovmentOfficialDTO member)
        {
            var add = GovmentOfficialService.Add(member);
            if (add != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Inserted", data = member });
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }
        [Route("api/gov/delete/{id}")]
        [HttpPost]
        public HttpResponseMessage Deletegov(int id)
        {
            var extr = GovmentOfficialService.Delete(id);
            if (extr)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Deleted!", data = extr });
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = "Error While deleting!", data = extr });
            }
        }
        [Route("api/gov/update")]
        [HttpPost]
        public HttpResponseMessage Updategov(GovmentOfficialDTO member)
        {
            var extr = GovmentOfficialService.Update(member);
            if (extr != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Updated!", data = extr });
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = "Error While updating!", data = extr });
            }
        }
    }
}
