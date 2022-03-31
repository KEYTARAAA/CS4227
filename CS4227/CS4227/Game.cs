using CS4227.Commands;
using CS4227.Characters.Enemies;
using CS4227.Constructs;
using System;
using System.Collections.Generic;
using System.Text;

namespace CS4227
{
    class Game
    {
        Maze maze;
        //Controller controller;
        public Game()
        {
            maze = new Maze();
            /*controller = new Controller();
            MoveSouth moveDown = new MoveSouth(maze);
            MoveNorth moveUp = new MoveNorth(maze);
            MoveWest moveLeft = new MoveWest(maze);
            MoveEast moveRight = new MoveEast(maze);

            controller.setCommand(moveLeft, 1);
            controller.setCommand(moveRight, 2);
            controller.setCommand(moveUp, 3);
            controller.setCommand(moveDown, 4);
            */
        }

        public void loop()
        {
            Console.WriteLine(CONSTS.INSTRUCTIONS);
            while (true)
            {
                maze.refresh();
                terminalInputReciever();
            }
        }

        private void terminalInputReciever()
        {
            string input = Console.ReadLine().ToUpper();
            string[] inputs =  input.Split(' ');
            Command c;
            switch (inputs[0])
            {
                case ("?"):
                    c = new Instructions();
                    break;
                case ("M"):
                    c = new Map(maze);
                    break;
                case ("N"):
                    c = new Move(maze, Direction.NORTH);
                    break;
                case ("S"):
                    c = new Move(maze, Direction.SOUTH);
                    break;
                case ("E"):
                    c = new Move(maze, Direction.EAST);
                    break;
                case ("W"):
                    c = new Move(maze, Direction.WEST);
                    break;
                case ("A"):
                    c = new Attack(maze);
                    break;
                case ("EXIT"):
                    c = new Exit();
                    break;
                default:
                    c = new Empty();
                    break;
            }
            c.execute();
            
        }
    }
}
