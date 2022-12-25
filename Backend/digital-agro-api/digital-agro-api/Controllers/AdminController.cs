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
    public class AdminController : ApiController
    {
        [Route("api/admin")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            try
            {
                var data = AdminService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch(Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        [Route("api/admin/username")]
        [HttpGet]
        public HttpResponseMessage Getuser()
        {
            try
            {
                var data = AdminService.GetUsername();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        [Route("api/admin/{id}")]
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            try
            {
                var data = AdminService.Get(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        [Route("api/admin/add")]
        [HttpPost]
        public HttpResponseMessage Post(AdminDTO member)
        {
            try
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
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        [Route("api/admin/delete/{id}")]
        [HttpPost]
        public HttpResponseMessage Delete(int id)
        {
            try
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
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        [Route("api/admin/update")]
        [HttpPost]
        public HttpResponseMessage Update(AdminDTO member)
        {
            try
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
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        //lease land to assig to gov

        [Route("api/Leaseland/byadmin/unavailable")]
        [HttpGet]
        public HttpResponseMessage GetUnabaleableLeaseLand()
        {
            var data = LeaseLandsService.GetUnAvailableLeasedLand();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        //Investland land to assig to gov

        [Route("api/Investland/byadmin/unavailable")]
        [HttpGet]
        public HttpResponseMessage GetUnabaleableInvestLand()
        {
            var data = InvestLandsService.GetUnAvailableLeasedLand();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        //assign gov to lease land
        [Route("api/leaseland/assign/assignbygov/{LLid}/{govId}")]
        [HttpPost]
        [Logged_Admin]
        public HttpResponseMessage AssignToLL(int LLid, int govId)
        {
            var extr = LeaseLandsService.UpdateVerification(LLid, govId);
            if (extr != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Changed!", data = extr });
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = "Error While assigning!", data = extr });
            }
        }

        //assign gov to Invest land
        [Route("api/investland/assign/assignbygov/{LLid}/{govId}")]
        [HttpPost]
        [Logged_Admin]
        public HttpResponseMessage AssignToIl(int LLid, int govId)
        {
            var extr = InvestLandsService.UpdateVerification(LLid, govId);
            if (extr != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Changed!", data = extr });
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = "Error While assigning!", data = extr });
            }
        }

        [Logged_Admin]
        [Route("api/invest/admin/Available")]
        [HttpGet]
        public HttpResponseMessage GetAvailable()
        {
            var data = InvestLandsService.GetAvailableInvest();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [Logged_Admin]
        [Route("api/invest/admin/Complete")]
        [HttpGet]
        public HttpResponseMessage GetCompleted()
        {
            var data = InvestLandsService.GetCompleted();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/Leaseland/leased/getnewowner")]
        [HttpGet]
        [Logged_Admin]
        public HttpResponseMessage AlLeased()
        {
            var data = ConfirmLeaseService.CustumeView_Get();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Logged_Admin]
        [Route("api/admin/Invest")]
        [HttpGet]
        public HttpResponseMessage GetIL()
        {
            var data = InvestLandsService.Get();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/adminpass/change/{id}/{password}/{old}")]
        [HttpPost]
        [Logged_Admin]
        public HttpResponseMessage UpdateUserPassword(int id, string password, string old)
        {
            var extr = AdminService.Update(id, password, old);
            if (extr != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Changed!", data = extr });
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = "Error While Changing!", data = extr });
            }
        }
        [Logged_Admin]
        [Route("api/Adminsee/user")]
        [HttpGet]
        public HttpResponseMessage GetUser()
        {
            try
            {
                var data = UsersService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        [Logged_Admin]
        [Route("api/Adminsee/user/{id}")]
        [HttpGet]
        public HttpResponseMessage GetUser(int id)
        {
            try
            {
                var data = UsersService.Get(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [Logged_Admin]
        [Route("api/user/username/{username}")]
        [HttpGet]
        public HttpResponseMessage GetUser(string username)
        {
            try
            {
                var data = UsersService.GetbyUsername(username);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }



    }
}
