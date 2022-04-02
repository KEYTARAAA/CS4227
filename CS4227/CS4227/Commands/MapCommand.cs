using CS4227.Constructs;
using System;
using System.Collections.Generic;
using System.Text;

namespace CS4227.Commands
{
    class MapCommand : Command
    {
        Maze maze;

        public MapCommand(Maze maze)
        {
            this.maze = maze;
        }
        public void execute()
        {
            maze.printMaze();
        }

        public string getType()
        {
            return "";
        }
    }
}
