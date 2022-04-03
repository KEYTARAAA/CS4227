using CS4227.Constructs;
using CS4227.Facade;
using System;
using System.Collections.Generic;
using System.Text;

namespace CS4227.Commands
{
    class MapCommand : Command
    {
        MazeFacade maze;

        public MapCommand(MazeFacade maze)
        {
            this.maze = maze;
        }
        public void execute()
        {
            maze.printMaze();
        }

        public string getType()
        {
            return "Map";
        }
    }
}
