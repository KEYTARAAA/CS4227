using System;
using System.Collections.Generic;
using System.Text;

namespace CS4227.Commands
{
    class ExitCommand : Command
    {
        public void execute()
        {
            Environment.Exit(0);
        }
        public string getType()
        {
            return "Exit";
        }
    }
}
