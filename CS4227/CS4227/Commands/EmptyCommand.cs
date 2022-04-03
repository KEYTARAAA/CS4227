using System;
using System.Collections.Generic;
using System.Text;

namespace CS4227.Commands
{
    class EmptyCommand: Command
    {
        public void execute()
        {

        }
        public string getType()
        {
            return "Empty";
        }
    }
}
