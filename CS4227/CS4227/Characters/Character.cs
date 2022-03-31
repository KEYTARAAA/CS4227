using System;
using System.Collections.Generic;
using System.Text;

namespace CS4227.Characters
{
    abstract class Character
    {
        protected int roomRow, roomCol, health, attack;
        protected string name;
        protected bool dead = false;

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

        public void setHealth(int health)
        {
            this.health = health;
        }
        public void setAttack(int attack)
        {
            this.attack = attack;
        }

       public void move(Direction direction)
        {
            switch (direction)
            {
                case Direction.NORTH:
                    roomRow--;
                    break;
                case Direction.SOUTH:
                    roomRow++;
                    break;
                case Direction.EAST:
                    roomCol++;
                    break;
                case Direction.WEST:
                    roomCol--;
                    break;
            }
        }


        abstract public void die();
    }
}
