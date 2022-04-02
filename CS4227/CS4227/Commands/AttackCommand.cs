using CS4227.Constructs;
using System;
using System.Collections.Generic;
using System.Text;

namespace CS4227.Commands
{
    class AttackCommand : Command
    {
        Maze maze;
        public AttackCommand(Maze maze)
        {
            this.maze = maze;
        }
        public void execute()
        {
            maze.playerAttack();
            
        }

        public string getType()
        {
            return "Attack";
        }
    }
}
