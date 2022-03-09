using CS4227.Characters;
using CS4227.Characters.Enemies;
using System;
using System.Collections.Generic;
using System.Text;

namespace CS4227.Constructs
{
    class Maze
    {
        Player player;
        Room[,] rooms;
        List<Enemy> enemies;
        public Maze()
        {
            player = new Player("Player", 0, 0, 100, 10);
            rooms = new Room[3,3];
            enemies = new List<Enemy>();
        }

        public void movePlayer(Direction direction)
        {
            player.move(direction);
        }

        public void moveAll()
        {

        }

        public List<Enemy> getEnemiesInCurrentRoom()
        {
            List<Enemy> enemiesInCurentRoom = new List<Enemy>();
            int row = player.getRoomRow();
            int col = player.getRoomCol();


            foreach(Enemy e in enemies)
            {
                if(e.getRoomRow() == row && e.getRoomCol() == col)
                {
                    enemiesInCurentRoom.Add(e);
                }
            }


            return enemiesInCurentRoom;
        }

        public void EnemyAttack()
        {
            List<Enemy> enemiesInCurentRoom = getEnemiesInCurrentRoom();
            foreach(Enemy e in enemiesInCurentRoom)
            {
                player.changeHealth(-e.getAttack());
            }
        }

        public void refresh()
        {

        }

    }
}
