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
    public class GovmentController : ApiController
    {
        //Govment Official
        [Route("api/gov")]
        [HttpGet]
        //[Logged_Govment]
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
