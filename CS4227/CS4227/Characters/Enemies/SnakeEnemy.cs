using System;
using System.Collections.Generic;
using System.Text;
using CS4227.BridgePatternEnemyMovement;
using CS4227.Visitor;



namespace CS4227.Characters.Enemies
{
    class SnakeEnemy : EnemyInterface
    {

        MovementInterface movementType;
        string name;
        MazeRoom room;
        double health = 100;
        public SnakeEnemy(MovementInterface movementType, string name, MazeRoom room)
        {
            this.movementType = movementType;
            this.name = name;
            this.room = room;
            room.addEnemyToRoom(this);

        }

        public void attack() { }
        public void move()
        {
            MazeRoom newRoom = movementType.move(room);
            newRoom.addEnemyToRoom(this);
            this.room.removeEnemyFromRoom(this);
            this.room = newRoom;
        }
        public string roar()
        {
            return "HISSSSSSSSSSSSSSSSS!";
        }
        public MazeRoom getRoom()
        {
            return this.room;
        }

        public void accept(VisitorInterface visitor)
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
    }
}
