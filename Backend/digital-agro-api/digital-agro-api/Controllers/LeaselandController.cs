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
    public class LeaselandController : ApiController
    {
        [Route("api/Leaseland")]
        [HttpGet]
        public HttpResponseMessage GetLL()
        {
            var data = LeaseLandsService.Get();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/Leaseland/available")]
        [HttpGet]
        public HttpResponseMessage GetLLAvailable()
        {
            var data = LeaseLandsService.GetAvailableLeasedLand();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [Route("api/Leaseland/leased")]
        [HttpGet]
        public HttpResponseMessage AlLeased()
        {
            var data = LeaseLandsService.AlreadyLeased();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/Leaseland/leased/myLand/my/{id}")]
        [HttpGet]
        public HttpResponseMessage MyLands(int id)
        {
            var data = LeaseLandsService.AlreadyLeased(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/Leaseland/byuser/{id}")]
        [HttpGet]
        public HttpResponseMessage GetForUserById(int id)
        {
            var data = ConfirmLeaseService.CustumeView_Get_byUserId(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }


        [Route("api/Leaseland/{id}")]
        [HttpGet]
        public HttpResponseMessage GetLL(int id)
        {
            var data = LeaseLandsService.Get(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [Route("api/Leaseland/add")]
        [HttpPost]
        public HttpResponseMessage AddLL(LeaseLandsDTO member)
        {
            var add = LeaseLandsService.Add(member);
            if (add != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Inserted", data = member });
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }
        [Route("api/Leaseland/delete/{id}")]
        [HttpPost]
        public HttpResponseMessage DeleteLL(int id)
        {
            var extr = LeaseLandsService.Delete(id);
            if (extr)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Deleted!", data = extr });
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = "Error While deleting!", data = extr });
            }
        }
        [Route("api/Leaseland/update")]
        [HttpPost]
        public HttpResponseMessage UpdateLL(LeaseLandsDTO member)
        {
            var extr = LeaseLandsService.Update(member);
            if (extr != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Updated!", data = extr });
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = "Error While updating!", data = extr });
            }
        }

        //cross orifin; link change
        [Route("api/cl/add/confirm/change")]
        [HttpPost]
        public HttpResponseMessage ConfirmLeaseLandByUser(ConfirmLeaseDTO member)
        {
            var add = ConfirmLeaseService.Add(member);
            if (add != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Inserted", data = add });
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { data = add });
            }
        }

    }
}
