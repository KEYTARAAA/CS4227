using CS4227.Commands;
using CS4227.Constructs;
using System;
using System.Collections.Generic;
using System.Text;

namespace CS4227
{
    class Game
    {
        Maze maze;
        public Game()
        {
            maze = new Maze();
        }

        public void start()
        {
            Console.WriteLine("\nType:\ninstructions: to view instructions\nexit: to exit game\nmove direction: move(replace direction with NORTH, SOUTH, EAST OR WEST)");
            bool run = true;
            while (run)
            {
                run = reciever();
            }
        }

        private bool reciever()
        {
            string input = Console.ReadLine().ToUpper();
            Command command = null;
            string[] inputs =  input.Split(' ');
            switch (inputs[0]) {
                default:
                    return true;
                case "INSTRUCTIONS":
                    command = new Instructions();
                    break;
                case "MOVE":
                    command = new Move(inputs, maze);
                    break;
                case "EXIT": 
                    return false;

            }

            Console.WriteLine("\nExecuting command: " + input + "\n");
            command.execute();
            return true;
            
            
        }
    }
}
