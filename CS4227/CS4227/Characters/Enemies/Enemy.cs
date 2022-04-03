using CS4227.BridgePatternEnemyMovement;
using CS4227.Memento;
using CS4227.Visitor;
using System;
using System.Collections.Generic;
using System.Text;

namespace CS4227.Characters.Enemies
{
    abstract class Enemy: Character, Originator
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

        override
        public string ToString()
        {
            return type + " " + name + ": Health: " + health + " Attack: " + attack;
        }
        override
        public void die()
        {
            dead = true;
            Console.WriteLine("You have defeated " + type + " "+ name);
        }


        public IMemento createMemento()
        {
            return new EnemyMemento(name, roomRow, roomCol, health, attack, type, sound, dead);
        }

        public void restore(IMemento memento)
        {
            EnemyMemento enemyMemento = memento as EnemyMemento;
            if (enemyMemento != null)
            {
                this.name = enemyMemento.getName();
                this.roomRow = enemyMemento.getRoomRow();
                this.roomCol = enemyMemento.getRoomCol();
                this.health = enemyMemento.getHealth();
                this.attack = enemyMemento.getattack();
                this.type = enemyMemento.getType();
                this.sound = enemyMemento.getSound();
                this.dead = enemyMemento.getDead();
            }
        }


        public class EnemyMemento : IMemento
        {
            string name, type, sound;
            int roomRow, roomCol, health, attack;
            bool dead;
            public EnemyMemento(string name, int roomRow, int roomCol, int health, int attack, string type, string sound, bool dead)
            {
                this.name = name;
                this.roomRow = roomRow;
                this.roomCol = roomCol;
                this.health = health;
                this.attack = attack;
                this.type = type;
                this.sound = sound;
                this.dead = dead;
            }

            public string getName()
            {
                return name;
            }
            public int getRoomRow()
            {
                return roomRow;
            }
            public int getRoomCol()
            {
                return roomCol;
            }
            public int getHealth()
            {
                return health;
            }
            public int getattack()
            {
                return attack;
            }
            public string getType()
            {
                return type;
            }
            public string getSound()
            {
                return sound;
            }
            public bool getDead()
            {
                return dead;
            }
        }
    }
}
