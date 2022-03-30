using CS4227.Characters;
using CS4227.Constructs;
using System;
using System.Collections.Generic;
using System.Text;

namespace CS4227.Commands
{
    class Move: Command
    {
        Maze maze;
        Direction direction;

        public Move(Maze maze, Direction direction)
        {
            this.maze = maze;
            this.direction = direction;
        }

        public void execute()
        {
            maze.movePlayer(direction);
            maze.moveEnemies();
        }
    }
}
