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

        public static bool checkUserRemoteAvailability(string mobile)
        {
            using (POCDBContext context = new POCDBContext())
            {
                bool availability = false;
                ObjectResult OR = context.spCheckAvailability(mobile);
                foreach (dynamic R in OR) availability = (R > 0) ? true : false;
                return availability;
            }
        }

    }
}
