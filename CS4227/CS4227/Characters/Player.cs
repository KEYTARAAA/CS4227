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

        }


        public void moveLeft()
        {
            this.roomCol = this.roomCol - 1;
            Console.WriteLine("Moving Left");
        }

        public void moveRight()
        {
            this.roomCol = this.roomCol + 1;
            Console.WriteLine("Moving Right");
        }
        public void moveUp()
        {
            this.roomRow = this.roomRow + 1;
            Console.WriteLine("Moving Up");
        }

        public void moveDown()
        {
            this.roomRow = this.roomRow - 1;
            Console.WriteLine("Moving Down");
        }

        public override string ToString()
        {
            return name + ": Health: " + health + " Attack: " + attack;
        }
    }
}
