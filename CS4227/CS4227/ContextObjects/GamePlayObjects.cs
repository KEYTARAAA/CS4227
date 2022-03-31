using System;
using System.Collections.Generic;

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

        public string getFull()
        {
            string full = game.getFull();

            return full;
        }

        public string getCommand()
        {
            return game.getLastCommand();

        }

        public void consume_service() { }

    }
}