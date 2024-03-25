using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genspil
{// hvad bruger vi conditionPrice til ??

    internal class Gamegroup
    {
        public string title;
        public int[] numbPlayers = new int[2]; // idx 0 = fra antal spillere, idx 1 = til antal spillere
        public int[] ageRecommended = new int[2]; // idx 0 = fra år, idx 1 = til år
        public string[] categories = new string[5]; // maks 5 kategorier
        public float price;
        public float conditionPrice; 
        public Game[] games = new Game[100]; // maks 100 spil
        
        public Gamegroup(string title)
        {
            this.title = title;
        }

        public void PrintGamegroup()
        {

            foreach (Game game in games)
            {
                if (game != null);
                    Console.WriteLine($"\tReferencenummer: \"{game.referenceNumber}\"");
            }
        }
    }
}
