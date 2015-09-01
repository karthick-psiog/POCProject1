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
        [Route("customer/mobile")]
        public String CheckAvailability([FromUri] String mobile)
        {
            return "mobile number is available : " + mobile.ToString();
        }

        [HttpGet()]
        [Route("servicearea/pin")]
        public String CheckServiceability(String PIN)
        {
            return "PIN is available: " +PIN.ToString();
        }

        [HttpGet()]
        [Route("remotecustomer/mobile")]
        public IHttpActionResult CheckRemoteAvailability(String mobile)
        {
            return Ok("Remote Cutomer mobile number is available: " + mobile.ToString());
        }

        [HttpPost()]
        [Route("registeruser")]
        public IHttpActionResult RegisterUser(User userinfo)
        {
            
            return Ok("Successfully Registered" + userinfo.firstname.ToString());
        }

        [HttpPost()]
        [Route("remotenotify")]
        public IHttpActionResult RemoteNotification()
        {
            return Ok("Remote Notification is successfully completed");
        }
        
    }
}
