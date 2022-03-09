using System;
using System.Collections.Generic;
using System.Text;

namespace CS4227.Commands
{
    class Instructions: Command
    {
        public Instructions() { }
        public void execute()
        {
            Console.WriteLine("\nType:\ninstructions: to view instructions\nexit: to exit game\nmove direction: move (replace direction with NORTH, SOUTH, EAST OR WEST)");
        }
        public void undo()
        {

        }
    }
}
