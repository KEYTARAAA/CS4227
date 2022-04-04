using System;
using System.Collections.Generic;
using CS4227.Characters.Enemies;

using System.Text;

namespace CS4227.ContextObjects
{
    class GamePlayObject
    {

        Game game;
        public GamePlayObject(Game game)
        {
            this.game = game;
        }
        public string getPlayerName()
        {
            return game.getPlayer().getName();
        }

        public int getPlayerHealth()
        {
            return game.getPlayerHealth();
        }

        public int[] getEnemiesHealth()
        {

            return game.getEnemiesHealth();
        }

        public Boolean getDead()
        {
            return game.getDead();
        }

        

        public bool getWin()
        {
            return game.getWin();
        }

        public List<bool> getEnemies()
        {
            List<Enemy> enemies = game.getEnemies();
            List<bool> deadEnemies = new List<bool>();
            foreach(Enemy enemy in enemies)
            {
                deadEnemies.Add(enemy.getNewlyDead());
            }
            return deadEnemies;
        }

        public string getFull()
        {
            string full = game.getFull();

            return full;
        }

        public string getCommand()
        {
            return game.getLastCommand();

        }
    }
}