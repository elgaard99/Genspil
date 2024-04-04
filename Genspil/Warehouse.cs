using System;
using System.Collections;
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
            string sorting = Console.ReadLine();

            // sortér gameGroups efter enten title eller genre
            string[] arrKeys = new string[gamegroups.Length];
            for (int i = 0; i < arrKeys.Length; i++)
            {
                if (gamegroups[i] != null)
                    arrKeys[i] = (sorting == "t" ? gamegroups[i].title : null);
            }

            Gamegroup[] sortedGamegroups = gamegroups;
            Array.Sort(arrKeys, sortedGamegroups);

            Console.Clear();

            foreach (Gamegroup group in sortedGamegroups)
            {
                if (group != null)
                {
                    Console.WriteLine($"Game: \"{group.title}\"");

                    group.PrintGamegroup();
                }
                    
            }
        }

        public object CreateGameGroup()
        {
            Console.WriteLine("Indtast en titel på den nye gamegroup:");
            string title = Console.ReadLine();

            int[] numbPlayers = new int[2];
            Console.WriteLine("Indtast hvor mange spillere der minimum kan spille på med i " + title);
            numbPlayers[0] = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Indtast hvor mange spillere der maksimum kan spille på med i " + title);
            numbPlayers[1] = Convert.ToInt32(Console.ReadLine());

            int[] ageRecommended = new int[2];
            Console.WriteLine("Indtast hvor gammel en spiller minimum skal være i " + title);
            ageRecommended[0] = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Indtast hvor gammel en spiller maksimum skal være i " + title);
            ageRecommended[1] = Convert.ToInt32(Console.ReadLine());

            bool exit = false;
            string[] categories = new string[1];
            while (exit = false)
            {
                int count = 0;
                Console.WriteLine("Indtast en kategori for " + title + ", eller tryk 0 for at gå videre");
                string[] categories1 = new string[count + 1];
                categories1[count] = Console.ReadLine();
                if (categories1[count] == "0") exit = true;
                return categories = categories1;
            }

            Console.WriteLine("Indtast en pris på spilgruppen");
            float price = float.Parse(Console.ReadLine());

            //-.-.-.-.-.- SKAL DE INDTASTE DISCOUNTEN SELV? HVIS JA ER KODEN HER
            float[] conditionPrice = new float[6];
            foreach (int condition in conditionPrice)
            {
                if (condition == 0) Console.WriteLine("Indtast % discount på tilstand A:"); conditionPrice[condition] = float.Parse(Console.ReadLine()) * price;
                if (condition == 1) Console.WriteLine("Indtast discount på tilstand B:"); conditionPrice[condition] = float.Parse(Console.ReadLine()) * price;
                if (condition == 2) Console.WriteLine("Indtast discount på tilstand C:"); conditionPrice[condition] = float.Parse(Console.ReadLine()) * price;
                if (condition == 3) Console.WriteLine("Indtast discount på tilstand D:"); conditionPrice[condition] = float.Parse(Console.ReadLine()) * price;
                if (condition == 4) Console.WriteLine("Indtast discount på tilstand E:"); conditionPrice[condition] = float.Parse(Console.ReadLine()) * price;
                if (condition == 5) Console.WriteLine("Indtast discount på tilstand F:"); conditionPrice[condition] = float.Parse(Console.ReadLine()) * price;
            }

            float aPrice = float.Parse(Console.ReadLine());

            Gamegroup newGameGroup = new Gamegroup(title, numbPlayers, ageRecommended, categories, price, conditionPrice);

            object[] tempGameGroups = new object[gamegroups.Length + 1];
            for (int i = 0; i < gamegroups.Length; i++)
            {
                tempGameGroups[i] = gamegroups[i];
            }
            tempGameGroups[gamegroups.Length + 1] = newGameGroup;
            return null; //gamegroups = tempGameGroups;


        }
        /*public object AddGame(int ID) 
        {
            Console.Clear();
            foreach (object gameGroup in gameGroups) { Console.WriteLine(gameGroup); }
            Console.WriteLine("Vælg det tal som repræsenterer spilets titel eller tryk 0 for at tilføje en ny titel:");
            this.ID = Convert.ToInt32(Console.ReadLine());

            if (this.ID > gameGroups.Length) 
            {
                while (ID>gameGroups.Length) 
                {
                    Console.Clear();
                    Console.WriteLine("Du har ikke valgt et gyldigt nummer. Prøv igen, eller tryk 0 for at lave en ny gruppe");
                    foreach (object gameGroup in gameGroups) { Console.WriteLine(gameGroup); }
                    Console.WriteLine("Vælg det tal som repræsenterer spilets titel eller tryk 0 for at tilføje en ny titel:");
                    this.ID = Convert.ToInt32(Console.ReadLine());
                }
            }
            else if (this.ID == 0) { CreateGameGroup(); }
            else 
            {
                //Henter titlen på gameGroupen. Her skal stå minus 1 fordi indeks starter fra 0, men brugerens valg af eksisterende spilgrupper starter fra 1.
                string title = gameGroups[ID - 1].title;
                //Her skal brugeren indtaste hvilken tilstand spillet er i
                Console.WriteLine("Vælg tilstanden som " + title + " spillet er i:");
                Console.WriteLine("A: Så godt som nyt \nB: Meget lidt slidt \nC: Spillet er rimelig brugt \nD: Spillet ligner et bombet lokum");
                string condition = Console.ReadLine();
                // HER SKAL INDSÆTTES AT STRING ENTEN SKAL VÆRE  A B C ELLER D, ELLERS PRØV IGEN
                *//*if (condition == "A" || condition == "B" || condition == "C" || condition == "D") 
                { 

                }*//*
                Game newGame = new Game();
                string newReferenceNumber = newGame.CreateGame(employee.ID, condition);
                
                //public void AddGameToGameGroup(int ID);
                //Kunne ikke finde ud af hvordan metoden Create Game skulle kaldes her så skrev den bare ind herunder

                
                // vi kan ikke genbruge den "oprindlige" array af objekter , da vi ikke kan ændre længden på en array. Så derfor laver jeg en midlertidig arra der er 1 indeks længere end originalen og gemmer objektet i den sidste
                object[] tempGames = new object[games.Length + 1];
                //Indsætter alle værdierne fra games array i den nye tempGames array
                for (int i = 0; i < games.Length; i++)
                {
                    tempGames[i] = games[i];
                }
                //Indsætter det nye objekt på det sidste indeks i den nye array
                tempGames[games.Length + 1] = newGame;
                //Gemmer den nye array "oveni" den gamle array som derfor bliver erstattet af den nye array.
                this.games = tempGames;
                //tæller en op på counter variablet
                this.counter++;
            }


        }*/

    }
}
