using CS4227.Constructs;
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
        Command mapCommand;
        Command instructionsCommand;
        Command pickUpCommand;
        Command inventoryCommand;
        Command undoCommand;
        Command exitCommand;
        Command emptyCommand;
        Command lastCommand;

        public void setCommand(Command command, int i)
        {

            switch (i)
            {
                case 0:
                    emptyCommand = command;
                    break;
                case 1:
                    moveWestCommand = command;
                    break;
                case 2:
                    moveEastCommand = command;
                    break;
                case 3:
                    moveNorthCommand = command;
                    break;
                case 4:
                    moveSouthCommand = command;
                    break;
                case 5:
                    attackCommand = command;
                    break;
                case 6:
                    mapCommand = command;
                    break;
                case 7:
                    instructionsCommand = command;
                    break;
                case 8:
                    pickUpCommand = command;
                    break;
                case 9:
                    inventoryCommand = command;
                    break;
                case 10:
                    undoCommand = command;
                    break;
                case 11:
                    exitCommand = command;
                    break;
            }
            lastCommand = command;
        }

        public void keyPressed(string s)
        {
            switch (s)
            {
                case "N":
                    moveNorthCommand.execute();
                    break;
                case "S":
                    moveSouthCommand.execute();
                    break;
                case "E":
                    moveEastCommand.execute();
                    break;
                case "W":
                    moveWestCommand.execute();
                    break;
                case "A":
                    attackCommand.execute();
                    break;
                case "M":
                    mapCommand.execute();
                    break;
                case "P":
                    pickUpCommand.execute();
                    break;
                case "I":
                    inventoryCommand.execute();
                    break;
                case "U":
                    undoCommand.execute();
                    break;
                case "?":
                    instructionsCommand.execute();
                    break;
                case "EXIT":
                    exitCommand.execute();
                    break;
                default:
                    emptyCommand.execute();
                    break;
            }
        }

        public string getLastCommand()
        {
            return lastCommand.getType();
        }
    }
}
