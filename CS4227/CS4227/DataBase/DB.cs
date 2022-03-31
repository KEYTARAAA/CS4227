using System;
using System.Collections.Generic;
using System.Text;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace CS4227.DataBase
{

    class DB
    {

        string startPath = null;
        string delimiter = ", ";
        public DB()
        {

            startPath = "../../Data/";
        }

        public void createStatsFile(string name)
        {
            string newPath = @"../../../Data/" + name + ".csv";
            if (!File.Exists(newPath))
            {

                string createColumns = "Number of Attacks" + delimiter
                    + "Number of Enemies Killed" + delimiter
                    + "Number of Weapons Broken" + delimiter
                    + "Deaths" + delimiter
                    + "Maze Moves" + delimiter
                    + "Wins"
                    + Environment.NewLine;
                string intialScores = "0" + delimiter + "0" + delimiter + "0"
                    + delimiter + "0" + delimiter + "0" + delimiter + "0" + Environment.NewLine;


                File.WriteAllText(newPath, createColumns);
                File.AppendAllText(newPath, intialScores);
            }
        }


        public void createGameLogsFile(string name)
        {
            string newPath = @"../../../Data/" + name + ".csv";
            if (!File.Exists(newPath))
            {

                string header = "These are the game logs for actions taken and resultant game state" + Environment.NewLine; ; 
                File.WriteAllText(newPath, header);
            }
        }

        //C:\Users\ronal\Source\Repos\CS4227\CS4227\CS4227\Data\

        //C:\Users\ronal\Source\Repos\CS4227\CS4227\CS4227\Data\test.csv

        private void write(string path, string insert)
        {
            File.AppendAllText(startPath + path + ".csv", insert + "\n");
        }

        public string[] readTotalStats(string name)
        {
            //C: \Users\ronal\Source\Repos\CS4227\CS4227\CS4227\Data\Player_total_stats.csv
            string newPath = @"../../../Data/";
            string[] values = new string[] { };
            using (var reader = new StreamReader(newPath + name + "_total_stats.csv"))
            {
                string d = reader.ReadLine();
                while (!reader.EndOfStream)
                {
                    d = reader.ReadLine();
                    values = d.Split(',');


                }
            }
            return values;
        }

        public void writeToStatsFile(string name, string [] values)
        {
            string newPath = @"../../../Data/" + name + ".csv";
            if (File.Exists(newPath))
            {

                string createColumns = "Number of Attacks" + delimiter
                    + "Number of Enemies Killed" + delimiter
                    + "Number of Weapons Broken" + delimiter
                    + "Deaths" + delimiter
                    + "Maze Moves" + delimiter
                    + "Wins"
                    + Environment.NewLine;
                string scores = values[0] + delimiter + values[1] + delimiter + values[2]
                    + delimiter + values[3] + delimiter + values[4] + delimiter + values[5] + Environment.NewLine;


                File.WriteAllText(newPath, createColumns);
                File.AppendAllText(newPath, scores);
            }
        }

        public void writeToGameLogsFile(string name, string s)
        {
            string newPath = @"../../../Data/" + name + ".csv";
            if (File.Exists(newPath))
            {

                File.AppendAllText(newPath, s);
            }
        }






    }
}
