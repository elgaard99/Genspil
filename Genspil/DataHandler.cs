using System;
using System.Collections.Generic;
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
        
        public void SaveGamegroups(Gamegroup[] gamegroups)
        {

            StreamWriter writer = new StreamWriter(DataFileName);

            foreach (Gamegroup gamegroup in gamegroups)
            {

                writer.WriteLine(gamegroup.ToString());

            }

            writer.Close();

        }
        /*
        public Person[] LoadPersons()
        {
            string[] lines = File.ReadAllLines(DataFileName);

            int noPersons = 0;
            foreach (string line in lines)
            { if (line.Split(";")[0] == "person") noPersons++; }

            Person[] persons = new Person[noPersons];

            int lineNo = 0;
            foreach (string line in lines)
            {

                string[] personInfo = line.Split(";");
                if (personInfo[0] != "person") { continue; }

                int teamId = int.Parse(personInfo[1]);
                string name = personInfo[2];
                DateTime birthDate = DateTime.Parse(personInfo[3]);
                double height = double.Parse(personInfo[4]);
                bool isMarried = bool.Parse(personInfo[5]);
                int noOfChildren = int.Parse(personInfo[6]);

                Person person = new Person(teamId, name, birthDate, height, isMarried, noOfChildren);

                persons[lineNo] = person;
                lineNo++;
            }

            return persons;

        }

        public void SaveTeams(Team[] teams)
        {

            using (StreamWriter writer = new StreamWriter(DataFileName))
            {
                foreach (Team team in teams)
                {

                    writer.WriteLine("team;" + team.MakeTitle());

                }
            }
        }
        */
        
    }
}
