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
        Command restartCommand;
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
                    restartCommand = command;
                    break;
                case 12:
                    exitCommand = command;
                    break;
            }
            lastCommand = command;
            Console.WriteLine("***COMMAND: Controller setting up "+ command.getType() +" command***");
        }

        public void keyPressed(string s)
        {
            switch (s)
            {
                case "N":
                    moveNorthCommand.execute();
                    lastCommand = moveNorthCommand;
                    break;
                case "S":
                    moveSouthCommand.execute();
                    lastCommand = moveSouthCommand;
                    break;
                case "E":
                    moveEastCommand.execute();
                    lastCommand = moveEastCommand;
                    break;
                case "W":
                    moveWestCommand.execute();
                    lastCommand = moveWestCommand;
                    break;
                case "A":
                    attackCommand.execute();
                    lastCommand = attackCommand;
                    break;
                case "M":
                    mapCommand.execute();
                    lastCommand = mapCommand;
                    break;
                case "P":
                    pickUpCommand.execute();
                    lastCommand = pickUpCommand;
                    break;
                case "I":
                    inventoryCommand.execute();
                    lastCommand = inventoryCommand;
                    break;
                case "U":
                    undoCommand.execute();
                    lastCommand = undoCommand;
                    break;
                case "R":
                    restartCommand.execute();
                    lastCommand = restartCommand;
                    break;
                case "?":
                    instructionsCommand.execute();
                    lastCommand = instructionsCommand;
                    break;
                case "EXIT":
                    exitCommand.execute();
                    lastCommand = exitCommand;
                    break;
                default:
                    emptyCommand.execute();
                    lastCommand = emptyCommand;
                    break;
            }
            Console.WriteLine("***COMMAND: Executed "+lastCommand.getType()+" command***");
        }

        public string getLastCommand()
        {
            return lastCommand.getType();
        }
    }
}
