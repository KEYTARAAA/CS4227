using CS4227.BridgePatternEnemyMovement;
using CS4227.Characters.Enemies;
using System;
using System.Collections.Generic;
using System.Text;

namespace CS4227.Builder
{
    interface IBuilder
    {
        public void reset() { }
        public void setName(String name) { }
        public void setMovementType(MovementInterface movementType) { }
        public void setRoom(MazeRoom room) { }
    }
}
