using System;
using System.Collections.Generic;
using System.Text;

namespace CS4227.Commands
{
    interface Command
    {
        public void execute();
        public void undo();
    }
}
