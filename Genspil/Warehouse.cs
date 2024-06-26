﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//Problemer i valg af conditionPrice

namespace Genspil
{
    internal class Warehouse
    {
        public Gamegroup[] gamegroups;

        public Warehouse(Gamegroup[] gamegroups) 
        { 
            this.gamegroups = gamegroups;
        }

        public void PrintWarehouse()
        {
            //Bør vi måske i virkeligheden ændre dette til at tage udgangspunkt i data filen??
            Console.Clear();

            Console.Write("Hvordan skal listen sorteres? Tast t for titel eller g for genre: ");

            string sorting;
            while (true) 
            {
                sorting = Console.ReadLine();

                if (sorting == "t" || sorting == "g")
                    break;

                Console.WriteLine("Du skal enten taste \"t\" eller \"g\".");
                Console.Write("Prøv igen: ");

            }

            // sortér gameGroups efter enten title eller genre
            string[] arrKeys = new string[gamegroups.Length];
            for (int i = 0; i < arrKeys.Length; i++)
            {
                if (gamegroups[i] != null)
                    arrKeys[i] = (sorting == "t" ? gamegroups[i].title : gamegroups[i].categories[0]);
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

            Console.Write("Tast enter for at komme tilbage: ");
            Console.ReadLine();

        }

        public void LoadGamegroups(DataHandler handler)
        {
            StreamReader ReadFromWareHouse = new StreamReader("C:\\Users\\dscha\\source\\repos\\TestAfKode\\TestAfKode\\test.txt");
            //skal rettes til at tage hver enkelt Gamegroup i stedet tænker jeg umiddelbart
            string file = ReadFromWareHouse.ReadToEnd();
            ReadFromWareHouse.Close();

        }

        public void SaveGamegroups(DataHandler handler)
        {
            /*
            StreamWriter WriteToWareHouse = new StreamWriter("C:\\Users\\dscha\\source\\repos\\TestAfKode\\TestAfKode\\Gamegroups.txt");
            foreach (Gamegroup game in gamegroups)
            {
                WriteToWareHouse.WriteLine("Titel:" + gamegroup.title);
                WriteToWareHouse.WriteLine("Kategorier:");
                foreach (string category in gamegroup.categories)
                {
                    if (category == null) ;
                    else
                        WriteToWareHouse.Write("- " + category + "\n");
                }
                WriteToWareHouse.WriteLine("Spillere: " + gamegroup.numbPlayers[0] + "-" + gamegroup.numbPlayers[1]);
                WriteToWareHouse.WriteLine("Alders anbefaling: " + gamegroup.ageRecommended[0] + "-" + gamegroup.ageRecommended[1] + " år");
                for (int i = 0; i < game.conditionPrice.Length; i++)
                {
                    char condition = Convert.ToChar(65 + i);
                    WriteToWareHouse.WriteLine("Pris for tilstand " + condition + ": " + gamegroup.conditionPrice[i]);
                }
                WriteToWareHouse.WriteLine("");
            }
            WriteToWareHouse.Close();
            */
        }

        public void CreateGamegroup()
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
            int countTitle = 0;
            while (exit == false)
            {
                Console.WriteLine("Indtast en kategori for " + title + ", eller tryk 0 for at gå videre");
                string[] categories1 = new string[countTitle+1];
                categories1[countTitle] = Console.ReadLine();
                if (categories1[countTitle] == "0") exit = true;
                categories = categories1;
            }

            Console.WriteLine("Indtast en pris på spilgruppen");
            float price = float.Parse(Console.ReadLine());

            //-.-.-.-.-.- SKAL DE INDTASTE DISCOUNTEN SELV? HVIS JA ER KODEN HER
            float[] conditionPrice = new float[4];

            for (int i = 0; i<4 ; i++)
            {
                string[] conditions = { "A", "B", "C", "D" };
                Console.WriteLine("Indtast % discount på tilstand " + conditions[i] + ":");
                conditionPrice[i] = (1-(float.Parse(Console.ReadLine())/100)) * price;
                Console.WriteLine(conditionPrice[i]);
            }


            Gamegroup newGameGroup = new Gamegroup(title, numbPlayers, ageRecommended, categories, price, conditionPrice);

            Gamegroup[] tempGameGroups = new Gamegroup[gamegroups.Length + 1];
            for (int i = 0; i < gamegroups.Length; i++)
            {
                tempGameGroups[i] = gamegroups[i];
            }

            tempGameGroups[gamegroups.Length] = newGameGroup;

            gamegroups = tempGameGroups;
            Array.Sort(gamegroups, new CompareTitle());
        }

        public void RemoveGamegroup()
        {
            Console.Clear();

            Console.WriteLine("Hvilken gamegroup ønsker du at slette?");

            for (int i = 0; i < gamegroups.Length; i++)
                Console.WriteLine($"\tTast {i +1}: {gamegroups[i].title}");

            Console.Write("\n\n(Tryk menupunkt eller 0 for at afslutte) ");

            int gamegroupIndex = 0;
            string choice = Console.ReadLine(); // Tilføjet så du kan gå ud fra menuen ved at trykke 0, da den ellers sagde det var et ugyldigt valg med 0
            while (choice != "0") //Tilføjet at denne ikke skal være 0, for at undgå loopet.
            {

                if (int.TryParse(choice, out gamegroupIndex))
                {

                    gamegroupIndex--;

                    if (gamegroupIndex >= -1 && gamegroupIndex < gamegroups.Length)
                        break;

                }

                Console.WriteLine("Du skal indtaste et gyldigt tal.");

            }

            if (gamegroupIndex != -1)
            {
                // vi kan ikke genbruge den "oprindlige" array af objekter , da vi ikke kan ændre længden på en array. Så derfor laver jeg en midlertidig arra der er 1 indeks længere end originalen og gemmer objektet i den sidste
                Gamegroup[] tempGamegroups = new Gamegroup[this.gamegroups.Length - 1];

                //Indsætter alle værdierne fra games array i den nye tempGames array
                for (int i = 0; i < this.gamegroups.Length - 1; i++)
                {
                    if (i < gamegroupIndex)
                        tempGamegroups[i] = this.gamegroups[i];

                    else
                        tempGamegroups[i] = this.gamegroups[i + 1];

                }

                //Gemmer den nye array "oveni" den gamle array som derfor bliver erstattet af den nye array.
                this.gamegroups = tempGamegroups;
                Array.Sort(gamegroups, new CompareTitle());
            }
        }

        public void EditGames()
        {

            Console.Clear();

            Console.WriteLine("Hvilken titel vil du tilføje/ slette et spil i?");
            for (int i = 0; i < gamegroups.Length; i++)
                Console.WriteLine($"\tTast {i + 1}: {gamegroups[i].title}");

            Console.Write("\n\n(Tryk menupunkt eller 0 for at afslutte)");

            int chooseGamegroup;
            while (true)
            {

                if (int.TryParse(Console.ReadLine(), out chooseGamegroup))
                    break;

                Console.WriteLine("Du skal angive et tal");

            }

            if (chooseGamegroup != 0)
            {

                Console.WriteLine("Hvad vil du gerne?\n\tTast 1: Tilføje\n\tTast 2: Slette\n");

                int chooseWhatToDo;
                while (true)
                {

                    if (int.TryParse(Console.ReadLine(), out chooseWhatToDo))
                        break;

                    Console.WriteLine("Du skal angive et tal");

                }

                if (chooseWhatToDo == 1)
                    gamegroups[chooseGamegroup - 1].AddGame();

                else if (chooseWhatToDo == 2)
                    gamegroups[chooseGamegroup - 1].RemoveGame();
            }
        }
        public class CompareTitle : IComparer
        {
            public int Compare(object x, object y)
            {
                return (new CaseInsensitiveComparer()).Compare(((Gamegroup)x).title, ((Gamegroup)y).title);
            }
        }
        public class CompareCat : IComparer
        {
            public int Compare(object x, object y)
            {
                return (new CaseInsensitiveComparer()).Compare(((Gamegroup)x).categories[0], ((Gamegroup)y).categories[0]);
            }
        }
        public Gamegroup? SearchTitle(Gamegroup[] gamegroups, string title)
        {
            Array.Sort(gamegroups, new CompareTitle());
            string[] gamegroupsTitle = new string[gamegroups.Length];
            int i = 0;
            foreach (Gamegroup gamegroup in gamegroups)
            {
                gamegroupsTitle[i] = gamegroup.title;
                i++;
            }
            //Tror denne er overkill fordi den jo i virkeligheden bare kan være en if statement :p
            if (Array.BinarySearch(gamegroupsTitle, title) < 0)
            {
                Console.WriteLine("HOV! Spillet er ikke tilføjet til databasen. Overvej at tilføje " + title + " til databasen");
                return null;
            }
            //if (gamegroups==title) 
            //Var itvivl om den skulle returnere gamegroup'ens title eller bare alle iformationer? Nedenstående er åbentlyst kun titlen, men tænker da det er federe med hele lortet.
            else return gamegroups[Array.BinarySearch(gamegroupsTitle, title)];
        }

        public Gamegroup[]? SearchCategories(string category)
        {
            Array.Sort(gamegroups, new CompareCat());
            Gamegroup[] searchResultsCat= new Gamegroup[gamegroups.Length];
            int i = 0;
            foreach (Gamegroup group in gamegroups)
            {
                if (Array.BinarySearch(group.categories, category) >= 0)
                {
                    searchResultsCat[i] = group;
                    Console.WriteLine(searchResultsCat[i].title + " matcher kriteret " + category);
                    i++;
                }
            }
            if (searchResultsCat.Count(g=>g != null) > 0)
                return searchResultsCat;
            else
            {
                Console.WriteLine("Intet resultat af din søgning");
                return null;
            }
                
        }
        public Gamegroup[]? SearchCategories(string category, Gamegroup[] prevSearchResults)
        {
            Array.Sort(gamegroups, new CompareCat());
            Gamegroup[] searchResultsCat = new Gamegroup[gamegroups.Length];
            int i = 0;
            foreach (Gamegroup group in prevSearchResults)
            {
                if (group != null)
                {
                    int binarySearchResult = Array.BinarySearch(group.categories, category);
                    if (binarySearchResult >= 0)
                    {
                        searchResultsCat[i] = group;
                        Console.WriteLine(searchResultsCat[i].title + " matcher kriteret " + category);
                        i++;
                    }
                }
            }
            if (searchResultsCat != null)
                return searchResultsCat;
            else
                return null;
        }
        public Gamegroup[]? SearchNumbPlayers(int min, int max)
        {
            int i = 0;
            Gamegroup[] searchResultsNumbPlayers = new Gamegroup[100];
            foreach (Gamegroup group in gamegroups)
            {
                //Da array altid er 2 ingen grund til brug af binarysearch???
                if (group.numbPlayers[0] >= min && group.numbPlayers[1] >= max)
                {
                    searchResultsNumbPlayers[i] = group;
                    Console.WriteLine(searchResultsNumbPlayers[i].title + " matcher kriteret" + ". Det har rummer " + group.numbPlayers[0] + "-" + group.numbPlayers[1] + " spillere.");
                    i++;
                }
            }
            if (searchResultsNumbPlayers != null)
                return searchResultsNumbPlayers;
            else
                return null;
        }

        public Gamegroup[]? SearchNumbPlayers(int min, int max, Gamegroup[] prevSearchResults)
        {
            int i = 0;
            Gamegroup[] searchResultsNumbPlayers = new Gamegroup[100];
            foreach (Gamegroup group in prevSearchResults)
            {
                //Da array altid er 2 ingen grund til brug af binarysearch???
                if (group != null && group.numbPlayers[0] >= min && group.numbPlayers[1] >= max)
                {
                    searchResultsNumbPlayers[i] = group;
                    Console.WriteLine(searchResultsNumbPlayers[i].title + " matcher kriteret" + ". Det har rummer " + group.numbPlayers[0] + "-" + group.numbPlayers[1] + " spillere.");
                    i++;
                }
            }
            if (searchResultsNumbPlayers != null)
                return searchResultsNumbPlayers;
            else
                return null;
        }
        public Gamegroup[]? SearchNumbPlayers(int min)
        {
            int i = 0;
            Gamegroup[] searchResultsNumbPlayers = new Gamegroup[100];
            foreach (Gamegroup group in gamegroups)
            {
                //Da array altid er 2 ingen grund til brug af binarysearch???
                if (group != null && group.numbPlayers[0] <= min && group.numbPlayers[1] >= min)
                {
                    searchResultsNumbPlayers[i] = group;
                    Console.WriteLine(searchResultsNumbPlayers[i].title + " matcher kriteret" + ". Det har rummer " + group.numbPlayers[0] + "-" + group.numbPlayers[1] + " spillere.");
                    i++;
                }
            }
            if (searchResultsNumbPlayers != null)
                return searchResultsNumbPlayers;
            else
                return null;
        }

        public Gamegroup[]? SearchNumbPlayers(int min, Gamegroup[] prevSearchResults)
        {
            int i = 0;
            Gamegroup[] searchResultsNumbPlayers = new Gamegroup[100];
            foreach (Gamegroup group in prevSearchResults)
            {
                //Da array altid er 2 ingen grund til brug af binarysearch???
                if (group != null && group.numbPlayers[0] <= min && group.numbPlayers[1] >= min)
                {
                    searchResultsNumbPlayers[i] = group;
                    Console.WriteLine(searchResultsNumbPlayers[i].title + " matcher kriteret" + ". Det har rummer " + group.numbPlayers[0] + "-" + group.numbPlayers[1] + " spillere.");
                    i++;
                }
            }
            if (searchResultsNumbPlayers != null)
                return searchResultsNumbPlayers;
            else
                return null;
        }

        public Gamegroup[]? SearchAgeRecommend(int min, int max)
        {
            int i = 0;
            Gamegroup[] searchResultsAgeRecommended = new Gamegroup[100];
            foreach (Gamegroup group in gamegroups)
            {
                //Da array altid er 2 ingen grund til brug af binarysearch???
                if (group != null && group.ageRecommended[0] >= min && group.ageRecommended[1] <= max)
                {
                    searchResultsAgeRecommended[i] = group;
                    Console.WriteLine(searchResultsAgeRecommended[i].title + " matcher kriteret" + ". Alders anbefalingen er: " + group.ageRecommended[0] + "-" + group.ageRecommended[1] + " år.");
                    i++;
                }
            }
            if (searchResultsAgeRecommended != null)
                return searchResultsAgeRecommended;
            else
                return null;
        }

        public Gamegroup[]? SearchAgeRecommend(int min, int max, Gamegroup[] prevSearchResults)
        {
            int i = 0;
            Gamegroup[] searchResultsAgeRecommended = new Gamegroup[100];
            foreach (Gamegroup group in prevSearchResults)
            {
                //Da array altid er 2 ingen grund til brug af binarysearch???
                if (group != null && group.ageRecommended[0] >= min && group.ageRecommended[1] <= max)
                {
                    searchResultsAgeRecommended[i] = group;
                    Console.WriteLine(searchResultsAgeRecommended[i].title + " matcher kriteret" + ". Det har rummer " + group.ageRecommended[0] + "-" + group.ageRecommended[1] + " spillere.");
                    i++;
                }
            }
            if (searchResultsAgeRecommended != null)
                return searchResultsAgeRecommended;
            else
                return null;
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
