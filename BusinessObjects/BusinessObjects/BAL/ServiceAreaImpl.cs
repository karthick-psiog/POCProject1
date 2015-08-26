using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects.DAL;
namespace BusinessObjects.BAL
{
    class ServiceAreaImpl:IServiceArea,IServiceability
    {   
        public ServiceAreaImpl() { }
        public ServiceAreaImpl(string p) 
        {
            Pin = p;
        }

        public string Pin { get; private set { } }

        List<string> IServiceArea.getServiceAreas()
        {
            return DataStore.getServiceAreas();
        }

        bool IServiceArea.findByPin()
        {
            return DataStore.findByPin(Pin);            
        }
    }
}
