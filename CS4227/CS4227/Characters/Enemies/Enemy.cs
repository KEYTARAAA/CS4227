﻿using CS4227.BridgePatternEnemyMovement;
using CS4227.Memento;
using CS4227.Visitor;
using System;
using System.Collections.Generic;
using System.Text;

namespace CS4227.Characters.Enemies
{
    abstract class Enemy : Character, Originator
    {
        protected string sound = "", type = "ENEMY", eyes ="";
        MovementInterface movementType;
        bool newlyDead;
        public Enemy(string name, int startingRoomRow, int startingRoomCol, int health, int attack, string sound, MovementInterface movementType) : base(name, startingRoomRow, startingRoomCol, health, attack)
        {
            this.sound = sound;
            this.movementType = movementType;
            newlyDead = false;
        }

        public Enemy() : base()
        {

        }

        public void move(List<Direction> exits)
        {
            move(movementType.move(exits));
        }

        public void speak()
        {
            Console.WriteLine(sound);
        }
        abstract public string getPortrait();

        public void setNewlyDead(bool newlyDead)
        {
            this.newlyDead = newlyDead;
        }
        public bool getNewlyDead()
        {
            bool tempNewlyDead = newlyDead;
            newlyDead = false;
            return tempNewlyDead;
        }

        public string getType()
        {
            return type;
        }

        override
        public string ToString()
        {
            return name + ": Health: " + health + " Attack: " + attack;
        }

        override
        public void die()
        {
            dead = true;
            newlyDead = true;
            Console.WriteLine("You have defeated " + type + " " + name);
        }


        public IMemento createMemento()
        {
            Console.WriteLine("***MEMENTO: Making Enemy Memento for " + type + " "  +name + "***");
            return new EnemyMemento(name, roomRow, roomCol, health, attack, type, sound, dead);
        }

        public void restore(IMemento memento)
        {
            Console.WriteLine("***MEMENTO: Restoring Enemy Memento for " + type + " " + name + "***");
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

        public void setMovementType(MovementInterface movementType)
        {
            this.movementType = movementType;
        }

        public void setEyes(string eyes)
        {
            this.eyes = eyes;
        }

        public void setSound(string sound)
        {
            this.sound = sound;
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
