using CS4227.Characters;
using CS4227.Constructs;
using System;
using System.Collections.Generic;
using System.Text;

namespace CS4227.Commands
{
    class Move: Command
    {
        Direction direction;
        Maze maze;
        bool directionSet = false;
        public Move(string[] directionString,  Maze maze)
        {
            this.maze = maze;
            if (directionString.Length > 1) {
                switch (directionString[1])
                {
                    case "NORTH":
                        direction = Direction.NORTH;
                        directionSet = true;
                        break;
                    case "SOUTH":
                        direction = Direction.SOUTH;
                        directionSet = true;
                        break;
                    case "EAST":
                        direction = Direction.EAST;
                        directionSet = true;
                        break;
                    case "WEST":
                        direction = Direction.WEST;
                        directionSet = true;
                        break;
                }
            }
        }

        public void execute()
        {
            if (directionSet)
            {
                maze.movePlayer(direction);
            }else{
                Console.WriteLine("\nDirection does not exist!\n");
            }
        }

        public void undo()
        {
            
        }
    }
}
