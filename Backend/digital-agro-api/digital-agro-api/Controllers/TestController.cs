using BLL.DTOs;
using BLL.Services;
using digital_agro_api.Auth;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace digital_agro_api.Controllers
{
    [EnableCors("*", "*", "*")]
    public class TestController : ApiController
    {
        //[Route("api/admin")]
        //[HttpGet]
        //public HttpResponseMessage Get()
        //{
        //    var data = AdminService.Get();
        //    return Request.CreateResponse(HttpStatusCode.OK, data);
        //}
        //[Route("api/admin/username")]
        //[HttpGet]
        //public HttpResponseMessage Getuser()
        //{
        //    var data = AdminService.GetUsername();
        //    return Request.CreateResponse(HttpStatusCode.OK, data);
        //}
        //[Route("api/admin/{id}")]
        //[HttpGet]
        //public HttpResponseMessage Get(int id)
        //{
        //    var data = AdminService.Get(id);
        //    return Request.CreateResponse(HttpStatusCode.OK, data);
        //}
        //[Route("api/admin/add")]
        //[HttpPost]
        //public HttpResponseMessage Post(AdminDTO member)
        //{
        //    var add = AdminService.Add(member);
        //    if (add != null)
        //    {
        //        return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Inserted", data = member });
        //    }
        //    else
        //    {
        //        return Request.CreateResponse(HttpStatusCode.InternalServerError);
        //    }
        //}
        //[Route("api/admin/delete/{id}")]
        //[HttpPost]
        //public HttpResponseMessage Delete(int id)
        //{
        //    var extr = AdminService.Delete(id);
        //    if (extr)
        //    {
        //        return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Deleted!", data = extr });
        //    }
        //    else
        //    {
        //        return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = "Error While deleting!", data = extr });
        //    }
        //}
        //[Route("api/admin/update")]
        //[HttpPost]
        //public HttpResponseMessage Update(AdminDTO member)
        //{
        //    var extr = AdminService.Update(member);
        //    if (extr != null)
        //    {
        //        return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Updated!", data = extr });
        //    }
        //    else
        //    {
        //        return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = "Error While updating!", data = extr });
        //    }
        //}


        //For User
        //[Route("api/user")]
        //[HttpGet]
        ////[Logged_Users]
        //public HttpResponseMessage GetUser()
        //{
        //    var data = UsersService.Get();
        //    return Request.CreateResponse(HttpStatusCode.OK, data);
        //}
        //[Route("api/user/{id}")]
        //[HttpGet]
        //public HttpResponseMessage GetUser(int id)
        //{
        //    var data = UsersService.Get(id);
        //    return Request.CreateResponse(HttpStatusCode.OK, data);
        //}
        //[Route("api/user/add")]
        //[HttpPost]
        //public HttpResponseMessage Add(UsersDTO member)
        //{
        //    var add = UsersService.Add(member);
        //    if (add != null)
        //    {
        //        return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Inserted", data = member });
        //    }
        //    else
        //    {
        //        return Request.CreateResponse(HttpStatusCode.InternalServerError);
        //    }
        //}
        //[Route("api/user/delete/{id}")]
        //[HttpPost]
        //public HttpResponseMessage DeleteUser(int id)
        //{
        //    var extr = UsersService.Delete(id);
        //    if (extr)
        //    {
        //        return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Deleted!", data = extr });
        //    }
        //    else
        //    {
        //        return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = "Error While deleting!", data = extr });
        //    }
        //}
        //[Route("api/user/update")]
        //[HttpPost]
        //public HttpResponseMessage UpdateUser(UsersDTO member)
        //{
        //    var extr = UsersService.Update(member);
        //    if (extr != null)
        //    {
        //        return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Updated!", data = extr });
        //    }
        //    else
        //    {
        //        return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = "Error While updating!", data = extr });
        //    }
        //}


        ////Govment Official
        //[Route("api/gov")]
        //[HttpGet]
        ////[Logged_Govment]
        //public HttpResponseMessage Getgov()
        //{
        //    var data = GovmentOfficialService.Get();
        //    return Request.CreateResponse(HttpStatusCode.OK, data);
        //}
        //[Route("api/gov/{id}")]
        //[HttpGet]
        //public HttpResponseMessage Getgov(int id)
        //{
        //    var data = GovmentOfficialService.Get(id);
        //    return Request.CreateResponse(HttpStatusCode.OK, data);
        //}
        //[Route("api/gov/add")]
        //[HttpPost]
        //public HttpResponseMessage Addgov(GovmentOfficialDTO member)
        //{
        //    var add = GovmentOfficialService.Add(member);
        //    if (add != null)
        //    {
        //        return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Inserted", data = member });
        //    }
        //    else
        //    {
        //        return Request.CreateResponse(HttpStatusCode.InternalServerError);
        //    }
        //}
        //[Route("api/gov/delete/{id}")]
        //[HttpPost]
        //public HttpResponseMessage Deletegov(int id)
        //{
        //    var extr = GovmentOfficialService.Delete(id);
        //    if (extr)
        //    {
        //        return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Deleted!", data = extr });
        //    }
        //    else
        //    {
        //        return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = "Error While deleting!", data = extr });
        //    }
        //}
        //[Route("api/gov/update")]
        //[HttpPost]
        //public HttpResponseMessage Updategov(GovmentOfficialDTO member)
        //{
        //    var extr = GovmentOfficialService.Update(member);
        //    if (extr != null)
        //    {
        //        return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Updated!", data = extr });
        //    }
        //    else
        //    {
        //        return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = "Error While updating!", data = extr });
        //    }
        //}

        //Leaseland
        //[Route("api/Leaseland")]
        //[HttpGet]
        //[Logged_Users]
        //public HttpResponseMessage GetLL()
        //{
        //    var data = LeaseLandsService.Get();
        //    return Request.CreateResponse(HttpStatusCode.OK, data);
        //}
        //[Route("api/Leaseland/{id}")]
        //[HttpGet]
        //public HttpResponseMessage GetLL(int id)
        //{
        //    var data = LeaseLandsService.Get(id);
        //    return Request.CreateResponse(HttpStatusCode.OK, data);
        //}
        //[Route("api/Leaseland/add")]
        //[HttpPost]
        //public HttpResponseMessage AddLL(LeaseLandsDTO member)
        //{
        //    var add = LeaseLandsService.Add(member);
        //    if (add != null)
        //    {
        //        return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Inserted", data = member });
        //    }
        //    else
        //    {
        //        return Request.CreateResponse(HttpStatusCode.InternalServerError);
        //    }
        //}
        //[Route("api/Leaseland/delete/{id}")]
        //[HttpPost]
        //public HttpResponseMessage DeleteLL(int id)
        //{
        //    var extr = LeaseLandsService.Delete(id);
        //    if (extr)
        //    {
        //        return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Deleted!", data = extr });
        //    }
        //    else
        //    {
        //        return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = "Error While deleting!", data = extr });
        //    }
        //}
        //[Route("api/Leaseland/update")]
        //[HttpPost]
        //public HttpResponseMessage UpdateLL(LeaseLandsDTO member)
        //{
        //    var extr = LeaseLandsService.Update(member);
        //    if (extr != null)
        //    {
        //        return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Updated!", data = extr });
        //    }
        //    else
        //    {
        //        return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = "Error While updating!", data = extr });
        //    }
        //}

        /////InvestLand
        ///

        //[Route("api/Invest")]
        //[HttpGet]
        //public HttpResponseMessage GetIL()
        //{
        //    var data = InvestLandsService.Get();
        //    return Request.CreateResponse(HttpStatusCode.OK, data);
        //}
        //[Route("api/Invest/{id}")]
        //[HttpGet]
        //public HttpResponseMessage GetIL(int id)
        //{
        //    var data = InvestLandsService.Get(id);
        //    return Request.CreateResponse(HttpStatusCode.OK, data);
        //}
        //[Route("api/Invest/add")]
        //[HttpPost]
        //public HttpResponseMessage AddIL(InvestLandsDTO member)
        //{
        //    var add = InvestLandsService.Add(member);
        //    if (add != null)
        //    {
        //        return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Inserted", data = member });
        //    }
        //    else
        //    {
        //        return Request.CreateResponse(HttpStatusCode.InternalServerError);
        //    }
        //}
        //[Route("api/Invest/delete/{id}")]
        //[HttpPost]
        //public HttpResponseMessage DeleteIL(int id)
        //{
        //    var extr = InvestLandsService.Delete(id);
        //    if (extr)
        //    {
        //        return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Deleted!", data = extr });
        //    }
        //    else
        //    {
        //        return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = "Error While deleting!", data = extr });
        //    }
        //}
        //[Route("api/Invest/update")]
        //[HttpPost]
        //public HttpResponseMessage UpdateIL(InvestLandsDTO member)
        //{
        //    var extr = InvestLandsService.Update(member);
        //    if (extr != null)
        //    {
        //        return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Updated!", data = extr });
        //    }
        //    else
        //    {
        //        return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = "Error While updating!", data = extr });
        //    }
        //}


        /////District
        ///

        [Route("api/district")]
        [HttpGet]
        public HttpResponseMessage Getdis()
        {
            var data = DistrictService.Get();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [Route("api/district/{id}")]
        [HttpGet]
        public HttpResponseMessage Getdis(int id)
        {
            var data = DistrictService.Get(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [Route("api/district/add")]
        [HttpPost]
        public HttpResponseMessage Adddis(DistrictDTO member)
        {
            var add = DistrictService.Add(member);
            if (add != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Inserted", data = member });
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }
        [Route("api/district/delete/{id}")]
        [HttpPost]
        public HttpResponseMessage Deletedis(int id)
        {
            var extr = DistrictService.Delete(id);
            if (extr)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Deleted!", data = extr });
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = "Error While deleting!", data = extr });
            }
        }
        [Route("api/district/update")]
        [HttpPost]
        public HttpResponseMessage Updatedis(DistrictDTO member)
        {
            var extr = DistrictService.Update(member);
            if (extr != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Updated!", data = extr });
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = "Error While updating!", data = extr });
            }
        }

        ////
        ///Transaction
        ///

        //[Route("api/transaction")]
        //[HttpGet]
        //public HttpResponseMessage GetT()
        //{
        //    var data = TransactionService.Get();
        //    return Request.CreateResponse(HttpStatusCode.OK, data);
        //}
        //[Route("api/transaction/view")]
        //[HttpGet]
        //public HttpResponseMessage V_GetT()
        //{
        //    var data = TransactionService.CustumeView_Get();
        //    return Request.CreateResponse(HttpStatusCode.OK, data);
        //}
        //[Route("api/transaction/{id}")]
        //[HttpGet]
        //public HttpResponseMessage GetT(int id)
        //{
        //    var data = TransactionService.Get(id);
        //    return Request.CreateResponse(HttpStatusCode.OK, data);
        //}
        //[Route("api/transaction/view/{id}")]
        //[HttpGet]
        //public HttpResponseMessage V_GetT(int id)
        //{
        //    var data = TransactionService.CustumeView_Get(id);
        //    return Request.CreateResponse(HttpStatusCode.OK, data);
        //}
        //[Route("api/transaction/add")]
        //[HttpPost]
        //public HttpResponseMessage AddT(TransactionDTO member)
        //{
        //    var add = TransactionService.Add(member);
        //    if (add != null)
        //    {
        //        return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Inserted", data = member });
        //    }
        //    else
        //    {
        //        return Request.CreateResponse(HttpStatusCode.InternalServerError, new {data = add} );
        //    }
        //}
        //[Route("api/transaction/cancel/{id}")]
        //[HttpPost]
        //public HttpResponseMessage Cancel(int id)
        //{
        //    var extr = TransactionService.Cancel(id);
        //    if (extr != null)
        //    {
        //        return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Canceled!", data = extr });
        //    }
        //    else
        //    {
        //        return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = "Error While Canceling!", data = extr });
        //    }
        //}

        ////
        ///Confirm_Lease
        ///

        [Route("api/cl")]
        [HttpGet]
        public HttpResponseMessage GetCL()
        {
            var data = ConfirmLeaseService.Get();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [Route("api/cl/view")]
        [HttpGet]
        public HttpResponseMessage V_GetCL()
        {
            var data = ConfirmLeaseService.CustumeView_Get();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [Route("api/cl/{id}")]
        [HttpGet]
        public HttpResponseMessage GetCL(int id)
        {
            var data = ConfirmLeaseService.Get(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [Route("api/cl/view/{id}")]
        [HttpGet]
        public HttpResponseMessage V_GetCL(int id)
        {
            var data = ConfirmLeaseService.CustumeView_Get(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        //[Route("api/cl/add")]
        //[HttpPost]
        //public HttpResponseMessage AddCL(ConfirmLeaseDTO member)
        //{
        //    var add = ConfirmLeaseService.Add(member);
        //    if (add != null)
        //    {
        //        return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Inserted", data = add });
        //    }
        //    else
        //    {
        //        return Request.CreateResponse(HttpStatusCode.InternalServerError, new { data = add });
        //    }
        //}
        //
        //ConfirmInvest
        ///

        [Route("api/ci")]
        [HttpGet]
        public HttpResponseMessage GetCI()
        {
            var data = ConfirmInvestmentsService.Get();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [Route("api/ci/view")]
        [HttpGet]
        public HttpResponseMessage V_GetCI()
        {
            var data = ConfirmInvestmentsService.CustumeView_Get();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [Route("api/ci/{id}")]
        [HttpGet]
        public HttpResponseMessage GetCI(int id)
        {
            var data = ConfirmInvestmentsService.Get(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [Route("api/ci/view/{id}")]
        [HttpGet]
        public HttpResponseMessage V_GetCI(int id)
        {
            var data = ConfirmInvestmentsService.CustumeView_Get(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        //[Route("api/ci/add")]
        //[HttpPost]
        //public HttpResponseMessage AddC(ConfirmInvestmentsDTO member)
        //{
        //    var add = ConfirmInvestmentsService.Add(member);
        //    if (add != null)
        //    {
        //        return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Inserted", data = add });
        //    }
        //    else
        //    {
        //        return Request.CreateResponse(HttpStatusCode.InternalServerError, new { data = add });
        //    }
        //}


        //[Route("api/close/update")]
        //[HttpPost]
        //public HttpResponseMessage UpdatedCheck(CloseInvestDTO member)
        //{
        //    var extr = CloseInvestService.Update(member);
        //    if (extr != null)
        //    {
        //        return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Updated!", data = extr });
        //    }
        //    else
        //    {
        //        return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = "Error While updating!", data = extr });
        //    }
        //}
        //[Route("api/close/getall")]
        //[HttpGet]
        //public HttpResponseMessage GetAllClose()
        //{
        //    var data = CloseInvestService.CustumeView_Get();
        //    return Request.CreateResponse(HttpStatusCode.OK, data);
        //}
        //[Route("api/cl/confirmlease/confirm")]
        //[HttpPost]
        //public HttpResponseMessage AddCL(ConfirmLeaseDTO member)
        //{
        //    var add = ConfirmLeaseService.Add(member);
        //    if (add != null)
        //    {
        //        return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Inserted", data = add });
        //    }
        //    else
        //    {
        //        return Request.CreateResponse(HttpStatusCode.InternalServerError, new { data = add });
        //    }
        //}
    }
}
