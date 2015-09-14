using BusinessObjects.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.BAL
{
    class CustomerRegistration:IRegistrationService
    {
        public bool checkUserExists(string mobile)
        {
          return DataStore.checkUserAvailability(mobile);          
        }

        public RemoteCustomer checkUserRemoteExists(string mobile)
        {
           return  DataStore.checkUserRemoteAvailability(mobile);

        }

        public bool registerUser(Customer customer, string password)
        {
            return DataStore.saveUser(customer, password);            
        }

        public  Customer getUser(int userid) 
        {
            return DataStore.getUser(userid);
        }

    }
}
