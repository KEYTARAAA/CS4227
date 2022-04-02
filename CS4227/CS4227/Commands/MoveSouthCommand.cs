using System;
using System.Collections.Generic;
using System.Text;
using CS4227.Constructs;


namespace CS4227.Commands
{
    class MoveSouthCommand : Command
    {
        Maze maze;

        public MoveSouthCommand(Maze maze)
        {
            this.maze = maze;
        }

        public void execute()
        {
            maze.movePlayerSouth();
        }

        public void undo() { }

        public string getType()
        {
            return "MoveSouth";
        }
    }
}
