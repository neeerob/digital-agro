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
    public class AuthController : ApiController
    {
        [Route("api/login/user")]
        [HttpPost]
        public HttpResponseMessage Login(LoginDTO login)
        {
            var data = AuthServices.Authenticate_User(login.Username, login.Password);
            if (data != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            return Request.CreateResponse(HttpStatusCode.NotFound);
        }
    }
}
