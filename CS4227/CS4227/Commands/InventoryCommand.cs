using CS4227.Constructs;
using CS4227.Facade;
using System;
using System.Collections.Generic;
using System.Text;

namespace CS4227.Commands
{
    class InventoryCommand: Command
    {
        MazeFacade maze;

        public InventoryCommand(MazeFacade maze)
        {
            this.maze = maze;
        }

        public void execute()
        {
            maze.playerInventory();
        }

        public string getType()
        {
            return "Inventory";
        }
    }
}
