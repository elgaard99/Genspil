using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Genspil
{
    public class Employee
    {

        public int ID;
        
        public Warehouse warehouse = new Warehouse();

        public void AddGame()
        {
            //_*_*_tester linje skal fjernes, antager at der allerede er et spil i gameGroups i warehouse klassen
            Console.Clear();
            //printer alle valg for gamegroup
            for (int i=0; i<warehouse.gameGroups.Length; i++) 
            {
                int count = i+1;
                GameGroup gameGroupInWarehouse = (GameGroup)warehouse.gameGroups[i];
                Console.WriteLine( " 1 + " + gameGroupInWarehouse.title); 
            }
            Console.WriteLine("Vælg det tal som repræsenterer spilets titel eller tryk 0 for at tilføje en ny titel:");
            //registrere brugerens valg af gamegroup
            this.ID = Convert.ToInt32(Console.ReadLine());

            if (this.ID > warehouse.gameGroups.Length)
            {
                while (ID > warehouse.gameGroups.Length)
                {
                    Console.Clear();
                    Console.WriteLine("Du har ikke valgt et gyldigt nummer. Prøv igen, eller tryk 0 for at lave en ny gruppe");
                    foreach (object gameGroup in warehouse.gameGroups) { Console.WriteLine(gameGroup); }
                    Console.WriteLine("Vælg det tal som repræsenterer spilets titel eller tryk 0 for at tilføje en ny titel:");
                    this.ID = Convert.ToInt32(Console.ReadLine());
                }
            }
            else if (this.ID == 0) { warehouse.CreateGameGroup(); }
            else
            {
                int IDminus = ID - 1;
                //Henter titlen på gameGroupen. Her skal stå minus 1 fordi indeks starter fra 0, men brugerens valg af eksisterende spilgrupper starter fra 1.
                GameGroup gameGroup = (GameGroup)warehouse.gameGroups[IDminus];
                gameGroup.counter++;
                string title = gameGroup.title;

                //Her skal brugeren indtaste hvilken tilstand spillet er i
                Console.WriteLine("Vælg tilstanden som " + title + " spillet er i:");
                Console.WriteLine("A: Så godt som nyt \nB: Meget lidt slidt \nC: Spillet er rimelig brugt \nD: Spillet ligner et bombet lokum");
                string condition = Console.ReadLine();
                // HER SKAL INDSÆTTES AT STRING ENTEN SKAL VÆRE  A B C ELLER D, ELLERS PRØV IGEN
                /*if (condition == "A" || condition == "B" || condition == "C" || condition == "D") 
                { 

                }*/
                Game newGame = new Game();
                newGame.CreateGame(title, condition, gameGroup.counter);
                //Kunne ikke finde ud af hvordan metoden Create Game skulle kaldes her så skrev den bare ind herunder


                // vi kan ikke genbruge den "oprindlige" array af objekter , da vi ikke kan ændre længden på en array. Så derfor laver jeg en midlertidig arra der er 1 indeks længere end originalen og gemmer objektet i den sidste
                object[] tempGames = new object[ gameGroup.games.Length + 1];
                //Indsætter alle værdierne fra games array i den nye tempGames array
                if (gameGroup.games.Length == 1)
                {
                    gameGroup.games[0] = newGame;
                }
                else
                {
                    for (int i = 0; i <= gameGroup.games.Length; i++)
                    {
                        tempGames[i] = gameGroup.games[i];
                        tempGames[gameGroup.games.Length + 1] = newGame;
                    }
                }
                
                //Indsætter det nye objekt på det sidste indeks i den nye array
                

            }
        }
    }
}
