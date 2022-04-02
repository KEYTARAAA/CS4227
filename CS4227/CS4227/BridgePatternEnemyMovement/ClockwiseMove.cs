using System;
using System.Collections.Generic;
using System.Text;
using CS4227.Constructs;

namespace CS4227.BridgePatternEnemyMovement
{
    class ClockwiseMove : MovementInterface
    {

        public Direction move(List<Direction> exits)
        {
            bool north = false;
            bool east = false;
            bool south = false;

            foreach (Direction direction in exits)
            {
                switch (direction)
                {
                    case Direction.NORTH:
                        north = true;
                        break;
                    case Direction.SOUTH:
                        south = true;
                        break;
                    case Direction.EAST:
                        east = true;
                        break;
                }
            }

            if (north)
            {
                return Direction.NORTH;
            }else if (east)
            {
                return Direction.EAST;
            }else if (south)
            {
                return Direction.SOUTH;
            }else
            {
                return Direction.WEST;
            }
        }
    }
}
