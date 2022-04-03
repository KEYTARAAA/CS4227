using System;
using System.Collections.Generic;
using System.Text;

namespace CS4227.Commands
{
    class InstructionsCommand: Command
    {
        public InstructionsCommand() { }
        public void execute()
        {
            Console.WriteLine(CONSTS.INSTRUCTIONS);
        }

        public string getType()
        {
            return "Instructions";
        }
    }
}
