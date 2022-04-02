using System;
using System.Collections.Generic;
using System.Text;

namespace CS4227.Characters
{
    interface Movable
    {
        public void move(Direction direction)
        {
            /*switch (direction)
            {
                case Direction.NORTH:
                    roomRow -= 1;
                    break;
                case Direction.SOUTH:
                    roomRow += 1;
                    break;
                case Direction.EAST:
                    RoomCol -= 1;
                    break;
                case Direction.WEST:
                    RoomCol += 1;
                    break;
            }*/
        }
    }
}
