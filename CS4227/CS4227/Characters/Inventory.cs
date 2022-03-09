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
                if (i.getName() == item)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
