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
        Random rnd;
        List<Enemy> enemies;
        MazeRoom currentRoom;
        Dictionary<string, MazeRoom> currentExits;
        public Maze()
        {
            player = new Player("Player", 0, 0, 100, 10);
            rooms = new Room[3,3];
            enemies = new List<Enemy>();
            rnd = new Random();

            genRooms();
            printMaze();

            /*MazeRoom aRoom = new MazeRoom("a");
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
            asetExits(null, dRoom, bRoom, null);
            currentExits = aRoom.getExits();
            bsetExits(null, eRoom, cRoom, aRoom);
            csetExits(null, null, null, bRoom);
            dsetExits(aRoom, gRoom, null, null);
            esetExits(bRoom, null, fRoom, null);
            fsetExits(null, iRoom, null, eRoom);
            gsetExits(dRoom, null, null, null);
            //hsetExits(null, iRoom, null, eRoom);
            isetExits(fRoom, null, null, null);*/

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
            ClockwiseMove moveType = new ClockwiseMove();
            BearEnemy george = new BearEnemy( "George", 2, 2, 50, 2,"ROARRRRR", moveType);
            george.accept(difficulty);
            enemies.Add(george);
            NormalMove moveType2 = new NormalMove();
            SnakeEnemy wriggles = new SnakeEnemy("Wriggles", 1, 1, 5, 30,"HISSSSSS", moveType2);
            wriggles.accept(difficulty);
            enemies.Add(wriggles);
        }

        private void genRooms()
        {
            char id = 'A';
            for (int row = 0; row < rooms.GetLength(0); row++)
            {
                for (int col = 0; col < rooms.GetLength(1); col++)
                {
                    rooms[row, col] = new Room(row, col, ("Room " + id.ToString()), id.ToString());
                    id++;
                }
            }

            foreach (Room room in rooms)
            {
                randomSetExits(Direction.NORTH, room);
                randomSetExits(Direction.SOUTH, room);
                randomSetExits(Direction.EAST, room);
                randomSetExits(Direction.WEST, room);
            }

            checkConnections();
        }

        private void randomSetExits(Direction direction, Room room)
        {
            if (!room.getExit(direction) && roomExists(direction, room))
            {
                int i = rnd.Next(2);

                if (i == 0)
                {
                    setExit(room, direction, false);
                }
                else
                {
                    setExit(room, direction, true);
                }
            }
        }

        private bool roomExists(Direction direction, Room room)
        {
            if (direction == Direction.NORTH)
            {
                if (room.getRow() == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }


            if (direction == Direction.SOUTH)
            {
                if (room.getRow() == rooms.GetLength(0)-1)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }


            if (direction == Direction.EAST)
            {
                if (room.getCol() == rooms.GetLength(1) - 1)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }


            if (direction == Direction.WEST)
            {
                if (room.getCol() == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }

            return false;
        }

        private void checkConnections()
        {

            for (int row = 0; row < rooms.GetLength(0); row++)
            {
                for (int col = 0; col < rooms.GetLength(1); col++)
                {
                    if (countNeighbours(rooms[row, col]) == 0)
                    {
                        setRandomNeighbour(rooms[row,col]);
                    }
                }
            }

            for (int row = 0; row < rooms.GetLength(0); row++)
            {
                int twoNeighbours = 0;
                for (int col = 0; col < rooms.GetLength(1); col++)
                {
                    if (countNeighbours(rooms[row, col]) >= 2)
                    {
                        twoNeighbours++;
                    }
                }
                if (twoNeighbours == 0)
                {
                    setRandomNeighbour(rooms[row, rnd.Next(rooms.GetLength(1))]);
                }
            }

            int threeNeighbours = 0;
            for (int row = 0; row < rooms.GetLength(0); row++)
            {
                for (int col = 0; col < rooms.GetLength(1); col++)
                {
                    if (countNeighbours(rooms[row, col]) < 3)
                    {
                        threeNeighbours++;
                    }
                }
            }
            if (threeNeighbours == 0)
            {
                bool getTwoNeighbour = false;
                while (!getTwoNeighbour)
                {
                    Room room = rooms[rnd.Next(rooms.GetLength(0)), rnd.Next(rooms.GetLength(1))];
                    if ((room.getRow() > 0 && room.getRow() < rooms.GetLength(0)-1) && (room.getCol() > 0 && room.getCol() < rooms.GetLength(1) - 1))
                    {
                        getTwoNeighbour = true;
                        while (countNeighbours(rooms[room.getRow(), room.getCol()]) < 3)
                        {
                            setRandomNeighbour(rooms[room.getRow(), room.getCol()]);
                        }
                    }
                }
            }
        }

        private int countNeighbours(Room room)
        {
            int neighbours = 0;
            if (room.getExit(Direction.NORTH))
            {
                neighbours++;
            }
            if (room.getExit(Direction.SOUTH))
            {
                neighbours++;
            }
            if (room.getExit(Direction.EAST))
            {
                neighbours++;
            }
            if (room.getExit(Direction.WEST))
            {
                neighbours++;
            }
            return neighbours;
        }

        private void setRandomNeighbour(Room room)
        {
            List<Direction> noExit = new List<Direction>();
            if (!room.getExit(Direction.NORTH) && roomExists(Direction.NORTH, room))
            {
                noExit.Add(Direction.NORTH);
            }
            if (!room.getExit(Direction.SOUTH) && roomExists(Direction.SOUTH, room))
            {
                noExit.Add(Direction.SOUTH);
            }
            if (!room.getExit(Direction.EAST) && roomExists(Direction.EAST, room))
            {
                noExit.Add(Direction.EAST);
            }
            if (!room.getExit(Direction.WEST) && roomExists(Direction.WEST, room))
            {
                noExit.Add(Direction.WEST);
            }
            setExit(room, noExit[rnd.Next(noExit.Count)], true);
        }

        private void setExit(Room room, Direction direction, bool exit)
        {
            room.setExit(direction, exit);
            switch (direction)
            {
                case Direction.NORTH:
                    rooms[room.getRow() - 1, room.getCol()].setExit(Direction.SOUTH, exit);
                    break;
                case Direction.SOUTH:
                    rooms[room.getRow() + 1, room.getCol()].setExit(Direction.NORTH, exit);
                    break;
                case Direction.EAST:
                    rooms[room.getRow() , room.getCol() + 1].setExit(Direction.WEST, exit);
                    break;
                case Direction.WEST:
                    rooms[room.getRow() , room.getCol() - 1].setExit(Direction.EAST, exit);
                    break;
            }
        }

        public void printMaze()
        {

            for (int row = 0; row < rooms.GetLength(0); row++)
            {
                string ns = " ";
                for (int col = 0; col < rooms.GetLength(1); col++)
                {
                    Console.Write("["+rooms[row,col].getMapName()+"]");
                    if (rooms[row, col].getExit(Direction.EAST))
                    {
                        Console.Write("---");
                    }
                    else
                    {
                        Console.Write("   ");
                    }
                    if (rooms[row, col].getExit(Direction.SOUTH))
                    {
                        ns += "|     ";
                    }
                    else
                    {
                        ns += "      ";
                    }
                }
                    Console.WriteLine('\n'+ ns);
            }
        }

        public void moveAll()
        {

        }

        public void movePlayer(Direction direction)
        {
            if (roomExists(direction, rooms[player.getRoomRow(), player.getRoomCol()]))
            {
                player.move(direction);
            }
        }

        public void moveEnemies()
        {
            foreach (Enemy enemy in enemies)
            {
                if ( ! ( ( enemy.getRoomRow() == player.getRoomRow() ) && ( enemy.getRoomCol() == player.getRoomCol() ) ) ) 
                {
                    enemy.move(rooms[enemy.getRoomRow(), enemy.getRoomCol()].getExits());
                }
            }
        }

        public void setRoom(MazeRoom room)
        {
            this.currentRoom = room;
        }

        public List<Enemy> getEnemies()
        {
            return this.enemies;
        }

        

       

        public void refresh()
        {

            Console.WriteLine(getCurrentRoom().getLongDescription());
            foreach (Enemy e in enemies)
            {
                if (rooms[e.getRoomRow(), e.getRoomCol()] == getCurrentRoom())
                {
                    Console.WriteLine(e.getType()+ " " + e.getName());
                    e.speak();
                }
            }
        }

        public Player getPlayer()
        {
            return this.player;
        }

        public Room getCurrentRoom()
        {
            return rooms[player.getRoomRow(), player.getRoomCol()];
        }

    }
}
