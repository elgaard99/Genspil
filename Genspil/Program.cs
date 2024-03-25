namespace Genspil
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Warehouse warehouse = new Warehouse();

            // forskellige games laves i gamegruppen "Matador" og "UNO"
            warehouse.gameGroups[0] = new GameGroup("Matador");
            warehouse.gameGroups[0].games[0] = new Game("001-A");
            warehouse.gameGroups[0].games[1] = new Game("002-A");
            warehouse.gameGroups[0].games[2] = new Game("003-B");

            warehouse.gameGroups[1] = new GameGroup("UNO");
            warehouse.gameGroups[1].games[0] = new Game("001-C");
            warehouse.gameGroups[1].games[1] = new Game("002-A");
            warehouse.gameGroups[1].games[2] = new Game("003-B");


            Console.WriteLine("Vælg menupunkt: ");
            Console.WriteLine("1. Print alle spil");

            int menuItem;
            int.TryParse(Console.ReadLine(), out menuItem);

            Console.WriteLine("Hvordan skal listen sorteres? Tast t for titel eller g for genre");
            char sorting = Console.ReadLine()[0];

            switch (menuItem)
            {
                case 1:
                    warehouse.PrintWarehouse(sorting); break;
            }

            Console.ReadLine();
        }
    }
}
