using CS4227.Memento;
using System;
using System.Collections.Generic;
using System.Text;

namespace CS4227.Characters.Items
{
    class StatChangingItem: Item
    {
        Dictionary<STAT, int> stats;

        public StatChangingItem(string name, Dictionary<STAT, int> stats): base(name)
        {
            this.stats = stats;
        }

        public Dictionary<STAT, int> getStats()
        {
            return stats;
        }

        public override IMemento createMemento()
        {
            return new StatChangingItemMemento(name, roomRow, roomCol, active, stats);
        }

        public override void restore(IMemento memento)
        {
            StatChangingItemMemento statChangingItemMemento = memento as StatChangingItemMemento;
            if (statChangingItemMemento != null)
            {
                this.name = statChangingItemMemento.getName();
                this.roomRow = statChangingItemMemento.getRoomRow();
                this.roomCol = statChangingItemMemento.getRoomCol();
                this.active = statChangingItemMemento.getActive();
                this.stats = statChangingItemMemento.getStats();
            }
        }

        public class StatChangingItemMemento : IMemento
        {
            string name;
            int roomRow, roomCol;
            bool active;
            Dictionary<STAT, int> stats;
            public StatChangingItemMemento(string name, int roomRow, int roomCol, bool active, Dictionary<STAT, int> stats)
            {
                this.name = name;
                this.roomRow = roomRow;
                this.roomCol = roomCol;
                this.active = active;
                this.stats = stats;
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
            public Dictionary<STAT, int> getStats()
            {
                return stats;
            }
        }
    }
}
