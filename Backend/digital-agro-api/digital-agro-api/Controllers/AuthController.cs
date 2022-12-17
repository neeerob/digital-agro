using BLL.DTOs;
using BLL.Services;
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
    public class AuthController : ApiController
    {
        [Route("api/login/user")]
        [HttpPost]
        public HttpResponseMessage Login_User(LoginDTO login)
        {
            var data = AuthServices.Authenticate_User(login.Username, login.Password);
            if (data != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            return Request.CreateResponse(HttpStatusCode.NotFound);
        }

        [Route("api/login/admin")]
        [HttpPost]
        public HttpResponseMessage Login_admin(LoginDTO login)
        {
            var data = AuthServices.Authenticate_Admin(login.Username, login.Password);
            if (data != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            return Request.CreateResponse(HttpStatusCode.NotFound);
        }

        [Route("api/login/govment")]
        [HttpPost]
        public HttpResponseMessage Login_govment(LoginDTO login)
        {
            var data = AuthServices.Authenticate_Govment(login.Username, login.Password);
            if (data != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            return Request.CreateResponse(HttpStatusCode.NotFound);
        }
    }
}
