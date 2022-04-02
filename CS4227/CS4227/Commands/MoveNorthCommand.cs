using System;
using System.Collections.Generic;
using System.Text;
using CS4227.Constructs;


namespace CS4227.Commands
{
    class MoveNorthCommand : Command
    {
        Maze maze;

        public MoveNorthCommand(Maze maze)
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