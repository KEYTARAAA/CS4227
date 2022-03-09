using System;
using System.Collections.Generic;
using System.Text;

namespace CS4227.Characters
{
    class Item
    {
        string name;
        STAT stat;
        int statChange;

        public Item(string name, STAT stat, int statChange)
        {
            this.name = name;
            this.stat = stat;
            this.statChange = statChange;
        }

        public string getName()
        {
            return name;
        }

        public STAT getStat()
        {
            return stat;
        }

        public int getStatChange()
        {
            return statChange;
        }
    }
}
