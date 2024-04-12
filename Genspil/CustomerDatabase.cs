using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genspil
{
    internal class CustomerDatabase
    {
        public List<Customer> customerDatabase = new List<Customer>();


        public void AddCustomer(Customer customer) 
        {
            customerDatabase.Add(customer);
        }

        public void AddCustomer()
        {

            string[] info = { "Fornavn", "Efternavn", "Telefonnummer", "Email" };
            string[] info2 = new string[4];

            for (int i = 0; i < info.Length; i++)
            {

                do
                {
                    
                    Console.Clear();

                    if (i > 1) { Console.WriteLine("Tryk enter for at skippe"); }
                    Console.Write(info[i] + ": ");

                    info2[i] = Console.ReadLine();

                }
                while (info2[0] == "");

            }

            Customer customer = new Customer(info2[0], info2[1]);

            if (info2[2] != "")
            {
                int phonenumber = 1;
                do
                {
                    if (int.TryParse(info2[2], out phonenumber))
                    {
                        customer.phoneNumber = phonenumber;
                        break;
                    }
                        

                    Console.Write("Du skal indtaste et gyldigt telefonnummer: ");
                    info2[2] = Console.ReadLine();
                }
                while (customer.phoneNumber == 0);
            }

           if (info2[3] != "")
                customer.email = info2[3];

            int customerId = 0;
            foreach (Customer c in customerDatabase)
                if (c.customerNumber > customerId)
                    customerId = c.customerNumber;

            customer.customerNumber = customerId +1;

            customerDatabase.Add(customer);

        }

        public void RemoveCustomer(Customer customer)
        {
            customerDatabase.Remove(customer);
        }

        public void RemoveCustomer()
        {

            Console.Clear();
            PrintCustomers();

            Console.Write("Indtast kundenr. på den kunde du vil slette (eller enter): ");

            string customerNo = Console.ReadLine();
            if (customerNo != "")
            {
                int.TryParse(customerNo, out int customerId);

                foreach (Customer c in customerDatabase)
                    if (c.customerNumber == customerId)
                    {
                        customerDatabase.Remove(c);
                        break;
                    }

            }

        }

        public void PrintCustomers()
        {

            Console.Clear();

            Console.WriteLine("Navn\t\t\tTelefonnr.\tEmail\t\t\tKundenr.");

            foreach (Customer c in customerDatabase)
                Console.WriteLine(
                    $"{c.lastName.ToUpper()}, {c.firstName}\t" +
                    $"{(c.phoneNumber != 0 ? c.phoneNumber : "\t")}\t" +
                    $"{(c.email != null ? c.email : "\t")}\t" +
                    $"{c.customerNumber}");

            

        }
    }

}
