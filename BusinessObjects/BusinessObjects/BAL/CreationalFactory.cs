using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.BAL
{
    class CreationalFactory
    {
        public static Customer getCustomer()
        {   
            return new Customer();
        }

        public static EmailService getEmail(int port,string host)
        {
            return new EmailService(port,host);
        }

    }
}
