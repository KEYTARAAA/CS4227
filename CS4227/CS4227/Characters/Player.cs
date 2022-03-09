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

        public void move(Direction direction)
        {
            switch (direction)
            {
                case Direction.NORTH:
                    roomRow -= 1;
                    break;
                case Direction.SOUTH:
                    roomRow += 1;
                    break;
                case Direction.EAST:
                    roomCol -= 1;
                    break;
                case Direction.WEST:
                    roomCol += 1;
                    break;
            }
        }

    }
}
