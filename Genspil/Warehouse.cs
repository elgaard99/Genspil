using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genspil
{
    internal class Warehouse
    {
        public GameGroup[] gameGroups = new GameGroup[100]; //maks 100 forskellige "spilgrupper"

        public void PrintWarehouse(char sorting)
        {

            Console.Clear();

            // sortér gameGroups efter enten title eller genre

            foreach (GameGroup group in gameGroups)
            {
                if (group == null) continue;

                Console.WriteLine($"Game: \"{group.title}\"");

                foreach (Game game in group.games) 
                {
                    if (game == null) continue;
                    Console.WriteLine($"\tReferencenummer: \"{game.referenceNumber}\"");
                }
            }
        }
    }
}
