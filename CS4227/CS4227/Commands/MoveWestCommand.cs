using System;
using System.Collections.Generic;
using System.Text;
using CS4227.Constructs;
using CS4227.Facade;

namespace CS4227.Commands
{
    class MoveWestCommand : Command
    {
        MazeFacade maze;

        public MoveWestCommand(MazeFacade maze)
        {
            this.maze = maze;
        }

        public void execute()
        {
            maze.movePlayerWest();
        }
        public void undo() { }

        public string getType()
        {
            return "MoveWest";
        }
    }
}