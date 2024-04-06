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
            
            warehouse.EditGames();
            warehouse.PrintWarehouse();

            warehouse.EditGames();
            warehouse.PrintWarehouse();

            warehouse.EditGames();
            warehouse.PrintWarehouse();

            warehouse.EditGames();
            warehouse.PrintWarehouse();

            warehouse.EditGames();
            warehouse.PrintWarehouse();

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



            Console.ReadLine();
        }

    }
}
