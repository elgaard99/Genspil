using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Genspil
{
    public class Warehouse
    {
        //_*_*_tester linjer skal fjernes, antager at der allerede er et spil matador i gameGroups i warehouse klassen
        static GameGroup matador = new GameGroup();

        public object[] gameGroups = { matador };
        
        
        public object CreateGameGroup() 
        { 
            GameGroup newGameGroup = new GameGroup();
            object[] tempGameGroups = new object[gameGroups.Length + 1];
            for (int i = 0; i < gameGroups.Length; i++)
            {
                tempGameGroups[i] = gameGroups[i];
            }
            tempGameGroups[gameGroups.Length + 1] = newGameGroup;
            return gameGroups=tempGameGroups;
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
