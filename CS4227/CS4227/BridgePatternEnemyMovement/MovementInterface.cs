using System;
using System.Collections.Generic;
using System.Text;
using CS4227;
using CS4227.Constructs;

namespace CS4227.BridgePatternEnemyMovement
{
    interface MovementInterface
    {

        public MazeRoom move(MazeRoom room) { return room; }
    }

    
}
