﻿using System;
using System.Collections.Generic;
using System.Text;
using CS4227.Characters.Enemies;
using CS4227.Characters;


namespace CS4227.Visitor
{
    class SetDifficultyEasyVisitor : VisitorInterface
    {

        public void visit(BearEnemy bearEnemy)
        {
            bearEnemy.setHealth((int)(bearEnemy.getHealth() * .75));
            bearEnemy.setAttack((int)(bearEnemy.getHealth() * .75));

        }

        public void visit(SnakeEnemy snakeEnemy)
        {
            snakeEnemy.setHealth((int)(snakeEnemy.getHealth() * .75));
            snakeEnemy.setAttack((int)(snakeEnemy.getHealth() * .75));
        }

        public void visit(Player player)
        {
            player.setHealth((int)(player.getHealth() * 1.25));
            player.setAttack((int)(player.getHealth() * 1.25));
        }
    }
}