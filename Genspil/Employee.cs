using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Genspil
{
    internal class Employee
    {

        public int ID;

        public Warehouse warehouse = new Warehouse(null);

        public void EditGames()
        {

            Console.WriteLine("Hvilken titel vil du tilføje/ slette et spil i?");
            for (int i = 0; i < warehouse.gamegroups.Length; i++)
                Console.WriteLine($"Tast {i + 1}: {warehouse.gamegroups[i].title}");

            int chooseGamegroup;
            while (true)
            {

                if (int.TryParse(Console.ReadLine(), out chooseGamegroup))
                    break;

                Console.WriteLine("Du skal angive et tal");

            }

            Console.WriteLine("Hvad vil du gerne?\n\tTast 1: Tilføje\n\tTast 2: Slette\n");

            int chooseWhatToDo;
            while (true)
            {

                if (int.TryParse(Console.ReadLine(), out chooseWhatToDo))
                    break;

                Console.WriteLine("Du skal angive et tal");

            }

            if (chooseWhatToDo == 1)
                warehouse.gamegroups[chooseGamegroup - 1].AddGame();

            else
                warehouse.gamegroups[chooseGamegroup - 1].RemoveGame();

        }


        public void AddGame(DataHandler dataHandler)
        {
            //_*_*_tester linje skal fjernes, antager at der allerede er et spil i gameGroups i warehouse klassen
            Console.Clear();

            //printer alle valg for gamegroup
            for (int i = 0; i < warehouse.gamegroups.Length; i++)
            {
                int count = i + 1;
                Gamegroup gamegroupInWarehouse = (Gamegroup)warehouse.gamegroups[i];
                Console.WriteLine(count + " " + gamegroupInWarehouse.title);
            }
            Console.WriteLine("Vælg det tal som repræsenterer spilets titel eller tryk 0 for at tilføje en ny titel:");
            
            //registrere brugerens valg af gamegroup
            this.ID = Convert.ToInt32(Console.ReadLine());

            if (this.ID > warehouse.gamegroups.Length)
            {
                while (ID > warehouse.gamegroups.Length)
                {
                    Console.Clear();
                    Console.WriteLine("Du har ikke valgt et gyldigt nummer. Prøv igen, eller tryk 0 for at lave en ny gruppe");
                    foreach (Gamegroup gamegroup in warehouse.gamegroups) { Console.WriteLine(gamegroup); }
                    Console.WriteLine("Vælg det tal som repræsenterer spilets titel eller tryk 0 for at tilføje en ny titel:");
                    this.ID = Convert.ToInt32(Console.ReadLine());
                }
            }
            else if (this.ID == 0) { warehouse.CreateGamegroup(); }
            else
            {
                int gamegroupIndex = ID - 1;

                //Henter titlen på gameGroupen. Her skal stå minus 1 fordi indeks starter fra 0, men brugerens valg af eksisterende spilgrupper starter fra 1.
                Gamegroup gamegroup = warehouse.gamegroups[gamegroupIndex];
                string title = gamegroup.title;

                //Her skal brugeren indtaste hvilken tilstand spillet er i
                Console.WriteLine("Vælg tilstanden som " + title + " spillet er i:");
                Console.WriteLine("A: Så godt som nyt \nB: Meget lidt slidt \nC: Spillet er rimelig brugt \nD: Spillet ligner et bombet lokum");
                string condition = Console.ReadLine();
                // HER SKAL INDSÆTTES AT STRING ENTEN SKAL VÆRE  A B C ELLER D, ELLERS PRØV IGEN
                /*if (condition == "A" || condition == "B" || condition == "C" || condition == "D") 
                { 

                }*/
                Game newGame = new Game(title, condition, 1);
                //Kunne ikke finde ud af hvordan metoden Create Game skulle kaldes her så skrev den bare ind herunder


                // vi kan ikke genbruge den "oprindlige" array af objekter , da vi ikke kan ændre længden på en array. Så derfor laver jeg en midlertidig arra der er 1 indeks længere end originalen og gemmer objektet i den sidste
                object[] tempGames = new object[gamegroup.games.Length + 1];
                //Indsætter alle værdierne fra games array i den nye tempGames array
                if (gamegroup.games.Length == 1)
                {
                    gamegroup.games[0] = newGame;
                }
                else
                {
                    for (int i = 0; i <= gamegroup.games.Length; i++)
                    {
                        tempGames[i] = gamegroup.games[i];

                    }
                    tempGames[gamegroup.games.Length + 1] = newGame;
                }
                gamegroup.games = null;//tempGames;


            }
        }
    }
}