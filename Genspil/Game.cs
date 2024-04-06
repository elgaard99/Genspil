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
        public Game(string title, string condition, Game[] exsistingGames)
        {
            if (exsistingGames.Length == 0)
                this.referenceNumber = title + "-" + "0001" + condition;

            else if (exsistingGames.Length == 9999)
                throw new Exception("Too many games. Maximum number of games in a gamegroup is 9999");

            else
            {
                int[] refNumbers = new int[exsistingGames.Length];
                
                for (int i = 0; i < exsistingGames.Length; i++)
                {

                    int startIndexOfNumber = exsistingGames[i].ReferenceNumber.IndexOf("-") +1;

                    refNumbers[i] = int.Parse(exsistingGames[i].ReferenceNumber.Substring(startIndexOfNumber, 4)); //gets the count-part of a reference-number
                }

                Array.Sort(refNumbers);

                int counter = 0;
                foreach (int  refNumber in refNumbers) 
                {
                    counter++;
                    
                    if (refNumber != counter)
                        break;

                    else if (counter == refNumbers.Length)
                        counter++;
                }
                
                // create refnumber
                string newReferenceNumber = "";
                if (counter < 10)
                    newReferenceNumber = "000" + counter;

                else if (counter < 100)
                    newReferenceNumber = "00" + counter;

                else if (counter < 1000)
                    newReferenceNumber = "0" + counter;

                else
                    newReferenceNumber = counter.ToString();
                
                this.referenceNumber = title + "-" + newReferenceNumber + condition;
            }
        }

        public Game(string referenceNumber)
        {
            this.referenceNumber = referenceNumber;
        }
    }
}
