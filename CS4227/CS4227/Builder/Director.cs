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
            builder.setName("Bear");
            MovementInterface moveType = new ClockwiseMove();
            builder.setMovementType(moveType);
            Random r = new Random();
            int row = r.Next(0, 3);
            int col = r.Next(0, 3);
            Console.WriteLine("row: " + row.ToString() + " col: " + col.ToString());
            builder.setRoom(row, col);
            builder.setHealth(30);
            builder.setAttack(5);
            builder.setSound("Roar");
        }

        public void makeNormalBearEnemy()
        {
            builder.reset();
            builder.setName("Bear");
            MovementInterface moveType = new NormalMove();
            builder.setMovementType(moveType);
            Random r = new Random();
            int row = r.Next(0, 3);
            int col = r.Next(0, 3);
            Console.WriteLine("row: " + row.ToString() + " col: " + col.ToString());
            builder.setRoom(row, col);
            builder.setHealth(30);
            builder.setAttack(5);
            builder.setSound("Roar");
        }
    }
}
