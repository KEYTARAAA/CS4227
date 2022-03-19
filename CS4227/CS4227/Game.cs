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
        Controller controller;
        public Game()
        {
            maze = new Maze();
            controller = new Controller();
            MoveDown moveDown = new MoveDown(maze);
            MoveUp moveUp = new MoveUp(maze);
            MoveLeft moveLeft = new MoveLeft(maze);
            MoveRight moveRight = new MoveRight(maze);

            controller.setCommand(moveLeft, 1);
            controller.setCommand(moveRight, 2);
            controller.setCommand(moveUp, 3);
            controller.setCommand(moveDown, 4);

        }

        public void start()
        {
            Console.WriteLine("\nType:\ninstructions: to view instructions\nexit: to exit game\n A = LEFT, W = UP, S = DOWN, D = RIGHT");
            Console.WriteLine(maze.getCurrentRoom().longDescription());
            bool run = true;
            while (run)
            {   

                run = terminalInputReciever();
                Console.WriteLine(maze.getCurrentRoom().longDescription());
                
                List<EnemyInterface> enemies = maze.getEnemies();
                for (int i = 0; i < enemies.Count; i++)
                {
                    if(maze.getCurrentRoom() != enemies[i].getRoom())
                    enemies[i].move();
                }
            }
        }

        private bool terminalInputReciever()
        {
            string input = Console.ReadLine().ToUpper();
            string[] inputs =  input.Split(' ');
            if(inputs[0] == "EXIT")
            {
                return false;
            }

            controller.keyPressed(inputs[0]);
            return true;
            
            
        }
    }
}
