using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genspil
{
    internal class Game
    {
        string referenceNumber;
//Muligvis god idé med en property?
/*        public string ReferenceNumber 
        { 
            get { return referenceNumber; } 
            set {  referenceNumber = value; }
        }*/
        //Laver et reference nummer ud fra title condition og en counter der ligger i gamegroup klassen
        public void CreateReferenceNumber (string title, string condition)
        {
            //Kan jo så alternativt løses med property istedet.
            this.referenceNumber = title + "-" +  gameGroup.counter + condition;
            // Her bliver det færdige produkt eksempelvis "Matador-127A" 
        }
    }
}
