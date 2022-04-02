using System;
using System.Collections.Generic;
using System.Text;
using CS4227.BridgePatternEnemyMovement;
using CS4227.Visitor;



namespace CS4227.Characters.Enemies
{
    class SnakeEnemy : Enemy
    {

        public SnakeEnemy()
        {
            this.type = "SNAKE";
        }

        public override void accept(VisitorInterface visitor)
        {
            visitor.visit(this);
        }
    }
}
