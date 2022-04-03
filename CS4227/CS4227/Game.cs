using CS4227.Commands;
using CS4227.Characters.Enemies;
using CS4227.Constructs;
using System;
using System.Collections.Generic;
using CS4227.Interceptors;
using CS4227.ContextObjects;

using CS4227.Characters;

using CS4227.Dispatchers;
using CS4227.Facade;

namespace CS4227
{
    class Game
    {
        MazeFacade maze;
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
            Command emptyCommand = new EmptyCommand();
            Command moveSouthCommand = new MoveSouthCommand(maze);
            Command moveNorthCommand = new MoveNorthCommand(maze);
            Command moveWestCommand = new MoveWestCommand(maze);
            Command moveEastCommand = new MoveEastCommand(maze);
            Command attackCommand = new AttackCommand(maze);
            Command mapCommand = new MapCommand(maze);
            Command instructionCommand = new InstructionsCommand();
            Command pickUpCommand = new PickUpCommand(maze);
            Command inventoryCommand = new InventoryCommand(maze);
            Command undoCommand = new UndoCommand(maze);
            Command restartCommand = new RestartCommand(maze);
            Command exitCommand = new ExitCommand();
            controller.setCommand(emptyCommand, 0);
            controller.setCommand(moveWestCommand, 1);
            controller.setCommand(moveEastCommand, 2);
            controller.setCommand(moveNorthCommand, 3);
            controller.setCommand(moveSouthCommand, 4);
            controller.setCommand(attackCommand, 5);
            controller.setCommand(mapCommand, 6);
            controller.setCommand(instructionCommand, 7);
            controller.setCommand(pickUpCommand, 8);
            controller.setCommand(inventoryCommand, 9);
            controller.setCommand(undoCommand, 10);
            controller.setCommand(restartCommand, 11);
            controller.setCommand(exitCommand, 12);


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

        private bool terminalInputReciever()
        {
            string input = Console.ReadLine().ToUpper();
            string[] inputs = input.Split(' ');

            controller.keyPressed(inputs[0]);
            game_event();

            return true;

        }
    }
}
