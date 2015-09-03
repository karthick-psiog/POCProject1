using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects.DAL;

namespace BusinessObjects.BAL
{
    class CustomerImpl : ICustomer
    {
        public bool saveUser(Customer customer,string password) {
           return DataStore.saveUser(customer, password);
        }
        public void deleteUser(Customer customer) { }

        public Customer findUserByMobile(string mobile)
        {
            return DataStore.findUserByMobile(mobile);
        }

        public Customer findUserByEmail(string email) 
        {
            return DataStore.findUserByEmail(email);
        }
    
    
    }
}
