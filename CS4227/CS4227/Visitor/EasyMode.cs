﻿using System;
using System.Collections.Generic;
using System.Text;
using CS4227.Characters.Enemies;

namespace CS4227.Visitor
{
    class EasyMode : VisitorInterface
    {

        public void visit(BearEnemy bearEnemy)
        {
            bearEnemy.setHealth((int)(bearEnemy.getHealth() * .75));
            
        }

        public void visit(SnakeEnemy snakeEnemy)
        {
            snakeEnemy.setHealth((int)(snakeEnemy.getHealth() * .75));
        }
    }
}