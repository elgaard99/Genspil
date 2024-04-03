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
        public Game(string title, string condition, int counter)
        {
            this.referenceNumber = title + "-" + counter + condition;
        }

    }
}
