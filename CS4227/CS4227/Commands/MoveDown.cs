using System;
using System.Collections.Generic;
using System.Text;
using CS4227.Constructs;


namespace CS4227.Commands
{
    class MoveDown : Command
    {
        Maze maze;

        public MoveDown(Maze maze)
        {
            this.maze = maze;
        }

        public void execute()
        {
            maze.moveDown();
        }

        public void undo() { }
    }
}
