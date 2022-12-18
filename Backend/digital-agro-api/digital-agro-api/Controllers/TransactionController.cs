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
    public class TransactionController : ApiController
    {
        [Route("api/transaction")]
        [HttpGet]
        public HttpResponseMessage GetT()
        {
            var data = TransactionService.Get();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [Route("api/transaction/view")]
        [HttpGet]
        public HttpResponseMessage V_GetT()
        {
            var data = TransactionService.CustumeView_Get();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [Route("api/transaction/{id}")]
        [HttpGet]
        public HttpResponseMessage GetT(int id)
        {
            var data = TransactionService.Get(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [Route("api/transaction/UserSendHistory/{id}")]
        [HttpGet]
        public HttpResponseMessage History_Send(int id)
        {
            var data = TransactionService.transactionHistoryUser_Send(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [Route("api/transaction/UserRecHistory/{id}")]
        [HttpGet]
        public HttpResponseMessage History_Rec(int id)
        {
            var data = TransactionService.transactionHistoryUser_Rec(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [Route("api/transaction/view/{id}")]
        [HttpGet]
        public HttpResponseMessage V_GetT(int id)
        {
            var data = TransactionService.CustumeView_Get(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [Route("api/transaction/add")]
        [HttpPost]
        public HttpResponseMessage AddT(TransactionDTO member)
        {
            var add = TransactionService.Add(member);
            if (add != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { Msg = add, data = member });
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { data = add });
            }
        }
        [Route("api/transaction/cancel/{id}")]
        [HttpPost]
        public HttpResponseMessage Cancel(int id)
        {
            var extr = TransactionService.Cancel(id);
            if (extr != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Canceled!", data = extr });
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = "Error While Canceling!", data = extr });
            }
        }
    }
}
