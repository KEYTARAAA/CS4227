using System;
using System.Collections.Generic;
using System.Text;

using CS4227.Characters.Enemies;
namespace CS4227
{
    class MazeRoom
    {
        string description;
        Dictionary<string, MazeRoom> exits;
        List<EnemyInterface> enemies = new List<EnemyInterface>();

        public MazeRoom(string description)
        {
            this.description = description;
            this.exits = new Dictionary<string, MazeRoom>();
            this.exits["north"] = null;
            this.exits["south"] = null;
            this.exits["east"] = null;
            this.exits["west"] = null;
            List<EnemyInterface> enemies = new List<EnemyInterface>();
        }

        public void setExits(MazeRoom north, MazeRoom south, MazeRoom east, MazeRoom west)
        {
            if (north != null)
                this.exits["north"] = north;
            if (east != null)
                this.exits["east"] = east;
            if (south != null)
                this.exits["south"] = south;
            if (west != null)
                this.exits["west"] = west;

        }

        public string shortDescription()
        {
            return description;
        }

        public string longDescription()
        {
            string enemiesString = "";
            for (int i = 0; i < this.enemies.Count; i++)
            {
                enemiesString += enemies[i].roar() + " ";
            }
            return "room = " + description + "\n" + exitString() + "\n" + enemiesString;
        }

        public string exitString()
        {
            string returnString = "\nexits =";
            if (exits["north"] != null)
                returnString += "north ";
            if (exits["east"] != null)
                returnString += "east ";
            if (exits["south"] != null)
                returnString += "south ";
            if (exits["west"] != null)
                returnString += "west ";
            return returnString;
        }

        public Dictionary<string, MazeRoom> getExits()
        {
            return exits;
        }

        public void addEnemyToRoom(EnemyInterface enemy)
        {
            this.enemies.Add(enemy);
        }

        public void removeEnemyFromRoom(EnemyInterface enemy)
        {
            this.enemies.Remove(enemy);
        }
    }

    
}
