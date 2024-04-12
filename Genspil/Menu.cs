﻿using System;
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
                        SearchWarehouse(warehouse);
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

        void SearchWarehouse(Warehouse warehouse) 
        {
            Menu subMenu = new Menu
                (
                "Søg efter spil på lageret",
                new[]
                {
                    "Søg efter title",
                    "Søg efter kategori",
                    "Søg efter antal spillere",
                    "Søg efter alder",
                    "Søg på flere kriterier"
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
                        //warehouse.SearchAgeRecommended();
                        break;

                    case "Søg på flere kriterier":
                        //warehouse.Search()
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

                void SearchCategori()
                {
                    Console.Write("Kategori: ");

                    foreach (string s in warehouse.SearchCategories(Console.ReadLine()))
                        Console.WriteLine(s);

                    Console.Write("\n(Tryk enter for at komme tilbage)");
                    Console.ReadLine();

                }

                void SearchNumberOfPlayers()
                {
                    Console.Write("Antal spillere: ");
                    int numberOfPlayers = int.Parse(Console.ReadLine());
                    warehouse.SearchNumbPlayers(numberOfPlayers, numberOfPlayers);

                    Console.Write("\n(Tryk enter for at komme tilbage)");
                    Console.ReadLine();
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