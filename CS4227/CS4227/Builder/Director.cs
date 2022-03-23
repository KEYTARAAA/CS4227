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
            BlindMove moveType = new BlindMove();
            builder.setMovementType(moveType);
        }

        public void makeNormalBearEnemy()
        {
            builder.reset();
            builder.setName("Bear");
            NormalMove moveType = new NormalMove();
            builder.setMovementType(moveType);
        }
    }
}
