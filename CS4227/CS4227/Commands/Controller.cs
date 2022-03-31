using System;
using System.Collections.Generic;
using System.Text;

namespace CS4227.Commands
{
    class Controller
    {
        Command moveWestCommand;
        Command moveEastCommand;
        Command moveNorthCommand;
        Command moveSouthCommand;
        Command attackCommand;
        Command lastCommand;
        public void setCommand(Command command, int i)
        {
            if(i == 1)
            {
                moveWestCommand = command;
            }
            if(i == 2)
            {
                moveEastCommand = command;
            }
            if(i == 3)
            {
                moveNorthCommand = command;
            }
            if(i == 4)
            {
                moveSouthCommand = command;
            }
            if(i == 5)
            {
                attackCommand = command;
            }
        }

        public void keyPressed(string s)
        {
            if(s == "A")
            {
                moveWestCommand.execute();
                lastCommand = moveWestCommand;
            }
            if(s == "S")
            {
                moveSouthCommand.execute();
                lastCommand = moveSouthCommand;
            }
            if(s == "D")
            {
                moveEastCommand.execute();
                lastCommand = moveEastCommand;
            }
            if(s == "W")
            {
                moveNorthCommand.execute();
                lastCommand = moveNorthCommand;
            }
            if (s == "C")
            {
                attackCommand.execute();
                lastCommand = attackCommand;
            }

        }

        public string getLastCommand()
        {
            return lastCommand.getType();
        }
    }
}
