using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Threading.Tasks;

namespace Genspil
{
    internal class Game
    {
        string referenceNumber;
        public string ReferenceNumber
        { get { return referenceNumber; } }

        //Muligvis god idé med en property?
        /*        public string ReferenceNumber 
                { 
                    get { return referenceNumber; } 
                    set {  referenceNumber = value; }
                }*/

        //Laver et reference nummer ud fra title og condition og en counter der ligger i gamegroup objektet som findes i Warehouse klassen
        public Game(string title, string condition, int index)
        {
            this.referenceNumber = CreateReferenceNumber(title, condition, index);
        }

        public Game(string referenceNumber)
        {
            this.referenceNumber = referenceNumber;
        }

        string CreateReferenceNumber(string title, string condition, int index)
        {

            index++;

            // create refnumber
            string newReferenceNumber = "";

            if (index < 10)
                newReferenceNumber = "000" + index;

            else if (index < 100)
                newReferenceNumber = "00" + index;

            else if (index < 1000)
                newReferenceNumber = "0" + index;

            else
                newReferenceNumber = index.ToString();

            return title + "-" + newReferenceNumber + condition;

        }
    }
}
