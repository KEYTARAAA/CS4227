using CS4227.Constructs;
using CS4227.Facade;
using System;
using System.Collections.Generic;
using System.Text;

namespace CS4227.Commands
{
    class AttackCommand : Command
    {
        MazeFacade maze;
        public AttackCommand(MazeFacade maze)
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
