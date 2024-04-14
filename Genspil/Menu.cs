using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Genspil
{
    internal class Menu
    {

        string title;
        public string Title { get; set; }

        string[] menuItems;
        
        public Menu()
        {
            this.title = "Hoved Menu";
            this.menuItems = new string[]
            {
                "Søg efter spil på lageret",
                "Print lagerliste",
                "Kunder",
                "Rediger Lager"
            };
        }

        public Menu(string title, string[] menuItems)
        {
            this.title = title;
            this.menuItems = menuItems;
        }

        void ShowMenu()
        {
            Console.Clear();

            Console.WriteLine(this.title + "\n");

            int counter = 1;
            foreach (string subMenu in menuItems)
            {
                Console.WriteLine($"{counter}. {subMenu}");
                counter++;
            }

            Console.Write("\n\n(Tryk menupunkt eller 0 for at afslutte) ");
        }

        int SelectMenuItem()
        {
            ShowMenu();

            while (true)
            {

                if (int.TryParse(Console.ReadLine(), out int menuIdx))
                {
                    if (menuIdx == 0)
                        return -1;

                    else if (menuIdx > 0 && menuIdx <= menuItems.Length)
                        return menuIdx -1;
                }

                else
                { Console.WriteLine("Du skal vælge et menupunkt mellem 0 og " + menuItems.Length); }
            }
        }
        public void CheckAvailability(Warehouse warehouse, CustomerDatabase customerDatabase)
        {
            customerDatabase.customerDatabase.ForEach(delegate (Customer customer)
            {
                customer.AvailabilityNotice(warehouse);
            });
        }
        public void MainMenu(Warehouse warehouse, CustomerDatabase customerDatabase)
        {

            while (true)
            {
                Console.Clear();

                int selectedMenu = SelectMenuItem();

                if (selectedMenu == -1)
                    break;

                switch ( menuItems[selectedMenu] ) 
                {

                    case "Søg efter spil på lageret":
                        SearchWarehouse(warehouse);
                        break;

                    case "Print lagerliste":
                        warehouse.PrintWarehouse();
                        break;

                    case "Kunder":
                        CustomerMenu(customerDatabase);
                        CheckAvailability(warehouse, customerDatabase);
                        break;

                    case "Rediger Lager":
                        EditWarehouse(warehouse);
                        CheckAvailability(warehouse, customerDatabase);
                        break;
                
                }

            }

        }

        void SearchWarehouse(Warehouse warehouse) 
        {
            Gamegroup[]? results;
            Menu subMenu = new Menu
                (
                "Søg efter spil på lageret",
                new[]
                {
                    "Søg efter title",
                    "Søg efter kategori",
                    "Søg efter antal spillere",
                    "Søg efter alder",
                }
            );

            while (true)
            {
                Console.Clear();

                int selectedMenu = subMenu.SelectMenuItem();

                if (selectedMenu == -1)
                    break;

                Console.Clear();

                switch (subMenu.menuItems[selectedMenu])
                {
                    case "Søg efter title":
                        SearchTitle();
                        break;

                    case "Søg efter kategori":
                        SearchCategori();
                        break;

                    case "Søg efter antal spillere":
                        SearchNumberOfPlayers();
                        break;

                    case "Søg efter alder":
                        SearchAgeRecommend();
                        break;

                }

                void SearchTitle()
                {
                    Console.Write("Titel på spillet: ");
                    Gamegroup[] gamegroups = warehouse.gamegroups;
                    Gamegroup group = warehouse.SearchTitle(gamegroups, Console.ReadLine());
                    
                    if (group != null)
                        if (!group.games.All(x => x==null))
                            group.PrintGamegroup();
                        
                        else
                            Console.WriteLine("Ingen spil på lager med titlen {0}", group.title);

                    Console.Write("(Tryk enter for at komme tilbage)");
                    Console.ReadLine();
                
                }

                void CombineSearchCategori()
                {
                    Console.Write("Kategori: ");

                    results = warehouse.SearchCategories(Console.ReadLine(), results);

                    CombineMenu();

                }
                void SearchCategori()
                {
                    Console.Write("Kategori: ");

                    results = warehouse.SearchCategories(Console.ReadLine());
                    CombineMenu();
                    
                }

                void CombineSearchNumberOfPlayers()
                {
                    Console.Write("Antal spillere: ");
                    int numberOfPlayers = int.Parse(Console.ReadLine());
                    results = warehouse.SearchNumbPlayers(numberOfPlayers, results);

                    CombineMenu();
                }
                void SearchNumberOfPlayers()
                {
                    Console.Write("Antal spillere: ");
                    int numberOfPlayers = int.Parse(Console.ReadLine());
                    results = warehouse.SearchNumbPlayers(numberOfPlayers);
                    CombineMenu();
                }

                void SearchAgeRecommend()
                {

                    Console.Write("Miniums alder: ");
                    int.TryParse(Console.ReadLine(), out int min);

                    Console.Write("Maks alder: ");
                    int.TryParse(Console.ReadLine(), out int max);

                    results = warehouse.SearchAgeRecommend(min, max);
                    CombineMenu();

                }

                void CombineSearchAgeRecommend()
                {

                    Console.Write("Miniums alder: ");
                    int.TryParse(Console.ReadLine(), out int min);

                    Console.Write("Maks alder: ");
                    int.TryParse(Console.ReadLine(), out int max);

                    warehouse.SearchAgeRecommend(min, max, results);

                    CombineMenu();

                }

                void CombineMenu()
                {
                    Console.WriteLine("Tryk 0 for at vende tilbage til søge-menuen, eller et andet tal for at kombinere søgning");
                    int combineContinue = Convert.ToInt32(Console.ReadLine());
                    if (combineContinue == 0) SearchWarehouse(warehouse);
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Vælg hvad du vil kombinere søgningen med, eller tryk 0 for at afslutte og se dine resultater:");
                        Console.WriteLine("1. Kategori");
                        Console.WriteLine("2. Antal spillere");
                        Console.WriteLine("3. Alder");
                        int combineSearch = Convert.ToInt32(Console.ReadLine());
                        if (combineSearch == 0)
                        {
                            foreach (Gamegroup result in results)
                            {
                                if (result != null)
                                    Console.WriteLine(result.title + " matchede dit søgekriterie");
                            }
                            Console.WriteLine("Tryk på enter for at vende tilbage til søge-menuen");
                            Console.ReadLine();
                            SearchWarehouse(warehouse);


                        }
                        if (combineSearch == 1)
                        {
                            CombineSearchCategori();
                        }
                        else if (combineSearch == 2)
                        {
                            CombineSearchNumberOfPlayers();
                        }
                        else if (combineSearch == 3)
                        {
                            CombineSearchAgeRecommend();
                        }
                        else
                        {
                            Console.WriteLine("Du skal vælge et tal mellem 0 og 3");
                            CombineMenu();
                        }

                    }
                }
            }

        }

        void CustomerMenu(CustomerDatabase customerDatabase)
        {

            Menu subMenu = new Menu
                (
                "Kunder",
                new[]
                {
                    "Opret Kunde",
                    "Slet Kunde",
                    "Rediger Eksisterende Kunde",
                    "Print Kunder"
                }
            );

            while (true)
            {
                Console.Clear();

                int selectedMenu = subMenu.SelectMenuItem();

                if (selectedMenu == -1)
                    break;

                Console.Clear();

                switch (subMenu.menuItems[selectedMenu])
                {
                    case "Opret Kunde":
                        customerDatabase.AddCustomer();
                        break;

                    case "Slet Kunde":
                        customerDatabase.RemoveCustomer();
                        break;

                    case "Rediger Eksisterende Kunde":
                        EditCustomer();
                        break;

                    case "Print Kunder":
                        customerDatabase.PrintCustomers();
                        Console.Write("\n\n(Tryk enter for at gå tilbage) ");
                        Console.ReadLine();
                        break;
                }

                void EditCustomer()
                {
                    Console.Clear();
                    customerDatabase.PrintCustomers();

                    Console.Write("Indtast kundenr. på den kunde du vil redigere (eller enter): ");

                    string customerNo = Console.ReadLine();
                    if (customerNo != "")
                    {
                        int.TryParse(customerNo, out int customerId);

                        foreach (Customer c in customerDatabase.customerDatabase)
                            if (c.customerNumber == customerId)
                            {
                                c.EditCustomer();
                                break;
                            }

                    }
                
                }

            }

        }

        void EditWarehouse(Warehouse warehouse)
        {
            Menu subMenu = new Menu
                (
                "Rediger Lager",
                new[]
                {
                    "Opret ny gamegroup",
                    "Slet Eksisterende gamegroup",
                    "Rediger spil på lageret"
                }
            );

            while (true)
            {
                Console.Clear();

                int selectedMenu = subMenu.SelectMenuItem();

                if (selectedMenu == -1)
                    break;

                switch (subMenu.menuItems[selectedMenu])
                {
                    case "Opret ny gamegroup":
                        warehouse.CreateGamegroup();
                        break;

                    case "Slet Eksisterende gamegroup":
                        warehouse.RemoveGamegroup();
                        break;

                    case "Rediger spil på lageret":
                        warehouse.EditGames();
                        break;

                }
            }

        }


    }

}
