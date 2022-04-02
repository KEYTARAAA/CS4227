using CS4227.Characters;
using CS4227.Characters.Enemies;
using CS4227.Visitor;

using CS4227.BridgePatternEnemyMovement;
using System;
using System.Collections.Generic;
using System.Text;
using CS4227.Characters.Items;
using CS4227.Memento;
using CS4227.Builder;

namespace CS4227.Constructs
{
    class Maze : Caretaker
    {
        Player player;
        Room[,] rooms;
        Random rnd;
        List<Enemy> enemies;
        List<Item> items;
        MazeRoom currentRoom;
        Dictionary<string, MazeRoom> currentExits;

        List<IMemento> playerMementos;
        List<List<IMemento>> enemyMementos;
        List<List<IMemento>> itemMementos;


        VisitorInterface difficulty;

        int undos = 5;
        public Maze()
        {
            player = new Player("Player", 0, 0, 100, 10);
            rooms = new Room[3,3];
            enemies = new List<Enemy>();
            items = new List<Item>();
            enemies = new List<Enemy>();
            playerMementos = new List<IMemento>();
            enemyMementos = new List<List<IMemento>>();
            itemMementos = new List<List<IMemento>>();
            rnd = new Random();

            genRooms();

            Console.WriteLine("Type E for Easy or H for Hard");
            string input = Console.ReadLine().ToUpper();
            string[] inputs = input.Split(' ');
            while(inputs[0] != "E" & inputs[0] != "H")
            {
                Console.WriteLine("Invalid Choice! Please type E for Easy or H for Hard");
                input = Console.ReadLine().ToUpper();
                inputs = input.Split(' ');
            }
            if(inputs[0] == "E")
            {
                difficulty = new EasyMode();
            }
            else
            {
                 difficulty = new HardMode();
            }

            printMaze();

            Director director = new Director();
            BearEnemyBuilder builder = new BearEnemyBuilder();

            director.setBuilder(builder);

            director.makeBlindBearEnemy();
            BearEnemy bear1 = builder.getResult();
            makeEnemy(bear1);
            builder.reset();

            director.makeNormalBearEnemy();
            BearEnemy bear2 = builder.getResult();
            makeEnemy(bear2);
            builder.reset();


            makeItem(new Item("Key"));
            makeItem(new StatChangingItem("Sword", (new Dictionary<STAT, int>() { [STAT.ATTACK] = 10 })));
            placeItems();
        }

        private void makeEnemy(Enemy e)
        {
            e.accept(difficulty);
            enemies.Add(e);
            enemyMementos.Add(new List<IMemento>());
        }
        private void makeItem(Item i)
        {
            items.Add(i);
            itemMementos.Add(new List<IMemento>());
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
            //Algorthm to fully connect maze


            //STEP 1: all rooms have at least 1 neighbour
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

            //STEP 2: 1 room per rouw connects to next row
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

            //STEP 3: 1 room maze has 3 neighbours
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

            finalCheck();
        }

        void finalCheck()
        {
            foreach (Room r in rooms)
            {
                if (countNeighbours(r) == 1)
                {
                    List<Direction> exits = r.getExits();

                    foreach (Direction d in exits)
                    {
                        int row = r.getRow();
                        int col = r.getCol();

                        switch (d)
                        {
                            case Direction.NORTH:
                                row--;
                                break;
                            case Direction.SOUTH:
                                row++;
                                break;
                            case Direction.EAST:
                                col++;
                                break;
                            case Direction.WEST:
                                col--;
                                break;
                        }

                        if (countNeighbours(rooms[row, col]) == 1)
                        {
                            setRandomNeighbour(rooms[row, col]);
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

        private void placeItems()
        {
            foreach (Item item in items)
            {
                item.setRoom(rnd.Next(rooms.GetLength(0)), rnd.Next(rooms.GetLength(0)));
            }
        }
        public void movePlayerSouth()
        {
            makeMementos();
            if (roomExists(Direction.SOUTH, rooms[player.getRoomRow(), player.getRoomCol()]))
            {
                player.move(Direction.SOUTH);
            }
            moveEnemies();
        }

        public void movePlayerNorth()
        {
            makeMementos();
            if (roomExists(Direction.NORTH, rooms[player.getRoomRow(), player.getRoomCol()]))
            {
                player.move(Direction.NORTH);
            }
            moveEnemies();
        }

        public void movePlayerEast()
        {
            makeMementos();
            if (roomExists(Direction.EAST, rooms[player.getRoomRow(), player.getRoomCol()]))
            {
                player.move(Direction.EAST);
            }
            moveEnemies();
        }

        public void movePlayerWest()
        {
            makeMementos();
            if (roomExists(Direction.WEST, rooms[player.getRoomRow(), player.getRoomCol()]))
            {
                player.move(Direction.WEST);
            }
            moveEnemies();
        }

        public void moveEnemies()
        {
            foreach (Enemy enemy in enemies)
            {
                if (!((enemy.getRoomRow() == player.getRoomRow()) && (enemy.getRoomCol() == player.getRoomCol())))
                {
                    enemy.move(rooms[enemy.getRoomRow(), enemy.getRoomCol()].getExits());
                }
            }
            enemiesAttack();
        }

        public void enemiesAttack()
        {
            foreach (Enemy enemy in enemies)
            {
                if (((enemy.getRoomRow() == player.getRoomRow()) && (enemy.getRoomCol() == player.getRoomCol())))
                {
                    if (!enemy.getDead()) {
                        enemy.attackOther(player);
                    }
                }
            }
        }

        public void playerAttack()
        {
            makeMementos();
            foreach (Enemy enemy in enemies)
            {
                if (((enemy.getRoomRow() == player.getRoomRow()) && (enemy.getRoomCol() == player.getRoomCol())))
                {
                    player.attackOther(enemy);
                }
            }
            moveEnemies();
        }

        public void playerInventory()
        {
            player.printInventory();
        }

        public void playerPickUp()
        {
            makeMementos();
            foreach (Item item in items)
            {
                if (rooms[item.getRoomRow(), item.getRoomCol()] == getCurrentRoom() && item.getActive())
                {
                    player.addInventory(item);
                    item.setActive(false);
                }
            }
            moveEnemies();
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
            Console.WriteLine("\n" + getCurrentRoom().getLongDescription());
            Console.WriteLine(player.ToString());
            bool first = true;
            foreach (Item i in items)
            {
                if (rooms[i.getRoomRow(), i.getRoomCol()] == getCurrentRoom() && i.getActive())
                {
                    if (first)
                    {
                        Console.WriteLine("\nItems:");
                        first = false;
                    }
                    Console.WriteLine(i.getName());
                }
            }

            foreach (Enemy e in enemies)
            {
                if (rooms[e.getRoomRow(), e.getRoomCol()] == getCurrentRoom() && (!e.getDead()))
                {
                    Console.WriteLine("\n" + e.ToString());
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

        public string getFull()
        {
            string full = getPlayer().getHealth().ToString() + ",";
            foreach (Enemy enemy in enemies)
            {
                full += enemy.getName() + "," + enemy.getHealth().ToString() + ",";
            }
            full = full.Remove(full.Length - 1, 1);
            return full;
        }

        public void makeMementos()
        {
            mementoObject(player, playerMementos);

            for (int i = 0; i < enemies.Count; i++)
            {
                mementoObject(enemies[i], enemyMementos[i]);
            }
            for (int i = 0; i < items.Count; i++)
            {
                mementoObject(items[i], itemMementos[i]);
            }
        }
        void mementoObject(Originator o, List<IMemento> mementos)
        {
            while (mementos.Count >= undos)
            {
                mementos.RemoveAt(0);
            }
            mementos.Add(o.createMemento());
        }

        public void undo()
        {
            if (playerMementos.Count <= undos)
            {
                undoObject(player, playerMementos);

                for (int i = 0; i < enemies.Count; i++)
                {
                    undoObject(enemies[i], enemyMementos[i]);
                }
                for (int i = 0; i < items.Count; i++)
                {
                    undoObject(items[i], itemMementos[i]);
                }
            }
            else
            {
                Console.WriteLine("\nNo undos left!");
            }
        }

        void undoObject(Originator o, List<IMemento> mementos)
        {
            if (mementos.Count > 0)
            {
                o.restore(mementos[mementos.Count-1]);
                mementos.Remove(mementos[mementos.Count - 1]);
            }
        }
    }
}
