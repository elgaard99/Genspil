namespace Genspil
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Warehouse warehouse = new Warehouse();
            Customer[] customers = new Customer[100]; //maks 100 kunder

            // forskellige games laves i gamegruppen "Matador" og "UNO"
            warehouse.gamegroups[0] = new Gamegroup("Matador");
            warehouse.gamegroups[0].games[0] = new Game("001-A");
            warehouse.gamegroups[0].games[1] = new Game("002-A");
            warehouse.gamegroups[0].games[2] = new Game("003-B");

            warehouse.gamegroups[1] = new Gamegroup("UNO");
            warehouse.gamegroups[1].games[0] = new Game("001-C");
            warehouse.gamegroups[1].games[1] = new Game("002-A");
            warehouse.gamegroups[1].games[2] = new Game("003-B");



            Console.WriteLine("Vælg menupunkt: ");
            Console.WriteLine("1. Print alle spil");
            Console.WriteLine("2. Lav nu kunde");

            int menuItem;
            int.TryParse(Console.ReadLine(), out menuItem);



            switch (menuItem)
            {
                case 1:
                    warehouse.PrintWarehouse(); break;
                case 2:



            }

            Console.ReadLine();
        }

    }
}
