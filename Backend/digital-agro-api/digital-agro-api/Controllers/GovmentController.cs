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

        //veryfy land pending
        [Route("api/Leaseland/verifyByGovID/{id}")]
        [HttpGet]
        [Logged_Govment]
        public HttpResponseMessage getByGovId(int id)
        {
            var data = LeaseLandsService.GetAvailableLeasedLand(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        //done
        [Route("api/Leaseland/clearedByGovID/{id}")]
        [HttpGet]
        [Logged_Govment]
        public HttpResponseMessage getByGovIdCompleted(int id)
        {
            var data = LeaseLandsService.GetCompletedByGovId(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        //verifying
        [Route("api/Leaseland/VerifyLLbyGov/{id}/{govid}")]
        [HttpPost]
        [Logged_Govment]
        public HttpResponseMessage getByGovId(int id, int govid)
        {
            var data = LeaseLandsService.VerifyByGovment(id, govid);
            if (data != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Successfully verified!", data = data });
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = "Unsuccessfull!", data = data });
            }
        }

        //verifying
        [Route("api/InvestLand/VerifyLLbyGov/{id}/{govid}")]
        [HttpPost]
        [Logged_Govment]
        public HttpResponseMessage getByGovIdInvest(int id, int govid)
        {
            var data = InvestLandsService.VerifyByGovment(id, govid);
            if (data != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Successfully verified!", data = data });
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = "Unsuccessfull!", data = data });
            }
        }

        [Route("api/Leaseland/DeleteByGov/{id}")]
        [HttpPost]
        [Logged_Govment]
        public HttpResponseMessage delByGov(int id)
        {
            var data = LeaseLandsService.Delete(id);
            if (data)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Successfully Candeled!(Deleted)" });
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = "Unsuccessfull!"});
            }
        }

        [Route("api/Investland/DeleteByGov/{id}")]
        [HttpPost]
        [Logged_Govment]
        public HttpResponseMessage delByGovInvestLand(int id)
        {
            var data = InvestLandsService.Delete(id);
            if (data)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Successfully Candeled!(Deleted)" });
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = "Unsuccessfull!" });
            }
        }

        //veryfy land pending
        [Route("api/InvestLand/verifyByGovID/{id}")]
        [HttpGet]
        [Logged_Govment]
        public HttpResponseMessage getByGovIdLL(int id)
        {
            var data = InvestLandsService.GetAvailableInvest(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        //done
        [Route("api/Investland/clearedByGovID/{id}")]
        [HttpGet]
        [Logged_Govment]
        public HttpResponseMessage getByGovIdCompletedInvest(int id)
        {
            var data = InvestLandsService.GetCompletedByGovId(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/govPass/change/{id}/{password}/{old}")]
        [HttpPost]
        [Logged_Govment]
        public HttpResponseMessage UpdateGovPassword(int id, string password, string old)
        {
            var extr = GovmentOfficialService.Update(id, password, old);
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
