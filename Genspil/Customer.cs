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
        

        //Demme er vel ikke færdig?? Har givet mit bud på alle mulige constructore
        public Customer(string firstName)
        {
            this.firstName = firstName;
        }

        public Customer(string firstName, string lastName)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.phoneNumber = 0;
            this.email = "";
            this.customerNumber = -1;

        }
        public Customer(string firstName, string lastName, int phoneNumber)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.phoneNumber = phoneNumber;
        }

        public Customer(string firstName, string lastName, int phoneNumber, Request[] requests)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.phoneNumber = phoneNumber;
            this.requests = requests;
        }

        public Customer(string firstName, string lastName, string email)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.email = email;
        }

        public Customer(string firstName, string lastName, string email, Request[] requests)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.email = email;
        }

        public Customer(string firstName, string lastName, int phoneNumber, string email)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.phoneNumber = phoneNumber;
            this.email = email;
            
        }

        public Customer(string firstName, string lastName, int phoneNumber, string email, Request[] requests)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.phoneNumber = phoneNumber;
            this.email = email;
        }

        public void MakeRequest()
        {
            
            Console.Clear();

            Console.Write("Hvilken title skal der laves en forespørgsel på (enter for at gå tilbage): ");
            string title = Console.ReadLine();

            if (title != "")
            {
                Request request = new Request(title);

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

        public void EditCustomer()
        {
            Console.WriteLine("Vælg hvad du vil redigere");
            Console.WriteLine("1. Fornavn " + firstName);
            Console.WriteLine("2. Efternavn" + lastName);
            Console.WriteLine("3. Telefon nummer" + phoneNumber);
            Console.WriteLine("4. E-mail" + email);
            Console.WriteLine("5. Efterspørgsel");
            Console.WriteLine("6. Opret Efterspørgsel");

            int choice = Convert.ToInt32(Console.ReadLine());
            if (choice >= 1 || choice <= 5)
            {
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Indtast et nyt fornavn: ");
                        this.firstName = Console.ReadLine();
                        break;
                    case 2:
                        Console.WriteLine("Indtast et nyt efternavn: ");
                        this.lastName = Console.ReadLine();
                        break;
                    case 3:
                        Console.WriteLine("Indtast et nyt telefon nummer: ");
                        this.phoneNumber = Convert.ToInt32(Console.ReadLine());
                        break;
                    case 4:
                        Console.WriteLine("Indtast en nyt email: ");
                        this.email = Console.ReadLine();
                        break;
                    case 5:
                        EditRequest();
                        break;

                    case 6:
                        MakeRequest();
                        break;
                }
            }
        }

        public void EditRequest()
        {
            Console.WriteLine("Vælg et tal for hvilken efterspørgsel du vil redigere:");
            int i = 1;
            foreach (Request request in requests)
                {
                    if (request != null)
                    {
                        Console.WriteLine("Request " + i + ":");
                        foreach (string title in request.titles)
                        {
                            Console.WriteLine("-" + title);
                        }
                        i++;
                    }
                    
                }
            Console.WriteLine("Vælg et tal for den indtastning der skal redigeres:");
            Request requestChoice = requests[Convert.ToInt32(Console.ReadLine())-1];

            Console.WriteLine("Vælg hvilken titel du vil redigere:");
            int j = 1;
            foreach (string title in requestChoice.titles)
            {
                Console.WriteLine( j + " " + title);
                j++;
            }
            Console.WriteLine("Vælg et tal for den titel der skal redigeres");
            int titleIndex = Convert.ToInt32(Console.ReadLine());
            string titleChoice = requestChoice.titles[titleIndex];
            Console.WriteLine("Indtast efterspørgsel:");
            requestChoice.titles[titleIndex] = Console.ReadLine();
           
        }
    }
}
