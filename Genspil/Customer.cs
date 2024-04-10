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

        /*public void AvailabilityNotice(Gamegroup[] gamegroups, Warehouse warehouse)
        {
            foreach (string requestTitle in this.titles)
            {
                //gemmer det index i gamegroups der svarer til hvor spillet ligger
                //int gamegroupIndex= warehouse.SearchTitle(warehouse.gamegroups, requestTitle);

                //Gemmer den fundne gamegroup.
                Gamegroup gamegroup = warehouse.SearchTitle(gamegroups, requestTitle);
                //tror altså ikke vi kan gøre det sådan her, vi er nødt til at ittere igennem alle indekspladser i games array or checke om de er tomm

                if (gamegroup != null)
                {
                    Console.WriteLine(gamegroup.title + " er på lager.");
                    Console.WriteLine("Der kan vælges mellem følgende spil:");
                    gamegroup.PrintGamegroup();
                }
                else Console.WriteLine("Spillet " + requestTitle + " er ikke på lager");
            }

        }*/
    }
}
