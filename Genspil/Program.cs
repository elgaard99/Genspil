namespace Genspil
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Gamegroup[] gamegroups = 
            { 
                new Gamegroup("Matador", new[] { 2, 6 }, new[] { 10, 12 }, new[] { "børn", "strategi" }, 199.95F, new[] { 1F, 0.9F, 0.8F, 0.7F, 0.6F, 0.5F }) 
            };

            Warehouse warehouse = new Warehouse(gamegroups);
            Customer[] customers = [];

            // forskellige games laves i gamegruppen "Matador" og "UNO"
            //warehouse.gamegroups[0].games[0] = new Game("001-A");
            //warehouse.gamegroups[0].games[1] = new Game("002-A");
            //warehouse.gamegroups[0].games[2] = new Game("003-B");

            //warehouse.gamegroups[1] = new Gamegroup("UNO");
            //warehouse.gamegroups[1].games[0] = new Game("001-C");
            //warehouse.gamegroups[1].games[1] = new Game("002-A");
            //warehouse.gamegroups[1].games[2] = new Game("003-B");

            //warehouse.gamegroups[2] = new Gamegroup("Catan");
            //warehouse.gamegroups[2].games[0] = new Game("001-C");
            //warehouse.gamegroups[2].games[1] = new Game("002-A");
            //warehouse.gamegroups[2].games[2] = new Game("003-B");

            warehouse.EditGames();
            warehouse.EditGames();
            warehouse.EditGames();
            warehouse.EditGames();

            warehouse.gamegroups[0].games[0] = new Game("Matador-0005A");

            warehouse.EditGames();

            //Console.WriteLine("Vælg menupunkt: ");
            //Console.WriteLine("1. Print alle spil");
            //Console.WriteLine("2. Lav nu kunde");

            //int menuItem;
            //int.TryParse(Console.ReadLine(), out menuItem);

            //switch (menuItem)
            //{
            //    case 1:
            //        warehouse.PrintWarehouse(); break;
            //        //case 2:



            //}

            warehouse.PrintWarehouse();

            Console.ReadLine();
        }

    }
}
