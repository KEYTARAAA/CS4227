using System;
using System.Collections.Generic;
using System.Text;
using CS4227;
using CS4227.BridgePatternEnemyMovement;
using CS4227.Visitor;



namespace CS4227.Characters.Enemies
{
    class BearEnemy: Enemy
    {
        public BearEnemy(string name, int startingRoomRow, int startingRoomCol, int health, int attack, string sound, MovementInterface movementType) : base(name, startingRoomRow, startingRoomCol, health, attack, sound, movementType)
        {
            this.type = "BEAR";
        }
        public override void accept(VisitorInterface visitor)
        {
            visitor.visit(this);
        }
    }
}
