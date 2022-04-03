using CS4227.Constructs;
using CS4227.Facade;
using System;
using System.Collections.Generic;
using System.Text;

namespace CS4227.Commands
{
    class PickUpCommand : Command
    {
        MazeFacade maze;

        public PickUpCommand(MazeFacade maze)
        {
            this.maze = maze;
        }

        public void execute()
        {
            maze.playerPickUp();
        }

        public string getType()
        {
            return "PickUp";
        }
    }
}
