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
            this.eyes = "o";
        }

        public override void accept(VisitorInterface visitor)
        {
            visitor.visit(this);
        }

        public override string getPortrail()
        {
            return          " __         __\n" +
                            "/  \\.-" + '"' + '"' + '"' + "-./  \\" + "\n" +
                            "\\    -   -    /\n" +
                            " |   " + eyes + "   " + eyes + "   |\n" +
                            " \\  .-'''-.  /\n" +
                            "  '-\\__Y__/-'\n" +
                            "     `---`\n";
        }
    }
}
