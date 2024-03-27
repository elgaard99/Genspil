using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Genspil
{
    public class GameGroup
    {
        public string title;

        int quantityTotal = games.Length;

        float price;
        float conditionPrice;

        string[] categories;
        object[] games = new object[0];

        int[] numbPlayers = new int[2];
        int[] ageRecommended = new int [2];
        public void AddGameToGameGroup(int ID)
        {
            //Kunne ikke finde ud af hvordan metoden Create Game skulle kaldes her så skrev den bare ind herunder
            // vi kan ikke genbruge den "oprindlige" array af objekter , da vi ikke kan ændre længden på en array. Så derfor laver jeg en midlertidig arra der er 1 indeks længere end originalen og gemmer objektet i den sidste
            object[] tempGames = new object[games.Length + 1];
            //Indsætter alle værdierne fra games array i den nye tempGames array
            for (int i = 0; i<games.Length; i++) 
            {
                tempGames[i] = games[i];
            }
           //Indsætter det nye objekt på det sidste indeks i den nye array
            tempGames[games.Length + 1] = newGame;
            //Gemmer den nye array "oveni" den gamle array som derfor bliver erstattet af den nye array.
            this.games = tempGames;

        }
        //instanciere et objekt af Games klassen
    }
}
