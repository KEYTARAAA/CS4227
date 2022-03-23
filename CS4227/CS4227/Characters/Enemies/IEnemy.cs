using CS4227.BridgePatternEnemyMovement;
using System;
using System.Collections.Generic;
using System.Text;


namespace CS4227.Characters.Enemies
{
    interface IEnemy
    {
        
        public void attack() { }
        public void move() { }

        public string roar() { return ""; }
        public MazeRoom getRoom() { return null; }

    }
}
