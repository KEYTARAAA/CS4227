using System;
using System.Collections.Generic;
using System.Text;

namespace CS4227.Commands
{
    class Exit : Command
    {
        public void execute()
        {
            Environment.Exit(0);
        }
    }
}
