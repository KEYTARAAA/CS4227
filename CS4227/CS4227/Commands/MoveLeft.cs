using System;
using System.Collections.Generic;
using System.Text;
using CS4227.Constructs;


namespace CS4227.Commands
{
    class MoveLeft : Command
    {
        Maze maze;

        public MoveLeft(Maze maze)
        {
            this.maze = maze;
        }

        public void execute()
        {
            maze.movePlayerWest();
        }
        public void undo() { }

        public string getType()
        {
            return "MoveLeft";
        }
    }
}