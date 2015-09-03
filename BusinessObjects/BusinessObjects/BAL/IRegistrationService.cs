using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.BAL
{
    interface IRegistrationService
    {
        bool checkUserExists(string mobile);
        bool registerUser(Customer customer,string password);
        Customer getUser(int userid);
    }
}
