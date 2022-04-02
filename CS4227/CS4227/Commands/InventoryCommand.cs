using CS4227.Constructs;
using System;
using System.Collections.Generic;
using System.Text;

namespace CS4227.Commands
{
    class InventoryCommand: Command
    {
        Maze maze;

        public InventoryCommand(Maze maze)
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
