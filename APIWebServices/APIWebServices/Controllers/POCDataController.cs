using APIWebServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;
using BusinessObjects.BAL; 
 
namespace APIWebServices.Controllers
{
    [RoutePrefix("")]
    //[Authorize]
    public class POCDataController : ApiController
    {
        CustomerRegistration objCustReg = new CustomerRegistration();

        CustomerImpl objCustImp = new CustomerImpl();

        NotificationImpl objNotiImp = new NotificationImpl();

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
                if (objCustReg.checkUserExists(mobilenum))
                    return Request.CreateResponse(HttpStatusCode.OK, "True");
                else
                    return Request.CreateResponse(HttpStatusCode.OK, "False");
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
                ServiceAreaImpl objSAreaImp = new ServiceAreaImpl(PINCode);

                if (objSAreaImp.checkServiceability())
                    return Request.CreateResponse(HttpStatusCode.OK, "True");
                else
                    return Request.CreateResponse(HttpStatusCode.OK, "False"); 
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Error Message : " + ex.ToString());
            }

        }

        [HttpGet()]
        [Route("remotecustomer/mobile/{mobile}")]
        public HttpResponseMessage CheckRemoteAvailability(String mobile)
        {
            try
            {
                var remotecustomer = objCustReg.checkUserRemoteExists(mobile);

                if (remotecustomer == null)
                    return Request.CreateResponse(HttpStatusCode.OK, "False");
                else
                    return Request.CreateResponse(HttpStatusCode.OK, remotecustomer);
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
                BusinessObjects.Customer customer = new BusinessObjects.Customer();
                customer.firstname = userinfo.firstname;
                customer.lastname = userinfo.lastname;
                customer.address = userinfo.address;
                customer.city = userinfo.city;
                customer.state = userinfo.state;
                customer.country = userinfo.country; 
                customer.PIN = userinfo.PIN;
                customer.DOB = userinfo.DOB;
                customer.mobile = userinfo.mobile;

                if (objCustImp.saveUser(customer, userinfo.Pwd))
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "True");
                }
                else
                { return Request.CreateResponse(HttpStatusCode.OK, "False"); }
            }
            catch (Exception ex)  
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Error Message: " + ex.ToString());  
            }
        }

        [HttpPost()]
        [Route("remotenotify")]
        public HttpResponseMessage RemoteNotification(User userinfo)
        {
            try
            {
                BusinessObjects.Customer customer = new BusinessObjects.Customer();
                customer.firstname = userinfo.firstname;
                customer.lastname = userinfo.lastname;
                customer.address = userinfo.address;
                customer.city = userinfo.city;
                customer.state = userinfo.state;
                customer.country = userinfo.country;
                customer.PIN = userinfo.PIN;
                customer.DOB = userinfo.DOB;
                customer.mobile = userinfo.mobile;

                if (objNotiImp.notifyRemote(customer))
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "True");
                }
                else
                { return Request.CreateResponse(HttpStatusCode.OK, "False"); }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Error Message : " + ex.ToString());
            }
        }
        
    }
}
