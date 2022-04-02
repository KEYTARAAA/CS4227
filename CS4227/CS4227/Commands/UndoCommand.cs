using CS4227.Constructs;
using System;
using System.Collections.Generic;
using System.Text;

namespace CS4227.Commands
{
    class UndoCommand: Command
    {
        Maze maze;

        public UndoCommand(Maze maze)
        {
            this.maze = maze;
        }

        public void execute()
        {
            maze.undo();
        }

        public string getType()
        {
            return "Undo";
        }
    }
}
