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
        //mindre "Bug" i denne, da hvis du kommer til at tilføje en anden request der allerede eksistere printer den igen. Fx hvis der er oprettet 2 x matador, printes det 2 gange
        public void AvailabilityNotice(Warehouse warehouse)
        {
            foreach (Request request in requests)
            {
                if (request != null)
                {
                    foreach (string requestTitle in request.titles)
                    {
                        //gemmer det index i gamegroups der svarer til hvor spillet ligger
                        //int gamegroupIndex= warehouse.SearchTitle(warehouse.gamegroups, requestTitle);

                        //Gemmer den fundne gamegroup.
                        Gamegroup gamegroup = warehouse.SearchTitle(warehouse.gamegroups, requestTitle);
                        //tror altså ikke vi kan gøre det sådan her, vi er nødt til at ittere igennem alle indekspladser i games array or checke om de er tomm

                        if (gamegroup != null && gamegroup.games[0] != null)
                        {
                            Console.WriteLine(gamegroup.title + " er på lager.");
                            Console.WriteLine("Der kan vælges mellem følgende spil:");
                            gamegroup.PrintGamegroup();
                        }
                        else Console.WriteLine("Spillet " + requestTitle + " er ikke på lager");
                    }
                }
            }
        }
    }
}
