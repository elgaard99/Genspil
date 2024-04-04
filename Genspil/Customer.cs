using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genspil
{
    internal class Customer
    {
        public string firstName;
        public string lastName;
        public int id;
        public Request[] requests = new Request[100]; // maks 100 forespørgelser

        public Customer()
        {
            
        }
    }
}
