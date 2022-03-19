using System;
using System.Collections.Generic;
using CS4227.Characters.Enemies;

using System.Text;

namespace CS4227.Visitor
{
    class HardMode : VisitorInterface
    {
        public void visit(BearEnemy bearEnemy)
        {
            bearEnemy.setHealth(bearEnemy.getHealth() * 1.5);

        }

        public void visit(SnakeEnemy snakeEnemy)
        {
            snakeEnemy.setHealth(snakeEnemy.getHealth() * 1.5);
        }
    }
}
