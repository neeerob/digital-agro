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
    public class CloseInvestController : ApiController
    {
        [Route("api/close/getall")]
        [HttpGet]
        public HttpResponseMessage GetAllClose()
        {
            var data = CloseInvestService.CustumeView_Get();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [Route("api/close/getall/byOwnerId/{id}")]
        [HttpGet]
        public HttpResponseMessage GetAllCloseByOwner(int id)
        {
            var data = CloseInvestService.CustumeView_Get_byOwner(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [Route("api/close/returnInvest/{Id}/{landId}/{UserId}/{Ammount}")]
        [HttpPost]
        public HttpResponseMessage UpdatedCheck(int Id, int landId, int UserId, double Ammount)
        {
            var extr = CloseInvestService.Update(Id, landId, UserId, Ammount);
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
