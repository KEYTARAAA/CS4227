using CS4227.BridgePatternEnemyMovement;
using System;
using System.Collections.Generic;
using System.Text;

namespace CS4227.Builder
{
    class Director
    {
        private IBuilder builder;

        public void setBuilder(IBuilder builder)
        {
            this.builder = builder;
        }

        public void makeBlindBearEnemy()
        {
            builder.reset();
            builder.setName("Blind Bear");
            MovementInterface moveType = new ClockwiseMove();
            builder.setMovementType(moveType);
            Random r = new Random();
            int row = r.Next(0, 3);
            int col = r.Next(0, 3);
            builder.setRoom(row, col);
            builder.setHealth(30);
            builder.setAttack(5);
            builder.setSound("Blind Roar");
        }

        public void makeNormalBearEnemy()
        {
            builder.reset();
            builder.setName("Normal Bear");
            MovementInterface moveType = new NormalMove();
            builder.setMovementType(moveType);
            Random r = new Random();
            int row = r.Next(0, 3);
            int col = r.Next(0, 3);
            builder.setRoom(row, col);
            builder.setHealth(30);
            builder.setAttack(5);
            builder.setSound("Roar");
        }

        public void makeBlindSnakeEnemy()
        {
            builder.reset();
            builder.setName("Blind Snake");
            MovementInterface moveType = new NormalMove();
            builder.setMovementType(moveType);
            Random r = new Random();
            int row = r.Next(0, 3);
            int col = r.Next(0, 3);
            builder.setRoom(row, col);
            builder.setHealth(30);
            builder.setAttack(5);
            builder.setSound("Blind Hiss");
        }

        public void makeNormalSnakeEnemy()
        {
            builder.reset();
            builder.setName("Normal Snake");
            MovementInterface moveType = new NormalMove();
            builder.setMovementType(moveType);
            Random r = new Random();
            int row = r.Next(0, 3);
            int col = r.Next(0, 3);
            builder.setRoom(row, col);
            builder.setHealth(30);
            builder.setAttack(5);
            builder.setSound("Hiss");
        }
    }
}
