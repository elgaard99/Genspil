using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genspil
{
    // hvad bruger vi conditionPrice til ??

    internal class Gamegroup
    {
        public string title;
        public int[] numbPlayers = new int[2]; // idx 0 = fra antal spillere, idx 1 = til antal spillere
        public int[] ageRecommended = new int[2]; // idx 0 = fra år, idx 1 = til år
        public string[] categories = new string[5]; // maks 5 kategorier
        public float price;
        public float[] conditionPrice; 
        public Game[] games = new Game[100]; // maks 100 spil
        
        public Gamegroup(string title)
        {
            this.title = title;
        }

        public void PrintGamegroup()
        {

            foreach (Game game in games)
            {
                if (game != null)
                    Console.WriteLine($"\tReferencenummer: \"{game.referenceNumber}\"");
            }
        }
        public void AddGameToGameGroup(int ID, Game newGame)
        {
            // vi kan ikke genbruge den "oprindlige" array af objekter , da vi ikke kan ændre længden på en array. Så derfor laver jeg en midlertidig arra der er 1 indeks længere end originalen og gemmer objektet i den sidste
            Game[] tempGames = new Game[games.Length + 1];
            //Indsætter alle værdierne fra games array i den nye tempGames array
            for (int i = 0; i < games.Length; i++)
            {
                tempGames[i] = games[i];
            }
            //Indsætter det nye objekt på det sidste indeks i den nye array
            tempGames[games.Length + 1] = newGame;
            //Gemmer den nye array "oveni" den gamle array som derfor bliver erstattet af den nye array.
            this.games = tempGames;


        }
        public Gamegroup(string title, int[] numbPlayers, int[] ageRecommended, string[] categories, float price, float[] conditionPrice)
        {
            this.title = title;
            this.numbPlayers = numbPlayers;
            this.ageRecommended = ageRecommended;
            this.categories = categories;
            this.price = price;
            this.conditionPrice = conditionPrice;
        }
        //instanciere et objekt af Games klassen

    }
}
