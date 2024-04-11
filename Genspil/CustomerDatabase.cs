using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genspil
{
    internal class CustomerDatabase
    {
        public List<Customer> customerDatabase;
        public void AddCustomer(Customer customer) 
        {
            customerDatabase.Add(customer);
        }

        public void removeCustomer(Customer customer)
        {
            customerDatabase.Remove(customer);
        }

    }
}
