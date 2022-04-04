using CS4227.Memento;
using System;
using System.Collections.Generic;
using System.Text;

namespace CS4227.Characters.Items
{
    class Item: Originator
    {
        protected string name;
        protected int roomRow, roomCol;
        protected bool active;

        public Item(string name)
        {
            this.name = name;
            active = true;
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
        public void setActive(bool active)
        {
            this.active = active;
        }

        public bool getActive()
        {
            return active;
        }
        public virtual IMemento createMemento()
        {
            Console.WriteLine("***MEMENTO: Making Item Memento for " + name + "***");
            return new ItemMemento(name, roomRow, roomCol,active);
        }

        public virtual void restore(IMemento memento)
        {
            Console.WriteLine("***MEMENTO: Restoring Item Memento for " + name + "***");
            ItemMemento itemMemento = memento as ItemMemento;
            if (itemMemento != null)
            {
                this.name = itemMemento.getName();
                this.roomRow = itemMemento.getRoomRow();
                this.roomCol = itemMemento.getRoomCol();
                this.active = itemMemento.getActive();
            }
        }

        public class ItemMemento : IMemento
        {
            string name;
            int roomRow, roomCol;
            bool active;
            public ItemMemento(string name, int roomRow, int roomCol, bool active)
            {
                this.name = name;
                this.roomRow = roomRow;
                this.roomCol = roomCol;
                this.active = active;
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
            public bool getActive()
            {
                return active;
            }
        }
    }
}
