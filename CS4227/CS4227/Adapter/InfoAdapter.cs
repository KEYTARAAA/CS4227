using CS4227.Characters.Enemies;
using CS4227.Characters.Items;
using System;
using System.Collections.Generic;
using System.Text;

namespace CS4227.Adapter
{
    class InfoAdapter : IInfo
    {
        private readonly string info;
        public InfoAdapter(Enemy enemy)
        {
            Console.WriteLine("***PLUGGABLE ADAPTER: Creating new InfoAdapter for Enemy***");
            info = enemy.getPortrait()+"\nEnemy Info: " + enemy.getName() + ": Health: " + enemy.getHealth() + " Attack: " + enemy.getAttack();
        }

        public InfoAdapter(Item item)
        {
            Console.WriteLine("***PLUGGABLE ADAPTER: Creating new InfoAdapter for Item***");
            info = "Item Info: " + item.getName();
        }

        public String getInfo()
        {
            Console.WriteLine("***PLUGGABLE ADAPTER: Getting info for current InfoAdapter***");
            return info;
        }
    }
}
