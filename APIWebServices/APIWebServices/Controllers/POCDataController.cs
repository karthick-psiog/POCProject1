using APIWebServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;

namespace APIWebServices.Controllers
{
    [RoutePrefix("")]
    //[Authorize]
    public class POCDataController : ApiController
    {
        [Route("")]
        public IHttpActionResult Get()
        {
            //ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            //var userName = principal.Claims.Where(c => c.Type == "sub").Single().Value;
            return Ok("You are allowed to request data");
        }

        [HttpGet()]
        [Route("customer/mobile/{mobilenum}")]
        public HttpResponseMessage CheckAvailability(String mobilenum)
        {
            try
            { 
                if (mobilenum == null)
                    return Request.CreateResponse(HttpStatusCode.OK, "False");
                else
                    return Request.CreateResponse(HttpStatusCode.OK, "True");
             }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Error Message : " + ex.ToString());
            }
        }

        [HttpGet()]
        [Route("servicearea/pin/{PINCode}")]
        public HttpResponseMessage CheckServiceability(String PINCode)
        {
            try
            { 
                if (PINCode == null)
                    return Request.CreateResponse(HttpStatusCode.OK, "False");
                else
                    return Request.CreateResponse(HttpStatusCode.OK, "True"); 
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Error Message : " + ex.ToString());
            }

        }

        [HttpGet()]
        [Route("remotecustomer/mobile/{mobilenum}")]
        public HttpResponseMessage CheckRemoteAvailability(String mobilenum)
        {
            try
            { 
                if (mobilenum == null)
                    return Request.CreateResponse(HttpStatusCode.OK, "False");
                else
                    return Request.CreateResponse(HttpStatusCode.OK, "True");
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Error Message : " + ex.ToString());
            }
        }

        [HttpPost()]
        [Route("registeruser")]
        public HttpResponseMessage RegisterUser(User userinfo)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, " Successfully Registered " + userinfo.firstname);
            }
            catch (Exception ex)  
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Error Message: " + ex.ToString());  
            }  
        }

        [HttpPost()]
        [Route("remotenotify")]
        public HttpResponseMessage RemoteNotification()
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, " Successfully Sent ");
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Error Message : " + ex.ToString());
            }
        }
        
    }
}
