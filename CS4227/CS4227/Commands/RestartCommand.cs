using CS4227.Facade;
using System;
using System.Collections.Generic;
using System.Text;

namespace CS4227.Commands
{
    class RestartCommand:Command
    {
        MazeFacade maze;

        public RestartCommand(MazeFacade maze)
        {
            this.maze = maze;
        }

        public void execute()
        {
            maze.restart();
        }

        public string getType()
        {
            return "Restart";
        }
    }
}
