using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Genspil
{
    internal class Request
    {
        public string[] titles; //Lavet til en array hvis de nu skulle kunne øsnke flere.

        //public int customerID;


        public Request(string[] requestTitles) 
        {
            this.titles = requestTitles;
        }
        public Request(string requestTitle)
        {
            titles = new string[1];
            titles[0] = requestTitle;
        }

        //Har lidt ombestemt mig med denne metode og læner mig længere op af hvad Sanders allerede har sagt. Tænkte den var god at kalde hver gang der blev AddGame(), hvor den ittere igennem alle requests i alle customers, men ved ikke helt??
        /*public void AvailabilityNotice(Gamegroup[] gamegroups, Warehouse warehouse)
        {
            foreach (string requestTitle in this.titles)
            {
                //gemmer det index i gamegroups der svarer til hvor spillet ligger
                //int gamegroupIndex= warehouse.SearchTitle(warehouse.gamegroups, requestTitle);

                //Gemmer den fundne gamegroup.
                Gamegroup gamegroup = warehouse.SearchTitle(gamegroups, requestTitle);
                //tror altså ikke vi kan gøre det sådan her, vi er nødt til at ittere igennem alle indekspladser i games array or checke om de er tomm

                if (gamegroup != null && gamegroup.games[0] != null)
                {
                    Console.WriteLine(gamegroup.title + " er på lager.");
                    Console.WriteLine("Der kan vælges mellem følgende spil:");
                    gamegroup.PrintGamegroup();
                }
                else Console.WriteLine("Spillet " + requestTitle + " er ikke på lager");
            }
                    
        }*/
    }
        //public Gamegroup requestedGamegroup;

        // hvordan bruges ReferenceNumbers?
        /*
        public Game[] ReferenceNumbers;

        
        public Request(GameGroup gameGroup, Game[] referenceNumbers)
        {
            GameGroup = gameGroup;
            ReferenceNumbers = referenceNumbers;
        }

        // metode til at søge efter spil baseret på kunde krav 
        public void SearchGamesByRequest(int? numberOfPlayers = null, int? ageRecommended = null, string searchCategory = null)
        {
            Console.WriteLine("Leder efter spil baseret på kriterier...");
            foreach (var GameGroup in GameGroups)
            {
                bool matchesCriteria = false;

                //tjek om antal spillere macther 
                if (numberOfPlayers != null)
                {
                    int minPlayers = GameGroup.playersRecommended[0];
                    int maxPlayers = GameGroup.playersRecommended[1];

                    if (minPlayers <= numberOfPlayers && maxPlayers >= numberOfPlayers)
                    {
                        matchesCriteria = true;
                    }
                }

                //tjek om aldersanbefalinger matcher 
                if (ageRecommended != null)
                {
                    int minAgeRecommended = GameGroup.minAgeRecommended[0];
                    int maxAgeRecommended = GameGroup.maxAgeRecommended[1];

                    if (minAgeRecommended <= ageRecommended && maxAgeRecommended >= ageRecommended)
                    {
                        matchesCriteria = true;
                    }
                    
                }

                //tjek om kategorier matcher 
                if (searchCategory != null)
                {
                    foreach (string category in GameGroup.categories)
                    {
                        if (searchCategory == category) 
                        {
                            matchesCriteria = true;
                        }
                    }
                }

                //udskriv spillet, hvis det matcher et af kriterierne 
                if (matchesCriteria)
                {
                    Console.WriteLine($"spillet '{GameGroup.Title}' møder kundens krav");
                }

                
            }
            
            
        }
        
        
    }*/
}
