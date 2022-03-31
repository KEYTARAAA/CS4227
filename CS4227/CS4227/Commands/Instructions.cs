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
            Console.WriteLine(CONSTS.INSTRUCTIONS);
        }
        public void undo()
        {

        }
    }
}
