using CS4227.Characters;
using CS4227.Characters.Enemies;
using CS4227.Visitor;

using CS4227.BridgePatternEnemyMovement;
using System;
using System.Collections.Generic;
using System.Text;

namespace CS4227.Constructs
{
    class Maze
    {
        Player player;
        Room[,] rooms;
        List<EnemyInterface> enemies;
        MazeRoom currentRoom;
        Dictionary<string, MazeRoom> currentExits;
        public Maze()
        {
            player = new Player("Player", 0, 0, 100, 10);
            rooms = new Room[3,3];
            enemies = new List<EnemyInterface>();
            

            MazeRoom aRoom = new MazeRoom("a");
            currentRoom = aRoom;
            MazeRoom bRoom = new MazeRoom("b");
            MazeRoom cRoom = new MazeRoom("c");
            MazeRoom dRoom = new MazeRoom("d");
            MazeRoom eRoom = new MazeRoom("e");
            MazeRoom fRoom = new MazeRoom("f");
            MazeRoom gRoom = new MazeRoom("g");
            MazeRoom hRoom = new MazeRoom("h");
            MazeRoom iRoom = new MazeRoom("i");
            MazeRoom jRoom = new MazeRoom("j");
            // N, S, E, W
            aRoom.setExits(null, dRoom, bRoom, null);
            currentExits = aRoom.getExits();
            bRoom.setExits(null, eRoom, cRoom, aRoom);
            cRoom.setExits(null, null, null, bRoom);
            dRoom.setExits(aRoom, gRoom, null, null);
            eRoom.setExits(bRoom, null, fRoom, null);
            fRoom.setExits(null, iRoom, null, eRoom);
            gRoom.setExits(dRoom, null, null, null);
            //hRoom.setExits(null, iRoom, null, eRoom);
            iRoom.setExits(fRoom, null, null, null);

            Console.WriteLine("Type E for Easy or H for Hard");
            string input = Console.ReadLine().ToUpper();
            string[] inputs = input.Split(' ');
            while(inputs[0] != "E" & inputs[0] != "H")
            {
                Console.WriteLine("Invalid Choice! Please type E for Easy or H for Hard");
                input = Console.ReadLine().ToUpper();
                inputs = input.Split(' ');
            }
            VisitorInterface difficulty;
            if(inputs[0] == "E")
            {
                difficulty = new EasyMode();
            }
            else
            {
                 difficulty = new HardMode();
            }
            BlindMove moveType = new BlindMove();
            BearEnemy george = new BearEnemy(moveType, "George", iRoom);
            george.accept(difficulty);
            enemies.Add(george);
            iRoom.addEnemyToRoom(george);
            NormalMove moveType2 = new NormalMove();
            SnakeEnemy wriggles = new SnakeEnemy(moveType2, "Wriggles", dRoom);
            wriggles.accept(difficulty);
            enemies.Add(wriggles);
            iRoom.addEnemyToRoom(wriggles);
        }

        public void movePlayer(Direction direction)
        {
            player.move(direction);
        }

        public void moveAll()
        {

        }

        public void moveLeft()
        {
            if(currentExits["west"] != null)
            {
                setRoom(currentExits["west"]);
                currentExits = currentExits["west"].getExits();
            }
        }

        public void moveRight()
        {
            if (currentExits["east"] != null)
            {
                setRoom(currentExits["east"]);
                currentExits = currentExits["east"].getExits();
            }
        }
        public void moveUp()
        {
            if (currentExits["north"] != null)
            {
                setRoom(currentExits["north"]);
                currentExits = currentExits["north"].getExits();
            }
        }

        public void moveDown()
        {
            if (currentExits["south"] != null)
            {
                setRoom(currentExits["south"]);
                currentExits = currentExits["south"].getExits();

            }
        }

        public void setRoom(MazeRoom room)
        {
            this.currentRoom = room;
        }

        public List<EnemyInterface> getEnemies()
        {
            return this.enemies;
        }

        

       

        public void refresh()
        {

        }

        public Player getPlayer()
        {
            return this.player;
        }

        public MazeRoom getCurrentRoom()
        {
            return this.currentRoom;
        }

    }
}
