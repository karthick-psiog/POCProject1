using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data;
using System.Data.Entity.Core.Objects;
namespace BusinessObjects.DAL
{
    class DataStore
    {
        public static List<ServiceArea> getServiceAreas(string pin) 
        {
            using (POCDBContext context = new POCDBContext())
            {
                List<ServiceArea> Pins = context.FunGetServiceArea(pin).ToList();
                return Pins;
            }
            
        }

        public static bool findByPin(string pin)
         {
             bool avail = false;
             return avail;
         } 

        public static Customer findUserByMobile(string mobile)
           {
               using (POCDBContext context = new POCDBContext())
               {
                   Customer customer = new Customer();
                   return customer;
               } 
           }
        
        public static Customer getUser(int userid)
        {
            using (POCDBContext context = new POCDBContext())
            {
                dynamic customer  = context.FunGetCustomer(userid).FirstOrDefault(); 
                return (Customer) customer;
            }
        }
        public static Customer findUserByEmail(string email) 
        {
            using (POCDBContext context = new POCDBContext())
            {
                Customer customer = new Customer();
                return customer;
            } 
        }

        public static  bool checkUserAvailability(string mobile)
        {
            using (POCDBContext context = new POCDBContext())
            {
                bool availability = false;
                ObjectResult OR=context.spCheckAvailability(mobile);
                foreach (dynamic R in OR)  availability=  (R > 0)? true:false;                     
                return availability;
            }
        }
        public static bool saveUser(Customer customer, string password)
        {
            using (POCDBContext context = new POCDBContext())
            {
               ObjectParameter userid=new ObjectParameter("userid" , 0);
               context.spInsertCustomer(password, customer.mobile, customer.PIN, customer.DOB, customer.firstname, customer.lastname, customer.address, customer.city, customer.state, customer.country, userid);
               return ((int)userid.Value == 0) ? false : true;
            }
        }
        public static RemoteCustomer checkUserRemoteAvailability(string mobile)
        {
            using (POCDBContext context = new POCDBContext())
            {
                RemoteCustomer customer = new RemoteCustomer();
                dynamic customers = context.spCheckRemoteAvailability(mobile).FirstOrDefault();

                if (customers != null)
                {
                    customer.address = customers.address;
                    customer.mobile = customers.mobile;
                    customer.DOB = customers.DOB;
                    customer.firstname = customers.firstname;
                    customer.lastname = customers.lastname;
                    customer.address = customers.address;
                    customer.city = customers.city;
                    customer.PIN = customers.PIN;
                    customer.state = customers.state;
                    customer.country = customers.country;
                }
                else
                    customer = (RemoteCustomer)customers; 
                return  customer;
            }
        }

        public static List<Dictionary<string, int>> getEventTypes()
        {
            using (POCDBContext context = new POCDBContext())
            {
               dynamic eventtypes = context.FunGetEventType();
               return eventtypes;
            } 
        }

        public static void writeEventLog(AuditLog AL) 
        {
            using (POCDBContext context = new POCDBContext()) 
                {
                 context.spInsertTransLog(AL.userid, AL.eventtypeid, AL.source, AL.logmessage);
                 }
        }

        public static void writeEmailLog(EmailLog EL,AuditLog AL)
        {
            using (POCDBContext context = new POCDBContext())
            {
                context.spInsertEmailLog(AL.userid, AL.eventtypeid, AL.source, AL.logmessage, EL.emailaddress, EL.emailstatus);
            }
        }
    }
}
