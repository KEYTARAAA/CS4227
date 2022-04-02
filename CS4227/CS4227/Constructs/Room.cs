using System;
using System.Collections.Generic;
using System.Text;

namespace CS4227.Constructs
{
    class Room
    {
        int row, col;
        string name, mapName;
        Dictionary<Direction, bool> exits;

        public Room(int row, int col, string name, string mapName)
        {
            this.row = row;
            this.col = col;
            this.name = name;
            this.mapName = mapName;
            exits = new Dictionary<Direction, bool>();
            exits.Add(Direction.NORTH, false);
            exits.Add(Direction.SOUTH, false);
            exits.Add(Direction.EAST, false);
            exits.Add(Direction.WEST, false);
        }

        public int getRow()
        {
            return row;
        }
        public int getCol()
        {
            return col;
        }
        public string getName()
        {
            return name;
        }
        public string getMapName()
        {
            return mapName;
        }

        public void setExit(Direction direction, bool exit)
        {
            exits[direction] = exit;
        }
        public bool getExit(Direction direction)
        {
            return exits[direction];
        }

        public string getLongDescription()
        {
            string longDescription = "Room " + name;
            longDescription += "\nExits: ";
            foreach (KeyValuePair<Direction, bool> entry in exits)
            {
                if (entry.Value)
                {
                    longDescription += entry.Key.ToString() + " ";
                }
            }
            return longDescription;
        }

        public List<Direction> getExits()
        {
            List<Direction> e = new List<Direction>();
            foreach(KeyValuePair<Direction, bool> entry in exits)
            {
                if (entry.Value)
                {
                    e.Add(entry.Key);
                }
            }
            return e;
        }
    }
}
