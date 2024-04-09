using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Genspil
{

    internal class Gamegroup
    {
        public string title;
        public int[] numbPlayers = new int[2]; // idx 0 = fra antal spillere, idx 1 = til antal spillere
        public int[] ageRecommended = new int[2]; // idx 0 = fra år, idx 1 = til år
        public string[] categories = new string[5]; // maks 5 kategorier
        public float price;
        public float[] conditionPrice; 
        public Game[] games = [];

        public Gamegroup(string title, int[] numbPlayers, int[] ageRecommended, string[] categories, float price, float[] conditionPrice)
        {
            this.title = title;
            this.numbPlayers = numbPlayers;
            this.ageRecommended = ageRecommended;
            this.categories = categories;
            this.price = price;
            this.conditionPrice = conditionPrice;
            Game[] games = new Game[999];
        }

        public void PrintGamegroup()
        {

            foreach (Game game in games)
            {
                if (game != null)
                    Console.WriteLine($"\tReferencenummer: \"{game.ReferenceNumber}\"");
            }
        }

        public void AddGame()
        {
            
            //Her skal brugeren indtaste hvilken tilstand spillet er i
            Console.WriteLine("Vælg tilstanden som " + this.title + " spillet er i:");
            Console.WriteLine("A: Så godt som nyt \nB: Meget lidt slidt \nC: Spillet er rimelig brugt \nD: Spillet ligner et bombet lokum");

            char chooseCondition = Convert.ToChar("A");
            while (true)
            {

                if (char.TryParse(Console.ReadLine(), out chooseCondition))
                    break;

                Console.WriteLine("Du skal angive et bogstav. A, B, C, eller D");
                
            }

            int idx = 0;
            foreach (Game game in games)
            {
                if (game == null)
                {
                    games[idx] = new Game(this.title, chooseCondition.ToString(), idx);
                    break;
                }
                else if (idx == 999)
                    throw new Exception("")


                idx++;
                
            }

        }

        public void RemoveGame()
        {
            Console.WriteLine("Hvilket spil ønsker du at slette?");

            foreach (Game game in this.games)
                Console.WriteLine("\t" + game.ReferenceNumber);

            Console.Write("Indtast tallet i referencenummeret: ");

            int ?idxOfGame = null;
            while (true)
            {
                int refNumber;
                if (!int.TryParse(Console.ReadLine(), out refNumber))
                    Console.WriteLine("Du skal indtaste et gyldigt fircifret tal.");

                else
                {
                    for (int i = 0; i < this.games.Length; i++)
                    {
                        int startIndexOfNumber = games[i].ReferenceNumber.IndexOf("-") + 1;

                        if (refNumber == int.Parse(games[i].ReferenceNumber.Substring(startIndexOfNumber, 4))) //gets the count-part of a reference-number
                        {
                            idxOfGame = i;
                            break;
                        }

                    }

                    break;

                }
            }

            // vi kan ikke genbruge den "oprindlige" array af objekter , da vi ikke kan ændre længden på en array. Så derfor laver jeg en midlertidig arra der er 1 indeks længere end originalen og gemmer objektet i den sidste
            Game[] tempGames = new Game[this.games.Length -1];

            //Indsætter alle værdierne fra games array i den nye tempGames array
            for (int i = 0; i < this.games.Length -1; i++)
            {
                if (i < idxOfGame)
                    tempGames[i] = this.games[i];

                else
                    tempGames[i] = this.games[i +1];

            }
                                    
            //Gemmer den nye array "oveni" den gamle array som derfor bliver erstattet af den nye array.
            this.games = tempGames;

        }

        public override string ToString()
        {
            string s = @$"
                    Title: {title},
                     Number of players: {numbPlayers},
                     Recommended Age: {ageRecommended},
                     Categories: {categories},
                     Price: {price},
                     Condition Prices: {conditionPrice}";

            s = Regex.Replace(s, @"\s+", " ");

            return s ;
        }

        //instanciere et objekt af Games klassen

    }
}
