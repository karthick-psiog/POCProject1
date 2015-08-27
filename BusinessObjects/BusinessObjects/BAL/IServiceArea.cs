using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.BAL
{
    interface IServiceArea
    {
        string Pin { get;}
        List<string> getServiceAreas();
        bool findByPin(string pin);
    }
}
