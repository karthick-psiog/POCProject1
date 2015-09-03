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
             Customer customerlist = CR.getUser(5);
             
            Console.WriteLine(customerlist.firstname);

            Customer customer = new Customer();
            customer.address = "no5 anandaroad";
            customer.city = "Chennai";
            customer.country = "India";
            customer.DOB = DateTime.Today;
            customer.firstname = "Kumar";
            customer.lastname = "CM";
            customer.mobile = "9874563222";
            customer.PIN = "600017";
            customer.state = "Tamilnadu";
            if (CI.saveUser(customer, "hellopwd")) 
                { 
                    Console.WriteLine("Inserted Successfully"); 
                } 
            else 
                { 
                    Console.WriteLine("Failed to Insert"); 
                }


            Console.WriteLine(CR.checkUserRemoteExists("9874563210"));
            Console.WriteLine(CR.checkUserExists("9874563222"));

            dynamic SArea = SAI.getServiceAreas();
            foreach (var item in SArea)
            {
                Console.WriteLine(item.PIN); 
            }
            Console.WriteLine(SAI.checkServiceability());
    
        }
    }
}
