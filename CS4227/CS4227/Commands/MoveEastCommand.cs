using System;
using System.Collections.Generic;
using System.Text;
using CS4227.Constructs;
using CS4227.Facade;

namespace CS4227.Commands
{
    class MoveEastCommand : Command
    {
        MazeFacade maze;

        public MoveEastCommand(MazeFacade maze)
        {
            this.maze = maze;
        }

        public void execute()
        {
            maze.movePlayerEast();
        }

        public void undo() { }

        public string getType()
        {
            return "MoveEast";
        }
    }
}