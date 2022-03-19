using System;
using System.Collections.Generic;
using System.Text;
using CS4227.Characters.Enemies;


namespace CS4227.Visitor
{
    interface VisitorInterface
    {

        public void visit(BearEnemy bearEnemy);
        public void visit(SnakeEnemy snakeEnemy);
    }
}
