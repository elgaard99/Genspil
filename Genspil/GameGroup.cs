using System;
using System.Collections.Frozen;
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
        public float[] conditionPrice = new float[4];
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
                    throw new Exception("Too many games. Maximum number of games in a gamegroup is 999");

                idx++;
                
            }

        }

        public void RemoveGame()
        {
            Console.WriteLine("Hvilket spil ønsker du at slette?");

            foreach (Game game in this.games)
                Console.WriteLine("\t" + game.ReferenceNumber);

            Console.Write("Indtast tallet i referencenummeret: ");

            int idxOfGame = -1;
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

                    if (idxOfGame != -1)
                        break;

                    else
                        Console.WriteLine("Du skal indtaste et gyldigt fircifret tal.");

                }
            }

            games[idxOfGame] = null;

        }

        public override string ToString()
        {
            string[] _conditionPrice = new string[4];
            for (int i = 0;i < conditionPrice.Length;i++)
                _conditionPrice[i] = conditionPrice[i].ToString();

            string AddLeadingZero(int number)
            {
                return (number < 10 ? "0" + number.ToString() : number.ToString());
            }
            
            string s = @$"
                    Title: {title};
                    Number of players: {AddLeadingZero(numbPlayers[0])}, {AddLeadingZero(numbPlayers[1])};
                    Recommended Age: {AddLeadingZero(ageRecommended[0])}, {AddLeadingZero(ageRecommended[1])};
                    Categories: {string.Join(",", categories)};
                    Price: {price};
                    Condition Prices: {string.Join("-", _conditionPrice)}";

            s = Regex.Replace(s, @"\s+", "");

            return s ;
        }

        //instanciere et objekt af Games klassen

    }
}
