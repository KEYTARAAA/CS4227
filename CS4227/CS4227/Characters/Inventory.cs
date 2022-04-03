using CS4227.Characters.Items;
using System;
using System.Collections.Generic;
using System.Text;

namespace CS4227.Characters
{
    class Inventory
    {
        List<Item> inventory;

        public Inventory()
        {
            inventory = new List<Item>();
        }

        public void addItem(Item item)
        {
            inventory.Add(item);
        }

        public void removeItem(string item)
        {
            foreach(Item i in inventory)
            {
                if (i.getName() == item)
                {
                    inventory.Remove(i);
                    break;
                }
            }
        }

        public void clearInventory()
        {
            inventory.Clear();
        }

        public bool checkInventory(string item)
        {
            foreach (Item i in inventory)
            {
                if (i.getName().ToUpper() == item.ToUpper())
                {
                    return true;
                }
            }
            return false;
        }

        public void printInventory()
        {
            Console.WriteLine("\nInventory:");
            foreach (Item i in inventory)
            {
                Console.Write(i.getName());

                StatChangingItem statChangingItem = i as StatChangingItem;
                if (statChangingItem != null)
                {
                    printStats(statChangingItem.getStats());
                }

                Console.Write("\n");
            }
        }

        void printStats(Dictionary<STAT, int> stats)
        {
            Console.Write(":");
            foreach (KeyValuePair<STAT, int> entry in stats)
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
                Console.Write(" " + stat.ToString() + " " + sign + change + " ");
            }
        }

        public List<Item> getInventory()
        {
            return inventory;
        }
    }
}
