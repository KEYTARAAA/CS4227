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
using CS4227.Facade;
using CS4227.Adapter;

namespace CS4227.Constructs
{
    class Maze : Caretaker, MazeFacade
    {
        Player player;
        Room[,] rooms;
        Random rnd;
        List<Enemy> enemies;
        List<Item> items;

        List<IMemento> playerMementos;
        List<List<IMemento>> enemyMementos;
        List<List<IMemento>> itemMementos;
        bool won, lost;


        VisitorInterface difficulty;
        VisitorInterface introduction;

        int undos = 5;
        public Maze()
        {
            makeMaze();
        }

        private void makeMaze()
        {
            player = new Player("Player", 0, 0, 100, 10);
            rooms = new Room[3, 3];
            enemies = new List<Enemy>();
            items = new List<Item>();
            enemies = new List<Enemy>();
            playerMementos = new List<IMemento>();
            enemyMementos = new List<List<IMemento>>();
            itemMementos = new List<List<IMemento>>();
            rnd = new Random();
            won = false;
            lost = false;

            genRooms();

            introduction = new IntroductionVisitor();

            Console.WriteLine("Type 1 for Super Easy, 2 for Easy, 3 for Hard, 4 for Impossible");
            string input = Console.ReadLine().ToUpper();
            string[] inputs = input.Split(' ');
            while(inputs[0] != "1" & inputs[0] != "2" & inputs[0] != "3" & inputs[0] != "4")
            {
                Console.WriteLine("Invalid Choice! Please type E for Easy or H for Hard");
                input = Console.ReadLine().ToUpper();
                inputs = input.Split(' ');
            }
            if(inputs[0] == "1")
            {
                difficulty = new SetDifficultyVeryEasyVisitor();
            }
            else if(inputs[0] == "2")
            {
                 difficulty = new SetDifficultyEasyVisitor();
            }
            else if (inputs[0] == "3")
            {
                difficulty = new SetDifficultyHardVisitor();
            }
            else
            {
                difficulty = new SetDifficultyImpossibleVisitor();
            }

            printMaze();

            List<Character> characters = new List<Character>();
            characters.Add(player);

            Director director = new Director();
            BearEnemyBuilder bearBuilder = new BearEnemyBuilder();

            director.setBuilder(bearBuilder);

            director.makeBlindBearEnemy();
            BearEnemy bear1 = bearBuilder.getResult();
            makeEnemy(bear1);
            bearBuilder.reset();

            characters.Add(bear1);

            director.makeNormalBearEnemy();
            BearEnemy bear2 = bearBuilder.getResult();
            makeEnemy(bear2);
            bearBuilder.reset();

            characters.Add(bear2);


            SnakeEnemyBuilder snakeBuilder = new SnakeEnemyBuilder();
            snakeBuilder = new SnakeEnemyBuilder();

            director.setBuilder(snakeBuilder);

            director.makeBlindSnakeEnemy();
            SnakeEnemy snake2 = snakeBuilder.getResult();
            makeEnemy(snake2);
            snakeBuilder.reset();

            characters.Add(snake2);

            director.makeNormalSnakeEnemy();
            SnakeEnemy snake1 = snakeBuilder.getResult();
            makeEnemy(snake1);
            snakeBuilder.reset();

            characters.Add(snake1);


            

            foreach(Character character in characters)
            {
                character.accept(introduction);
            }


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
            rooms[0, 0].setExit(Direction.NORTH, true);
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

        public Room[,] getMaze()
        {
            return rooms;
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
            if (rooms[player.getRoomRow(), player.getRoomCol()].getExit(Direction.SOUTH))
            {
                player.move(Direction.SOUTH);
            }
            moveEnemies();
        }

        public void movePlayerNorth()
        {
            makeMementos();
            
            if (getCurrentRoom().getMapName() == "A" && !player.getDead())
            {
                if (player.checkInventory("KEY"))
                {
                    win();
                }
                else
                {
                    Console.WriteLine("\nRoom is locked!\nFind Key To open.");
                }
            }
            else if (rooms[player.getRoomRow(), player.getRoomCol()].getExit(Direction.NORTH))
            {
                player.move(Direction.NORTH);
            }
            moveEnemies();
        }

        public void movePlayerEast()
        {
            makeMementos();
            if (rooms[player.getRoomRow(), player.getRoomCol()].getExit(Direction.EAST))
            {
                player.move(Direction.EAST);
            }
            moveEnemies();
        }

        public void movePlayerWest()
        {
            makeMementos();
            if (rooms[player.getRoomRow(), player.getRoomCol()].getExit(Direction.WEST))
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
                if (((enemy.getRoomRow() == player.getRoomRow()) && (enemy.getRoomCol() == player.getRoomCol())) && !enemy.getDead())
                {
                        enemy.attackOther(player);
                }
            }
        }

        public void playerAttack()
        {
            makeMementos();
            foreach (Enemy enemy in enemies)
            {
                if (((enemy.getRoomRow() == player.getRoomRow()) && (enemy.getRoomCol() == player.getRoomCol())) && !enemy.getDead())
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

        public List<Enemy> getEnemies()
        {
            return this.enemies;
        }
       

        public void refresh()
        {
            if (player.getDead())
            {
                lose();
            }
            if (!won && !lost) {
                Console.WriteLine("\n" + getCurrentRoom().getLongDescription());
                Console.WriteLine(player.ToString());
                InfoAdapter infoAdapter;
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
                        infoAdapter = new InfoAdapter(i);
                        Console.WriteLine(infoAdapter.getInfo());
                    }
                }

                foreach (Enemy e in enemies)
                {
                    if (rooms[e.getRoomRow(), e.getRoomCol()] == getCurrentRoom() && (!e.getDead()))
                    {
                        Console.WriteLine("\n" + e.ToString());
                        infoAdapter = new InfoAdapter(e);
                        Console.WriteLine(infoAdapter.getInfo());
                        e.speak();
                    }
                }
            }
            else if (won)
            {
                Console.WriteLine("\nCongratulations you won the game!\nType R to restart");
            } 
            else if (lost)
            {
                Console.WriteLine("\n\nYou have died.\n\nGAME OVER.\n\nType R to restart");
            }
        }

        public bool getWin()
        {
            return won;
        }

        public bool getLoss()
        {
            return lost;
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

        void win()
        {
            won = true;
        }

        void lose()
        {
            lost = true;
        }

        public void restart()
        {
            makeMaze();
        }
    }
}
