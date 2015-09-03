using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.BAL
{
    interface ICustomer
    {
        bool saveUser(Customer customer, string password);
        void deleteUser(Customer customer);
        Customer findUserByMobile(string mobile);
        Customer findUserByEmail(string email);

    }
}
