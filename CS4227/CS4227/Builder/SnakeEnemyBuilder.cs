using CS4227.BridgePatternEnemyMovement;
using CS4227.Characters.Enemies;
using System;
using System.Collections.Generic;
using System.Text;

namespace CS4227.Builder
{
    class SnakeEnemyBuilder : IBuilder
    {
        private SnakeEnemy enemy;

        public SnakeEnemyBuilder()
        {
            Console.WriteLine("***BUILDER: Creating new Builder class for SnakeEnemy***");
            reset();
        }

        public void reset()
        {
            this.enemy = new SnakeEnemy();
            Console.WriteLine("***BUILDER: Creating/Reseting an Empty SnakeEnemy Object**");
        }

        public void setName(String name)
        {
            enemy.setName(name);
        }

        public void setMovementType(MovementInterface movementType)
        {
            enemy.setMovementType(movementType);
        }

        public void setEyes(string eyes)
        {
            enemy.setEyes(eyes);
        }

        public void setRoom(int roomRow, int roomCol)
        {
            enemy.setRoom(roomRow, roomCol);
        }

        public void setHealth(int health)
        {
            enemy.setHealth(health);
        }

        public void setAttack(int attack)
        {
            enemy.setAttack(attack);
        }

        public void setSound(string sound)
        {
            enemy.setSound(sound);
        }

        public SnakeEnemy getResult()
        {
            Console.WriteLine("***BUILDER: Getting result for SnakeEnemy***");
            return enemy;
        }
    }
}
