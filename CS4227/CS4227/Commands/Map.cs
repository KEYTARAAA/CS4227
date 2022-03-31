using CS4227.Constructs;
using System;
using System.Collections.Generic;
using System.Text;

namespace CS4227.Commands
{
    class Map : Command
    {
        Maze maze;

        public Map(Maze maze)
        {
            this.maze = maze;
        }
        public void execute()
        {
            maze.printMaze();
        }
    }
}
