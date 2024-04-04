using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genspil
{
    internal class Warehouse
    {
        public Gamegroup[] gamegroups = new Gamegroup[100]; //maks 100 forskellige "spilgrupper"

        public void PrintWarehouse()
        {

            Console.Clear();

            Console.WriteLine("Hvordan skal listen sorteres? Tast t for titel eller g for genre");
            char sorting = Console.ReadLine()[0];

            // sortér gameGroups efter enten title eller genre

            Console.Clear();

            foreach (Gamegroup group in gamegroups)
            {
                if (group != null)
                {
                    Console.WriteLine($"Game: \"{group.title}\"");

                    group.PrintGamegroup();
                }
                    
            }
        }
    }
}
