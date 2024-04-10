using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genspil
{
    internal class Customer
    {
        public string firstName;
        public string lastName;
        public int phoneNumber;
        public string email;
        public int customerNumber;
        public Request[] requests = new Request[100]; // maks 100 forespørgelser

        public Customer(string firstName = "", int ?phoneNumber = null)
        {
            this.firstName = firstName;
        }

        public void MakeRequest(Request request)
        {
            int i = 0;
            foreach (Request request2 in requests)
            {
                if (requests[i] != null)
                {
                    i++;
                }
                else
                {
                    this.requests[i] = request;
                    break;
                }
            }
        }
        public void AvailabilityNotice(Warehouse warehouse)
        {
            foreach (Request request in requests)
            {
                if (request != null)
                {
                    request.AvailabilityNotice(warehouse.gamegroups, warehouse);
                }
                else
                {

                }
            }
        }
    }
}
