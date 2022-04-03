using CS4227.Constructs;
using CS4227.Facade;
using System;
using System.Collections.Generic;
using System.Text;

namespace CS4227.Commands
{
    class UndoCommand: Command
    {
        MazeFacade maze;

        public UndoCommand(MazeFacade maze)
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
