using System;
using System.Collections.Generic;
using System.Text;

namespace CS4227.Characters
{
    abstract class Character
    {
        protected int roomRow, roomCol, health, attack;
        protected string name;

        public Character(string name, int startingRoomRow, int startingRoomCol, int health, int attack)
        {
            this.name = name;
            roomRow = startingRoomRow;
            roomCol = startingRoomCol;
            this.health = health;
            this.attack = attack;
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
        public int getAttack()
        {
            return attack;
        }

        public void changeHealth(int change)
        {
            health += change;
        }
        public void changeAttack(int change)
        {
            attack += change;
        }

        abstract public void die();
    }
}
