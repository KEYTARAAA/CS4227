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
        MovementInterface movementType;
        string name;
        MazeRoom room;
        double health = 100;
        public BearEnemy(MovementInterface movementType, string name, MazeRoom room)
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

        public string roar()
        {
           return "ROARRRRRRRR";
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
