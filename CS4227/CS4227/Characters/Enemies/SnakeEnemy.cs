using System;
using System.Collections.Generic;
using System.Text;
using CS4227.BridgePatternEnemyMovement;
using CS4227.Visitor;



namespace CS4227.Characters.Enemies
{
    class SnakeEnemy : Enemy
    {
        public SnakeEnemy(string name, int startingRoomRow, int startingRoomCol, int health, int attack, string sound, MovementInterface movementType) : base(name, startingRoomRow, startingRoomCol, health, attack, sound, movementType)
        {
            this.type = "SNAKE";
        }

        public override void accept(VisitorInterface visitor)
        {
            visitor.visit(this);
        }
    }
}
