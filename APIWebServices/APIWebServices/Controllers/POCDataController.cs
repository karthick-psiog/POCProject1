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
    [Authorize]
    public class POCDataController : ApiController
    {
        [Route("")]
        public IHttpActionResult Get()
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var userName = principal.Claims.Where(c => c.Type == "sub").Single().Value;
            return Ok("You are allowed to request data");
        }

        [Route("customer/mobile")]
        public IHttpActionResult CheckAvailability()
        {
            return Ok("mobile number is available : ");
        }

        [Route("servicearea/pin")]
        public IHttpActionResult CheckServiceability()
        {
            return Ok("PIN is available");
        }

        [Route("remotecustomer/mobile")]
        public IHttpActionResult CheckRemoteAvailability()
        {
            return Ok("Remote Cutomer mobile number is available");
        }

        [Route("registeruser")]
        public IHttpActionResult RegisterUser()
        {
            return Ok("Successfully Registered");
        }

        [Route("remotenotify")]
        public IHttpActionResult RemoteNotification()
        {
            return Ok("Remote Notification is successfully completed");
        }
        
    }
}
