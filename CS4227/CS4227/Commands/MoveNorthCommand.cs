using System;
using System.Collections.Generic;
using System.Text;
using CS4227.Constructs;
using CS4227.Facade;

namespace CS4227.Commands
{
    class MoveNorthCommand : Command
    {
        MazeFacade maze;

        public MoveNorthCommand(MazeFacade maze)
        {
            this.maze = maze;
        }

        public void execute()
        {
            maze.movePlayerNorth();
        }

        public void undo() { }
        public string getType()
        {
            return "MoveNorth";
        }
    }
}