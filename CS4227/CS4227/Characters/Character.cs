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

        public Character()
        {
            // is it needed to be set? or can it be left default null
            this.name = "";
            roomRow = 1;
            roomCol = 1;
            this.health = 1;
            this.attack = 1;
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
            if (health <= 0)
            {
                die();
            }
        }
        public void setAttack(int attack)
        {
            this.attack = attack;
        }

        public void attackOther(Character other)
        {
            other.setHealth(other.health - this.attack);
        }

       public void move(Direction direction)
        {
            switch (direction)
            {
                case Direction.NORTH:
                    if (roomRow!=0)
                    {
                        roomRow--;
                    }
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

        public bool getDead()
        {
            return dead;
        }
        public void setDead(bool dead)
        {
            this.dead = dead;
        }

        public void setName(string name)
        {
            this.name = name;
        }

        public void setRoom(int roomRow, int roomCol)
        {
            this.roomRow = roomRow;
            this.roomCol = roomCol;
        }

        override
        abstract public string ToString();


        abstract public void die();
    }
}
