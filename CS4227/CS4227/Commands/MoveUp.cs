using System;
using System.Collections.Generic;
using System.Text;
using CS4227.Constructs;


namespace CS4227.Commands
{
    class MoveUp : Command
    {
        Maze maze;

        public MoveUp(Maze maze)
        {
            this.maze = maze;
        }

        public void execute()
        {
            maze.moveUp();
        }

        public void undo() { }
    }
}