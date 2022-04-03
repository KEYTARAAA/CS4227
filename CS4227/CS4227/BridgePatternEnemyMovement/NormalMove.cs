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
            
            return exits[rnd.Next(exits.Count)];
        }
    }
}
