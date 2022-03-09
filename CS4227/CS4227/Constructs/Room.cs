using System;
using System.Collections.Generic;
using System.Text;

namespace CS4227.Constructs
{
    class Room
    {
        int row, col;
        string name;

        public Room(int row, int col, string name)
        {
            this.row = row;
            this.col = col;
            this.name = name;
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
    }
}
