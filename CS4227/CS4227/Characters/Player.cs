using CS4227.Characters.Items;
using CS4227.Constructs;
using System;
using System.Collections.Generic;
using System.Text;

namespace CS4227.Characters
{
    class Player: Character, Movable
    {
        Inventory inventory;
        public Player(string name, int startingRoomRow, int startingRoomCol, int health, int attack) : base(name, startingRoomRow, startingRoomCol, health, attack)
        {
            inventory = new Inventory();
        }

        public override void die()
        {
            Console.WriteLine("\nYou have died.\n\nGAME OVER.");
        }

        public void addInventory(Item item)
        {
            Console.WriteLine("\nYou have piced up " + item.getName());
            inventory.addItem(item);
            StatChangingItem statChangingItem = item as StatChangingItem;
            if (statChangingItem != null)
            {
                applyStats(statChangingItem.getStats());
            }
        }

        private void applyStats(Dictionary<STAT, int> stats)
        {
            foreach (KeyValuePair<STAT,int> entry in stats)
            {
                STAT stat = entry.Key;
                int change = entry.Value;
                string sign;

                if (change < 0)
                {
                    sign = "-";
                }
                else
                {
                    sign = "+";
                }

                switch (stat)
                {
                    case STAT.ATTACK:
                        this.attack += change;
                        break;
                    case STAT.HEALTH:
                        this.health += change;
                        break;
                }
                Console.WriteLine("\n" + stat.ToString() + " " + sign+change);
            }
        }

        public void printInventory()
        {
            inventory.printInventory();
        }
        public override string ToString()
        {
            return name + ": Health: " + health + " Attack: " + attack;
        }
    }
}
