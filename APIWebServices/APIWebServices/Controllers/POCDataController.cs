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
        public String CheckAvailability(String mobilenum)
        {
            return "mobile number is available : " + mobilenum.ToString();
        }

        [HttpGet()]
        [Route("servicearea/pin/{PINCode}")]
        public String CheckServiceability(String PINCode)
        {
            return "PIN is available: " + PINCode.ToString();
        }

        [HttpGet()]
        [Route("remotecustomer/mobile/{mobilenum}")]
        public IHttpActionResult CheckRemoteAvailability(String mobilenum)
        {
            return Ok("Remote Cutomer mobile number is available: " + mobilenum.ToString());
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
