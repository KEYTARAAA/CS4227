using CS4227.Characters.Items;
using CS4227.Constructs;
using CS4227.Visitor;

using CS4227.Memento;
using System;
using System.Collections.Generic;

using System.Text;

namespace CS4227.Characters
{
    class Player: Character, Movable, Originator, Visitable
    {
        Inventory inventory;
        public Player(string name, int startingRoomRow, int startingRoomCol, int health, int attack) : base(name, startingRoomRow, startingRoomCol, health, attack)
        {
            inventory = new Inventory();
        }

        public override void die()
        {
            dead = true;
        }

        public void addInventory(Item item)
        {
            Console.WriteLine("\nYou have picked up " + item.getName());
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

        public bool checkInventory(string itemName)
        {
            return inventory.checkInventory(itemName);
        }

        public void printInventory()
        {
            inventory.printInventory();
        }
        public override string ToString()
        {
            return name + ": Health: " + health + " Attack: " + attack;
        }

        public IMemento createMemento()
        {
            Console.WriteLine("***MEMENTO: Making Player Memento for " + name + "***");
            return new PlayerMemento(name, roomRow, roomCol, health, attack, inventory, dead);
        }

        public void restore(IMemento memento)
        {
            Console.WriteLine("***MEMENTO: Restoring Player Memento for " + name + "***");
            PlayerMemento playerMemento = memento as PlayerMemento;
            this.name = playerMemento.getName();
            this.roomRow = playerMemento.getRoomRow();
            this.roomCol = playerMemento.getRoomCol();
            this.health = playerMemento.getHealth();
            this.attack = playerMemento.getattack();
            this.inventory = playerMemento.getInventory();
            this.dead = playerMemento.getDead();
        }

       

        public override void accept(VisitorInterface visitor)
        {
            visitor.visit(this);
        }

        public class PlayerMemento: IMemento
        {
            string name;
            int roomRow, roomCol, health, attack;
            Inventory inventory;
            bool dead;
            public PlayerMemento(string name, int roomRow, int roomCol, int health, int attack, Inventory inventory, bool dead)
            {
                this.name = name;
                this.roomRow = roomRow;
                this.roomCol = roomCol;
                this.health = health;
                this.attack = attack;
                this.dead = dead;
                this.inventory = new Inventory();

                foreach (Item i in inventory.getInventory())
                {
                    this.inventory.addItem(i);
                }
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
            public int getHealth()
            {
                return health;
            }
            public int getattack()
            {
                return attack;
            }
            public Inventory getInventory()
            {
                return inventory;
            }

            public bool getDead()
            {
                return dead;
            }

            
        }
    }
}
