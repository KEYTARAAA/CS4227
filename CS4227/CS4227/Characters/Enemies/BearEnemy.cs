using System;
using System.Collections.Generic;
using System.Text;
using CS4227;
using CS4227.BridgePatternEnemyMovement;
using CS4227.Visitor;



namespace CS4227.Characters.Enemies
{
    class BearEnemy: IEnemy, Visitable
    {
        public BearEnemy(string name, int startingRoomRow, int startingRoomCol, int health, int attack, string sound, MovementInterface movementType) : base(name, startingRoomRow, startingRoomCol, health, attack, sound, movementType)
        {
            this.movementType = movementType;
            this.name = name;
            this.room = room;
        }

        public BearEnemy()
        {
        }

        public void attack() { }
        public void move()
        {
            MazeRoom newRoom = movementType.move(room);
            newRoom.addEnemyToRoom(this);
            this.room.removeEnemyFromRoom(this);
            this.room = newRoom;
        }
        public override void accept(VisitorInterface visitor)
        {
            visitor.visit(this);
        }

        public double getHealth()
        {
            return this.health;
        }

        public void setHealth(double health)
        {
            this.health = health;
        }

        public void setMovementType(MovementInterface movementType)
        {
            this.movementType = movementType;
        }

        public void setRoom(MazeRoom room)
        {
            this.room = room;
        }

        public void setName(String name)
        {
            this.name = name;
        }
    }
}
