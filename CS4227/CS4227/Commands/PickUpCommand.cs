using CS4227.Constructs;
using System;
using System.Collections.Generic;
using System.Text;

namespace CS4227.Commands
{
    class PickUpCommand : Command
    {
        Maze maze;

        public PickUpCommand(Maze maze)
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
