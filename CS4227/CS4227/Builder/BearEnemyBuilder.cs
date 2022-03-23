using CS4227.BridgePatternEnemyMovement;
using CS4227.Characters.Enemies;
using System;
using System.Collections.Generic;
using System.Text;

namespace CS4227.Builder
{
    class BearEnemyBuilder : IBuilder
    {
        private BearEnemy enemy;
        private MazeRoom room;
        
        public BearEnemyBuilder(MazeRoom room)
        {
            this.room = room;
            reset();
        }

        public void reset() {
            this.enemy = new BearEnemy();
            enemy.setRoom(room);
        }

        public void setName(String name) {
            enemy.setName(name);
        }

        public void setMovementType(MovementInterface movementType) {
            enemy.setMovementType(movementType);
        }

        public void setRoom(MazeRoom room) {
            enemy.setRoom(room);
        }

        public BearEnemy getResult()
        {
            return enemy;
        }
    }
}
