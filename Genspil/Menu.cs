using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
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

        public void MainMenu(Warehouse warehouse, Customer[] customers)
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
                        Console.WriteLine("Du vil søge efter et spil");
                        Console.Write("\n\n(Tryk menupunkt eller 0 for at afslutte) ");
                        Console.ReadLine();
                        break;

                    case "Print lagerliste":
                        warehouse.PrintWarehouse();
                        break;

                    case "Kunder":
                        CustomerMenu(customers);
                        Console.Write("Tast enter for at komme til Hovedmenuen");
                        Console.ReadLine();
                        break;

                    case "Rediger Lager":
                        EditWarehouse(warehouse);
                        break;
                }

            }
        }

        void CustomerMenu(Customer[] customers)
        {
            void CreateCostumer()
            {
            }

            void EditCustomer()
            {
            }

            void RemoveCustomer()
            {
            }

            void CreateRequst()
            {
                //find customer
                //customer.MakeReequest()
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
