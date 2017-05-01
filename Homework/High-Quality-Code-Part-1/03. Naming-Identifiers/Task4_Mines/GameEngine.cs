using System;
using System.Collections.Generic;

namespace Minesweeper
{
    public class GameEngine
    {
        private const int TOTAL_CELLS = 50;
        private const int EMPTY_CELLS = 35;
        private const int MINED_CELLS = TOTAL_CELLS - EMPTY_CELLS;
        private const int MIN_COMMAND_LENGTH = 3;

        static void Main()
        {
            int clearedCells = 0;
            int row = 0;
            int col = 0;

            bool hasExploded = false;
            bool nextPlayerStarted = true;
            bool hasFinished = false;

            char[,] grid = CreateGrid();
            char[,] minefield = CreateMinefield();

            List<Player> players = new List<Player>(6);

            string currentCommand = string.Empty;

            do
            {
                if (nextPlayerStarted)
                {
                    Console.WriteLine("Hajde da igraem na “Mini4KI”. " +
                                      "Probvaj si kasmeta da otkriesh poleteta bez mini4ki." +
                                      " Komanda 'top' pokazva klasiraneto, " +
                                      "'restart' po4va nova igra, 'exit' izliza i hajde 4ao!");
                    PrintGrid(grid);
                    nextPlayerStarted = false;
                }

                Console.Write("Daj red i kolona : ");

                currentCommand = Console.ReadLine().Trim();

                if (currentCommand.Length >= MIN_COMMAND_LENGTH)
                {
                    if (int.TryParse(currentCommand[0].ToString(), out row) &&
                        int.TryParse(currentCommand[2].ToString(), out col) &&
                        (row <= grid.GetLength(0)) &&
                        (col <= grid.GetLength(1)))
                    {
                        currentCommand = "turn";
                    }
                }

                switch (currentCommand)
                {
                    case "top":
                        PrintScoreTable(players);
                        break;
                    case "restart":
                        grid = CreateGrid();
                        minefield = CreateMinefield();
                        PrintGrid(grid);
                        break;
                    case "exit":
                        Console.WriteLine("4a0, 4a0, 4a0!");
                        break;
                    case "turn":
                        if (minefield[row, col] != '*')
                        {
                            if (minefield[row, col] == '-')
                            {
                                NextTurn(grid, minefield, row, col);
                                clearedCells++;
                            }
                            if (clearedCells == EMPTY_CELLS)
                            {
                                hasFinished = true;
                            }
                            else
                            {
                                PrintGrid(grid);
                            }
                        }
                        else
                        {
                            hasExploded = true;
                        }
                        break;
                    default:
                        Console.WriteLine("\nGreshka! nevalidna Komanda\n");
                        break;
                }

                if (hasExploded)
                {
                    PrintGrid(minefield);

                    Console.Write("\nHrrrrrr! Umria gerojski s {0} to4ki. " +
                                  "Daj si niknejm: ", clearedCells);
                    string nickName = Console.ReadLine();

                    Player currentPlayer = new Player(nickName, clearedCells);

                    if (players.Count < 5)
                    {
                        players.Add(currentPlayer);
                    }
                    else
                    {
                        for (int i = 0; i < players.Count; i++)
                        {
                            if (players[i].Points < currentPlayer.Points)
                            {
                                players.Insert(i, currentPlayer);
                                players.RemoveAt(players.Count - 1);
                                break;
                            }
                        }
                    }

                    players.Sort((x, y) => y.Name.CompareTo(x.Name));
                    players.Sort((x, y) => y.Points.CompareTo(x.Points));

                    PrintScoreTable(players);

                    grid = CreateGrid();
                    minefield = CreateMinefield();
                    clearedCells = 0;
                    hasExploded = false;
                    nextPlayerStarted = true;
                }

                if (hasFinished)
                {
                    Console.WriteLine("\nBRAVOOOS! Otvri 35 kletki bez kapka kryv.");

                    PrintGrid(minefield);

                    Console.WriteLine("Daj si imeto, batka: ");

                    string nickName = Console.ReadLine();
                    Player currentPlayer = new Player(nickName, clearedCells);
                    players.Add(currentPlayer);
                    PrintScoreTable(players);

                    grid = CreateGrid();
                    minefield = CreateMinefield();

                    clearedCells = 0;
                    hasFinished = false;
                    nextPlayerStarted = true;
                }
            } while (currentCommand != "exit");

            Console.WriteLine("Made in Bulgaria - Uauahahahahaha!");
            Console.WriteLine("AREEEEEEeeeeeee.");

            Console.Read();
        }

        private static void PrintScoreTable(List<Player> players)
        {
            Console.WriteLine("\nTo4KI:");

            if (players.Count > 0)
            {
                for (int i = 0; i < players.Count; i++)
                {
                    Console.WriteLine("{0}. {1} --> {2} kutii",
                        i + 1, players[i].Name, players[i].Points);
                }

                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("prazna klasaciq!\n");
            }
        }

        private static void NextTurn(char[,] grid, char[,] minefield, int row, int col)
        {
            char minesCount = GetSurroundingMinesCount(minefield, row, col);

            grid[row, col] = minesCount;
            minefield[row, col] = minesCount;
        }

        private static void PrintGrid(char[,] grid)
        {
            int rows = grid.GetLength(0);
            int cols = grid.GetLength(1);

            Console.WriteLine("\n    0 1 2 3 4 5 6 7 8 9");
            Console.WriteLine("   ---------------------");

            for (int i = 0; i < rows; i++)
            {
                Console.Write("{0} | ", i);

                for (int j = 0; j < cols; j++)
                {
                    Console.Write("{0} ", grid[i, j]);
                }

                Console.Write("|");
                Console.WriteLine();
            }

            Console.WriteLine("   ---------------------\n");
        }

        private static char[,] CreateGrid()
        {
            int rows = 5;
            int cols = 10;
            char[,] grid = new char[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    grid[i, j] = '?';
                }
            }

            return grid;
        }

        private static char[,] CreateMinefield()
        {
            int rows = 5;
            int cols = 10;
            char[,] minefield = new char[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    minefield[i, j] = '-';
                }
            }

            List<int> minedPositions = new List<int>();

            while (minedPositions.Count < MINED_CELLS)
            {
                Random random = new Random();
                int nextMinedPosition = random.Next(TOTAL_CELLS);

                if (!minedPositions.Contains(nextMinedPosition))
                {
                    minedPositions.Add(nextMinedPosition);
                }
            }

            foreach (int position in minedPositions)
            {
                int row = position % cols;
                int col = position / cols;

                if (row == 0 && position != 0)
                {
                    col--;
                    row = cols;
                }
                else
                {
                    row++;
                }

                minefield[col, row - 1] = '*';
            }

            return minefield;
        }

        // Unused method
        /*private static void smetki(char[,] pole)
        {
            int kol = pole.GetLength(0);
            int red = pole.GetLength(1);

            for (int i = 0; i < kol; i++)
            {
                for (int j = 0; j < red; j++)
                {
                    if (pole[i, j] != '*')
                    {
                        char kolkoo = GetSurroundingMinesCount(pole, i, j);
                        pole[i, j] = kolkoo;
                    }
                }
            }
        }*/

        private static char GetSurroundingMinesCount(char[,] mines, int row, int col)
        {
            int count = 0;
            int rows = mines.GetLength(0);
            int cols = mines.GetLength(1);

            if (row - 1 >= 0)
            {
                if (mines[row - 1, col] == '*')
                {
                    count++;
                }
            }

            if (row + 1 < rows)
            {
                if (mines[row + 1, col] == '*')
                {
                    count++;
                }
            }

            if (col - 1 >= 0)
            {
                if (mines[row, col - 1] == '*')
                {
                    count++;
                }
            }

            if (col + 1 < cols)
            {
                if (mines[row, col + 1] == '*')
                {
                    count++;
                }
            }

            if ((row - 1 >= 0) && (col - 1 >= 0))
            {
                if (mines[row - 1, col - 1] == '*')
                {
                    count++;
                }
            }

            if ((row - 1 >= 0) && (col + 1 < cols))
            {
                if (mines[row - 1, col + 1] == '*')
                {
                    count++;
                }
            }

            if ((row + 1 < rows) && (col - 1 >= 0))
            {
                if (mines[row + 1, col - 1] == '*')
                {
                    count++;
                }
            }

            if ((row + 1 < rows) && (col + 1 < cols))
            {
                if (mines[row + 1, col + 1] == '*')
                {
                    count++;
                }
            }

            return char.Parse(count.ToString());
        }
    }
}