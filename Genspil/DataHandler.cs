using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Genspil
{
    internal class DataHandler
    {
        
        string dataFileName;
        public string DataFileName
        {
            get { return dataFileName; }
        }

        public DataHandler(string dataFileName)
        { this.dataFileName = dataFileName; }
        
        public void Save(Object[] arr)
        {

            StreamWriter writer = new StreamWriter(DataFileName);

            foreach (Object element in arr)
            {

                writer.WriteLine(element.ToString());

            }

            writer.Close();

        }
        
        public Gamegroup[] LoadGamegroups()
        {
            string[] lines = File.ReadAllLines(DataFileName);
            
            Gamegroup[] gamegroups = new Gamegroup[lines.Length];

            int lineNo = 0;
            foreach (string line in lines)
            {

                string[] gamegroupInfo = line.Split(";");

                string[] _numbPlayers = gamegroupInfo[1].Substring(16).Split(",");
                string[] _ageRecommended = gamegroupInfo[2].Substring(15).Split(",");
                string[] _conditionPrice = gamegroupInfo[5].Substring(16).Split("-");
                string[] _games = gamegroupInfo[6].Substring(6).Split(",");

                string title = gamegroupInfo[0].Substring(6);
                int[] numbPlayers = { int.Parse(_numbPlayers[0]), int.Parse(_numbPlayers[1]) };
                int[] ageRecommended = { int.Parse(_ageRecommended[0]), int.Parse(_ageRecommended[1]) };
                string[] categories = gamegroupInfo[3].Substring(11).Split(",");
                float price = float.Parse(gamegroupInfo[4].Substring(6));
                float[] conditionPrice = { float.Parse(_conditionPrice[0]), float.Parse(_conditionPrice[1]), float.Parse(_conditionPrice[2]), float.Parse(_conditionPrice[3])};
                Game[] games = new Game[999];
                if (_games[0] != "")
                {
                    foreach (string referenceNumber in _games)
                    {

                        int indexOfGame = int.Parse(referenceNumber.Substring((referenceNumber.Length - 5), 4)); //gets the count-part of a reference-number
                        games[indexOfGame] = new Game(referenceNumber);

                    }

                }

                Gamegroup gamegroup = new Gamegroup(title, numbPlayers, ageRecommended, categories, price, conditionPrice, games);

                gamegroups[lineNo] = gamegroup;

                lineNo++;
            }

            return gamegroups;

        }

        public List<Customer> LoadCustomers()
        {
            string[] lines = File.ReadAllLines(DataFileName);

            List<Customer> customers = new List<Customer>();

            int lineNo = 0;
            foreach (string line in lines)
            {

                string[] customerInfo = line.Split(",");
                Request[] requests = new Request[100];
                string[] _requests;

                try
                {
                    _requests = customerInfo[5].Substring(2, customerInfo[5].Length - 3).Split(";");
                }
                catch (IndexOutOfRangeException)
                {
                    _requests = [];
                }

                for (int i = 0; i < _requests.Length; i++)
                {
                    requests[i] = new Request(_requests[i]);
                }

                customers.Add(
                    new Customer(
                        customerInfo[0],
                        customerInfo[1],
                        int.Parse(customerInfo[2]),
                        customerInfo[3],
                        int.Parse(customerInfo[4]),
                        requests
                        ));
                }
            return customers;

        }
    }
}
//Daniel, Scharla, 0,   , 1, {uno; sorte per}
//Henrik, Andersen, 67767676, henrik@gmail.com, 2, {matador}
//Sander, Andersen, 32323232, sander@gmail.com, 3, {}