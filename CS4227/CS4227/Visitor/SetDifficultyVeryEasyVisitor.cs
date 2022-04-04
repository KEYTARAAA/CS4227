using System;
using System.Collections.Generic;
using System.Text;
using CS4227.Characters.Enemies;
using CS4227.Characters;


namespace CS4227.Visitor
{
    class SetDifficultyVeryEasyVisitor : VisitorInterface
    {

        public void visit(BearEnemy bearEnemy)
        {
            bearEnemy.setHealth((int)(bearEnemy.getHealth() * .5));
            bearEnemy.setAttack((int)(bearEnemy.getHealth() * .5));
            Console.WriteLine("***VISITOR: Set Difficulty Visitor is called***");


        }

        public void visit(SnakeEnemy snakeEnemy)
        {
            snakeEnemy.setHealth((int)(snakeEnemy.getHealth() * .5));
            snakeEnemy.setAttack((int)(snakeEnemy.getHealth() * .5));
            Console.WriteLine("***VISITOR: Set Difficulty Visitor is called***");

        }

        public void visit(Player player)
        {
            player.setHealth((int)(player.getHealth() * 1.5));
            player.setAttack((int)(player.getHealth() * 1.5));
            Console.WriteLine("***VISITOR: Set Difficulty Visitor is called***");

        }
    }
}
