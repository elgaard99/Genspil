namespace Genspil
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            Gamegroup[] gamegroups =
            {
                new Gamegroup("Matador", new[] { 2, 4 }, new[] { 10, 99 }, new[] { "børn", "strategi" }, 199.95F, new[] { 1F, 0.9F, 0.8F, 0.7F }),
                new Gamegroup("UNO", new[] { 2, 6 }, new[] { 10, 99 }, new[] { "børn", "strategi" }, 199.95F, new[] { 1F, 0.9F, 0.8F, 0.7F }),
                new Gamegroup("Catan", new[] { 3, 12 }, new[] { 10, 99 }, new[] { "brætspil", "strategi" }, 199.95F, new[] {1F, 0.9F, 0.8F, 0.7F }),
                new Gamegroup("Kalaha", new[] { 2, 6 }, new[] { 10, 12 }, new[] { "kugler", "strategi" }, 199.95F, new[] {1F, 0.9F, 0.8F, 0.7F })
            };
            
            Referencenummer: "Matador-0001A"
            Warehouse warehouse = new Warehouse(gamegroups);


            warehouse.gamegroups[0].AddGame();
            warehouse.gamegroups[1].AddGame();
            warehouse.gamegroups[1].AddGame();

            warehouse.PrintWarehouse();
            handler.Save(warehouse.gamegroups);

            string[] requestTitles = { "Matador", "UNO", "Catan", "Kalaha" };
            string requestTitles2 = "Matador";
            Request request = new Request(requestTitles);
            Request request2 = new Request(requestTitles2);
            Game One = new Game("Matador", "A", 1);
            Game Two = new Game("Matador", "B", 2);
            gamegroups[0].games[0] = One;
            gamegroups[0].games[1] = Two;
            Game Three = new Game("Uno", "C", 1);
            gamegroups[1].games[0] = Three;
            
                        handler.Save(warehouse.gamegroups);
                        Gamegroup[] gamegroups_ = handler.LoadGamegroups();

                        Warehouse warehouse1 = new Warehouse(gamegroups_);

                        warehouse1.PrintWarehouse();
            
            //warehouse.SearchTitle(gamegroups, "Matador");
            request.AvailabilityNotice(gamegroups, warehouse);

            customer.MakeRequest(request);
            customer.MakeRequest(request2);
            customer.AvailabilityNotice(warehouse);
            Console.WriteLine(customer.ToString());

            customer.EditCustomer(1);

            Menu menu = new Menu();
            Customer[] c = new Customer[] { customer };
            menu.MainMenu(warehouse, c);
            warehouse.CreateGamegroup();

            Gamegroup[] cat = warehouse.SearchCategories("strategi");
            Gamegroup[] numb = warehouse.SearchNumbPlayers(2, 12);


            Customer[] c = new Customer[1];
            customer.EditCustomer();
            Customer customer = new Customer("Daniel", "Scharla");
            customer.customerNumber = 1;
            Customer c = new Customer("Sander", "Andersen", 32323232, "sander@gmail.com");
            c.customerNumber = 2;
            Customer cc = new Customer("Henrik", "Andersen", 67767676, "henrik@gmail.com");
            cc.customerNumber = 3;

            customerdb.AddCustomer(customer);
            customerdb.AddCustomer(cc);
            customerdb.AddCustomer(c);
            */

            // hvordan skal AvailabilityNotice implementeres ?
            // -havde umiddelbarttænkt hver gang AddGame bleev kaldt (altså i slutningen, men tester bugs først før jeg implemenntere det
            // hvordan skal Requests gemmes ?
            // - Som string[] i request.title
            // implementation i menuen så der kan søges på flere kriterier.
            // ret bugs.
            // PrintCustomers() kan gøres pænere...

            // I skal indsætte stien til hvor gamegroupData.txt og customerData.txt gemmes
            Environment.CurrentDirectory = /*"C:\\Visual Studio 2022\\Source\\Repos\\Genspil\\Genspil";*/ "C:\\Users\\dscha\\source\\repos\\Genspil\\Genspil\\";

            DataHandler gamegroupsHandler = new DataHandler("gamegroupData.txt");
            DataHandler customersHandler = new DataHandler("customerData.txt");

            Warehouse warehouse = new Warehouse(gamegroupsHandler.LoadGamegroups());
            CustomerDatabase customerdb = new CustomerDatabase(customersHandler.LoadCustomers());

            Menu menu = new Menu();
            menu.MainMenu(warehouse, customerdb);

            gamegroupsHandler.Save(warehouse.gamegroups);
            customersHandler.Save(customerdb.ToArray());

        }

    }
}

//RETTELSER:
// - Den gik i endless loop hvis du ville slette et spil fra en gamegroup der ikke er spil i. - ÅBEN
