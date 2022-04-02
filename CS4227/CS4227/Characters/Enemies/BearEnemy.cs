using System;
using System.Collections.Generic;
using System.Text;
using CS4227;
using CS4227.BridgePatternEnemyMovement;
using CS4227.Visitor;



namespace CS4227.Characters.Enemies
{
    class BearEnemy: Enemy, Visitable
    {
        public BearEnemy()
        {
               this.type = "BEAR";
        }

        public override void accept(VisitorInterface visitor)
        {
            visitor.visit(this);
        }

    }
}
