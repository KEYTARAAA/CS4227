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
    }
}
