using BusinessObjects.BAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class Class1
    {

        public static void Main(string[] a)
        {
            BusinessObjects.BAL.ServiceAreaImpl SAI = new BusinessObjects.BAL.ServiceAreaImpl("");
            BusinessObjects.BAL.CustomerImpl CI = new CustomerImpl();
            BusinessObjects.BAL.CustomerRegistration CR = new CustomerRegistration();
            CR.checkUserExists("98745632");

            Customer customer = new Customer();
            customer.address = "no5 anandaroad";
            customer.city = "Chennai";
            customer.country = "India";
            customer.DOB = DateTime.Today;
            customer.firstname = "Kumar";
            customer.lastname = "CM";
            customer.mobile = "9874563212";
            customer.PIN = "600017";
            customer.state = "Tamilnadu";
            if (CI.saveUser(customer, "hellopwd")) { Console.WriteLine("Inserted Successfully"); } else { Console.WriteLine("Failed to Insert"); }


            dynamic SArea= SAI.getServiceAreas();



            foreach (var item in SArea)
            {
                Console.WriteLine(item.PIN); 
            }

            Console.WriteLine(SAI.checkServiceability());
    
        }
    }
}
