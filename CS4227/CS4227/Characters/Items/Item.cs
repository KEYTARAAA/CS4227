using System;
using System.Collections.Generic;
using System.Text;

namespace CS4227.Characters.Items
{
    class Item
    {
        string name;
        int roomRow, roomCol;

        public Item(string name)
        {
            this.name = name;
        }

        public string getName()
        {
            return name;
        }
        public int getRoomRow()
        {
            return roomRow;
        }
        public int getRoomCol()
        {
            return roomCol;
        }
        public void setRoom(int row, int col)
        {
            roomRow = row;
            roomCol = col;
        }

    }
}
