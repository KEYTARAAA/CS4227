using System;
using System.Collections.Generic;
using System.Text;

namespace CS4227.Commands
{
    class Controller
    {
        Command moveLeftCommand;
        Command moveRightCommand;
        Command moveUpCommand;
        Command moveDownCommand;
        public void setCommand(Command command, int i)
        {
            if(i == 1)
            {
                moveLeftCommand = command;
            }
            if(i == 2)
            {
                moveRightCommand = command;
            }
            if(i == 3)
            {
                moveUpCommand = command;
            }
            if(i == 4)
            {
                moveDownCommand = command;
            }
        }

        public void keyPressed(string s)
        {
            if(s == "A")
            {
                moveLeftCommand.execute();
            }
            if(s == "S")
            {
                moveDownCommand.execute();
            }
            if(s == "D")
            {
                moveRightCommand.execute();
            }
            if(s == "W")
            {
                moveUpCommand.execute();
            }

        }
    }
}
