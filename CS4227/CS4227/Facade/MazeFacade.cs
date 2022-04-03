using CS4227.Characters;
using CS4227.Characters.Enemies;
using System;
using System.Collections.Generic;
using System.Text;

namespace CS4227.Facade
{
    interface MazeFacade
    {
        public void refresh();
        public Player getPlayer();
        public List<Enemy> getEnemies();

        public string getFull();
        public void playerAttack();
        public void playerInventory();
        public void printMaze();
        public void movePlayerNorth();
        public void movePlayerSouth();
        public void movePlayerEast();
        public void movePlayerWest();
        public void playerPickUp();
        public void undo();
        public void restart();
    }
}
