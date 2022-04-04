using System;
using System.Collections.Generic;
using CS4227.Characters.Enemies;
using CS4227.Characters;


using System.Text;

namespace CS4227.Visitor
{
    class SetDifficultyHardVisitor : VisitorInterface
    {
        public void visit(BearEnemy bearEnemy)
        {
            bearEnemy.setHealth((int)(bearEnemy.getHealth() * 1.5));
            bearEnemy.setAttack((int)(bearEnemy.getHealth() * 1.5));
            Console.WriteLine("***Visitor Pattern: Set Difficulty Visitor is called***");



        }

        public void visit(SnakeEnemy snakeEnemy)
        {
            snakeEnemy.setHealth((int)(snakeEnemy.getHealth() * 1.5));
            snakeEnemy.setAttack((int)(snakeEnemy.getHealth() * 1.5));
            Console.WriteLine("***Visitor Pattern: Set Difficulty Visitor is called***");


        }

        public void visit(Player player)
        {
            player.setHealth((int)(player.getHealth() * .75));
            player.setAttack((int)(player.getHealth() * .75));
            Console.WriteLine("***Visitor Pattern: Set Difficulty Visitor is called***");

        }
    }
}
