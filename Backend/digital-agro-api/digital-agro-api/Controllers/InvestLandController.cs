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
    [Logged_Users] 
    public class InvestLandController : ApiController
    {
        [Route("api/Invest")]
        [HttpGet]
        public HttpResponseMessage GetIL()
        {
            var data = InvestLandsService.Get();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [Route("api/invest/Available")]
        [HttpGet]
        public HttpResponseMessage GetAvailable()
        {
            var data = InvestLandsService.GetAvailableInvest();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [Route("api/invest/Complete")]
        [HttpGet]
        public HttpResponseMessage GetCompleted()
        {
            var data = InvestLandsService.GetCompleted();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/invest/my/land/{id}")]
        [HttpGet]
        public HttpResponseMessage GetCompleted(int id)
        {
            var data = InvestLandsService.GetCompleted(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/invest/byuser/{id}")]
        [HttpGet]
        public HttpResponseMessage GetForUserById(int id)
        {
            var data = ConfirmInvestmentsService.CustumeView_Get_byUserId(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [Route("api/Invest/{id}")]
        [HttpGet]
        public HttpResponseMessage GetIL(int id)
        {
            var data = InvestLandsService.Get(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [Route("api/Invest/add")]
        [HttpPost]
        public HttpResponseMessage AddIL(InvestLandsDTO member)
        {
            var add = InvestLandsService.Add(member);
            if (add != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Inserted", data = member });
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }

        [Route("api/Invest/delete/{id}")]
        [HttpPost]
        public HttpResponseMessage DeleteIL(int id)
        {
            var extr = InvestLandsService.Delete(id);
            if (extr)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Deleted!", data = extr });
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = "Error While deleting!", data = extr });
            }
        }
        [Route("api/Invest/update")]
        [HttpPost]
        public HttpResponseMessage UpdateIL(InvestLandsDTO member)
        {
            var extr = InvestLandsService.Update(member);
            if (extr != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Updated!", data = extr });
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = "Error While updating!", data = extr });
            }
        }
        [Route("api/doinvest/add/{landId}/{userId}/{Ammount}")]
        [HttpPost]
        public HttpResponseMessage AddC(int landId, int userId, int Ammount)
        {
            var add = ConfirmInvestmentsService.Add(landId, userId, Ammount);
            if (add != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Invested", data = add });
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { data = add });
            }
        }
    }
}
