using System;
using System.Collections.Generic;
using System.Text;
using CS4227.Constructs;


namespace CS4227.Commands
{
    class MoveRight : Command
    {
        Maze maze;

        public MoveRight(Maze maze)
        {
            this.maze = maze;
        }

        public void execute()
        {
            maze.movePlayerEast();
        }

        public void undo() { }

        public string getType()
        {
            return "MoveRight";
        }
    }
}