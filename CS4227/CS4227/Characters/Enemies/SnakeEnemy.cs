using System;
using System.Collections.Generic;
using System.Text;
using CS4227.BridgePatternEnemyMovement;
using CS4227.Visitor;



namespace CS4227.Characters.Enemies
{
    class SnakeEnemy : Enemy, Visitable
    {

        public SnakeEnemy()
        {
            this.type = "SNAKE";
            this.eyes = ".";
                            

        }

        public override void accept(VisitorInterface visitor)
        {
            visitor.visit(this);
        }

        public override string getPortrail()
        {
            return          "             ____\n" +
                            "            / " + eyes + " " + eyes + "\\\n" +
                            "            \\  ---<\n" +
                            "             \\  /\n" +
                            "   __________/ /\n" +
                            "-=:___________/\n";
        }
    }
}
