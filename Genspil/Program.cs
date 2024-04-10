namespace Genspil
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // I skal indsætte stien til hvor gamegroupData.txt gemmes
            Environment.CurrentDirectory = "C:\\Users\\dscha\\source\\repos\\Genspil\\Genspil";

            Gamegroup[] gamegroups =
            {
                new Gamegroup("Matador", new[] { 2, 6 }, new[] { 10, 99 }, new[] { "børn", "strategi" }, 199.95F, new[] { 1F, 0.9F, 0.8F, 0.7F }),
                new Gamegroup("UNO", new[] { 2, 6 }, new[] { 10, 99 }, new[] { "børn", "strategi" }, 199.95F, new[] { 1F, 0.9F, 0.8F, 0.7F }),
                new Gamegroup("Catan", new[] { 3, 12 }, new[] { 10, 99 }, new[] { "brætspil", "strategi" }, 199.95F, new[] {1F, 0.9F, 0.8F, 0.7F }),
                new Gamegroup("Kalaha", new[] { 2, 6 }, new[] { 10, 12 }, new[] { "kugler", "strategi" }, 199.95F, new[] {1F, 0.9F, 0.8F, 0.7F })
            };

            Warehouse warehouse = new Warehouse(gamegroups);
            DataHandler handler = new DataHandler("gamegroupData.txt");
            string[] requestTitles = { "Matador", "UNO", "Catan", "Kalaha" };
            string requestTitles2 = "Matador";
            Request request = new Request(requestTitles);
            Request request2 = new Request(requestTitles2);
            Game One = new Game("Matador", "A", 1);
            Game Two = new Game("Matador", "B", 2);
            gamegroups[0].games[0] = One;
            gamegroups[1].games[2] = Two;
            Game Three = new Game("Uno", "C", 1);
            gamegroups[2].games[1] = Three;
            /*
                        handler.Save(warehouse.gamegroups);
                        Gamegroup[] gamegroups_ = handler.LoadGamegroups();

                        Warehouse warehouse1 = new Warehouse(gamegroups_);

                        warehouse1.PrintWarehouse();
            */
            //warehouse.SearchTitle(gamegroups, "Matador");
            //request.AvailabilityNotice(gamegroups, warehouse);
            Customer customer = new Customer();
            customer.customerNumber = 1234;
            //customer.requests = new[] { request };
            customer.MakeRequest(request);
            customer.MakeRequest(request2);
            Console.WriteLine(customer.ToString());
            Console.ReadLine();

            /*
Titel:kalaha
Kategorier:
- Noget andet
- Terningspil
Spillere: 2-2
Alders anbefaling: 0-0 år
Pris for tilstand A: 1,2156
Pris for tilstand B: 2,213
Pris for tilstand C: 3,132
Pris for tilstand D: 5,312
Pris for tilstand E: 4,532

Titel:Ludo
Kategorier:
- Børnevenlig
- Terningspil
Spillere: 2-4
Alders anbefaling: 0-0 år
Pris for tilstand A: 1,2423
Pris for tilstand B: 2,13
Pris for tilstand C: 3,132
Pris for tilstand D: 5,312
Pris for tilstand E: 4,532

Titel:Matador
Kategorier:
- Brætspil
- Strategi
- Terningspil
Spillere: 2-4
Alders anbefaling: 0-0 år
Pris for tilstand A: 1,2432
Pris for tilstand B: 2,213
Pris for tilstand C: 3,132
Pris for tilstand D: 5,312
Pris for tilstand E: 4,532

Titel:uno
Kategorier:
- Børnevenlig
- Kortspil
Spillere: 2-8
Alders anbefaling: 0-0 år
Pris for tilstand A: 1,22
Pris for tilstand B: 2,13
Pris for tilstand C: 3,132
Pris for tilstand D: 5,312
Pris for tilstand E: 4,532

*/
        }

    }
}
