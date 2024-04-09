namespace Genspil
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Gamegroup[] gamegroups =
            {
                new Gamegroup("Matador", new[] { 2, 6 }, new[] { 10, 12 }, new[] { "børn", "strategi" }, 199.95F, new[] { 1F, 0.9F, 0.8F, 0.7F, 0.6F, 0.5F }),
                new Gamegroup("UNO", new[] { 2, 6 }, new[] { 10, 12 }, new[] { "børn", "strategi" }, 199.95F, new[] { 1F, 0.9F, 0.8F, 0.7F, 0.6F, 0.5F })
            };

            Warehouse warehouse = new Warehouse(gamegroups);
            Customer[] customers = [];

            //warehouse.EditGames();
            //warehouse.PrintWarehouse();

            //warehouse.EditGames();
            //warehouse.PrintWarehouse();

            //warehouse.EditGames();
            //warehouse.PrintWarehouse();

            //warehouse.EditGames();
            //warehouse.PrintWarehouse();

            //warehouse.EditGames();
            //warehouse.PrintWarehouse();

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

            warehouse.RemoveGamegroup();

            warehouse.PrintWarehouse();

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
