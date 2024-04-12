using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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

    }
}
