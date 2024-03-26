using System.Net.Cache;

namespace Genspil
{
    internal class Customer
    {
        public string Name { get; set; }
        public int CustomerNumber { get; set; }
        public Request[] Requests { get; set; }
        
        //constructer 
        public Customer(string name, int customerNumber) 
        {
            Name = name;
            CustomerNumber = customerNumber;
            Requests = new Request[0];
        }
        public class Request
        {
            // properties
            public string MethodName { get; set; }

            //constructer 
            public Request(string methodName)
            {
                MethodName = methodName;
            }

        }
    
    }   

        
}
