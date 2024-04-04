using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genspil
{
    internal class Request
    {
        public Gamegroup requestedGamegroup;

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
    }
}
