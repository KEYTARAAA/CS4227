using System;
using System.Collections.Generic;
using System.Text;
using CS4227.Characters.Enemies;
using CS4227.Characters;


namespace CS4227.Visitor
{
    class IntroductionVisitor : VisitorInterface
    {

        public void visit(BearEnemy bearEnemy)
        {
            Console.WriteLine("Hello, I'm " + bearEnemy.getName() + ", I have " + bearEnemy.getHealth() + " health and I have " + bearEnemy.getAttack() + " attack");
            Console.WriteLine("***Visitor Pattern: Introduction Visitor is called***");

        }

        public void visit(SnakeEnemy snakeEnemy)
        {
            Console.WriteLine("Hello, I'm " + snakeEnemy.getName() + ", I have " + snakeEnemy.getHealth() + " health and I have " + snakeEnemy.getAttack() + " attack");
            Console.WriteLine("***Visitor Pattern: Introduction Visitor is called***");


        }

        public void visit(Player player)
        {
            Console.WriteLine("Hello, I'm " + player.getName() + ", I have " + player.getHealth() + " health and I have " + player.getAttack() + " attack");
            Console.WriteLine("***Visitor Pattern: Introduction Visitor is called***");


        }
    }
}
