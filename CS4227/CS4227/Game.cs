using CS4227.Commands;
using CS4227.Characters.Enemies;
using CS4227.Constructs;
using System;
using System.Collections.Generic;
using System.Text;
using CS4227.Interceptors;
using CS4227.ContextObjects;

using CS4227.Characters.Enemies;

using CS4227.Characters;

using CS4227.Dispatchers;


namespace CS4227
{
    class Game
    {
        Maze maze;
        List<Dispatcher> dispatchers;
        Controller controller;
        int count = 0;
        public Game()
        {
            maze = new Maze();
            dispatchers = new List<Dispatcher>();
            Dispatcher dispatcher = new Dispatcher();
            GamePlayObject gameplayobject = new GamePlayObject(this);
            Interceptor gameplayinterceptor = new GamePlayInterceptor(gameplayobject);
            dispatcher.register(gameplayinterceptor);
            dispatchers.Add(dispatcher);
            //DB db = new DB();
            //db.createFile("sean");

            controller = new Controller();
            Command moveDown = new MoveDown(maze);
            Command moveUp = new MoveUp(maze);
            Command moveLeft = new MoveLeft(maze);
            Command moveRight = new MoveRight(maze);
            Command attackCommand = new Attack(maze);
            controller.setCommand(moveLeft, 1);
            controller.setCommand(moveRight, 2);
            controller.setCommand(moveUp, 3);
            controller.setCommand(moveDown, 4);
            controller.setCommand(attackCommand, 5);


        }

        public void loop()
        {
            Boolean run = true;
            Console.WriteLine(CONSTS.INSTRUCTIONS);
            while (run)
            {
                maze.refresh();
                run = terminalInputReciever();
                count += 1;
            }
        }

        public int getPlayerHealth()
        {
            return maze.getPlayer().getHealth();
        }

        public int[] getEnemiesHealth()
        {
            int i = 0;
            List<Enemy> enemies = maze.getEnemies();
            int[] enemiesHealth = new int[enemies.Count];
            foreach (Enemy enemy in enemies)
            {
                enemiesHealth[i] = enemy.getHealth();
                i = i + 1;

            }
            return enemiesHealth;
        }

        public string getLastCommand()
        {
            return controller.getLastCommand();


        }

        public Player getPlayer()
        {
            return maze.getPlayer();
        }

        public string getFull()
        {
            return maze.getFull() + "," + count.ToString() + Environment.NewLine;
        }
        public void game_event()
        {
            foreach (Dispatcher dispatcher in dispatchers)
            {
                dispatcher.dispatch();
            }
        }

        private Boolean terminalInputReciever()
        {
            string input = Console.ReadLine().ToUpper();
            string[] inputs = input.Split(' ');
            if (inputs[0] == "EXIT")
            {
                return false;
            }

            controller.keyPressed(inputs[0]);
            maze.moveEnemies();
            game_event();

            return true;

        }
    }
}