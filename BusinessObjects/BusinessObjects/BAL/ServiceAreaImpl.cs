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
        string _pin;
      //  public ServiceAreaImpl() { }    //Comment the default constructor to avoid create object without pin. 
       
        public ServiceAreaImpl(string p) 
        {
            _pin = p;
        }

        public string Pin { get { return _pin; } private set { _pin = value; } }

        

        public  List<ServiceArea> getServiceAreas()
        {
            return DataStore.getServiceAreas(Pin);
        }

       
        public   bool checkServiceability()
        {
            dynamic servicearea = DataStore.getServiceAreas(Pin);
            return (servicearea.Count == 0) ? false : true;
        }

        
        public bool findByPin(string pin)
        {
            return DataStore.findByPin(Pin);      
        }
    }
}
