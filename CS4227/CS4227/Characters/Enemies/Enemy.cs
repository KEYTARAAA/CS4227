using CS4227.BridgePatternEnemyMovement;
using System;
using System.Collections.Generic;
using System.Text;

namespace CS4227.Characters.Enemies
{
    abstract class Enemy: Character
    {
        protected string sound = "", type = "ENEMY";
        MovementInterface movementType;
        public Enemy(string name, int startingRoomRow, int startingRoomCol, int health, int attack, string sound, MovementInterface movementType) : base(name, startingRoomRow, startingRoomCol, health, attack)
        {
            this.sound = sound;
            this.movementType = movementType;
        }

        public void move(List<Direction> exits)
        {
            move(movementType.move(exits));
        }

        public void speak()
        {
            Console.WriteLine(sound);
        }
        public string getType()
        {
            return type;
        }
    }
}
