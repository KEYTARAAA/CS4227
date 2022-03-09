using System;
using System.Collections.Generic;
using System.Text;

namespace CS4227.Characters.Enemies
{
    class Enemy:Character
    {
        bool attacked = false;
        public Enemy(string name, int startingRoomRow, int startingRoomCol, int health, int attack): base(name, startingRoomRow, startingRoomCol, health, attack)
        {
        }

        public override void die()
        {
            
        }
    }
}
