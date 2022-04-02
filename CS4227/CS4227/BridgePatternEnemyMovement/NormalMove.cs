using System;
using System.Collections.Generic;
using System.Text;
using CS4227.Constructs;

namespace CS4227.BridgePatternEnemyMovement
{
    class NormalMove : MovementInterface
    {

        public Direction move(List<Direction> exits)
        {
            Random rnd = new Random();
            /*List<MazeRoom> validExits = new List<MazeRoom>();
            Dictionary<string, MazeRoom> exits = room.getExits();
            foreach (KeyValuePair<string, MazeRoom> entry in exits)
            {
                if(exits[entry.Key] != null)
                {
                    validExits.Add(exits[entry.Key]);
                }
            }

            int index = rnd.Next(validExits.Count);*/
            return exits[rnd.Next(exits.Count)];
        }
    }
}
