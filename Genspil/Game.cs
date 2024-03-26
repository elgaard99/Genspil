using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genspil
{
    public class Game
    {
        public string referenceNumber;
//Muligvis god idé med en property?
/*        public string ReferenceNumber 
        { 
            get { return referenceNumber; } 
            set {  referenceNumber = value; }
        }*/
        //Laver et reference nummer ud fra title og condition og en counter der ligger i gamegroup objektet som findes i Warehouse klassen
        public void CreateReferenceNumber (string ID, string condition)
        {
            //"oversætter" titleID til en specifik title, eksempelvis matador. Her antager vi altså at det objekt på indeksplads ID i gamegroups, der indeholder et objekt af matador gameGroupen som indeholder et field med title
            string title = GameGroup.title;
            //"oversætter" titleID til en counter, eksempelvis matador. Her antager vi altså at det objekt på indeksplads ID i gamegroups, der indeholder et objekt af matador gameGroupen som indeholder et field med det antal spil der har været tilføjet.
            int counter = GameGroup.counter;
            //Kan jo så alternativt løses med properties istedet.
            this.referenceNumber = title + "-" + counter + condition;
            // Her bliver det færdige produkt eksempelvis "Matador-127A"
        }
    }
}
