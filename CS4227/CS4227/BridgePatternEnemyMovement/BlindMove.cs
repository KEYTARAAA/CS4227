using System;
using System.Collections.Generic;
using System.Text;
using CS4227.Constructs;

namespace CS4227.BridgePatternEnemyMovement
{
    class BlindMove : MovementInterface
    {

        public MazeRoom move(MazeRoom room)
        {
            Random rnd = new Random();
            int direction = rnd.Next(1, 4);
            Dictionary<string, MazeRoom> exits = room.getExits();
            if (direction == 1)
            {
                if (exits["north"] != null)
                {
                    
                    return exits["north"];
                }
            }
            if (direction == 2) {
                if (exits["south"] != null)
                {
                    
                    return exits["south"];
                }
            }
            if (direction == 3) {
                if (exits["east"] != null)
                {
                    
                    return exits["east"];
                }
            }
            if(direction == 4) { 
                if (exits["west"] != null)
                {
                    
                    return exits["west"];
                }
            }

            return room;
        }
    }
}
