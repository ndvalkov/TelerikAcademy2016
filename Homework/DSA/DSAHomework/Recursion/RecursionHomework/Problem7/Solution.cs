using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem7
{
    class Solution
    {
        struct Cell
        {
            public int Row { get; set; }
            public int Col { get; set; }
        }
        
        static char[,] m =
        {
            { ' ', ' ', ' '},
            { ' ', ' ', ' '},
            { ' ', ' ', ' '}
        };

        static List<Cell[]> paths = new List<Cell[]>();

        static void Main()
        {

        }

        static void FindPathToExit(int row, int col, char direction)
        {
            #if DEBUG_MODE
                        PrintLabyrinth(row, col);
            #endif

            if (!InRange(row, col))
            {
                // We are out of the labyrinth -> can't find a path
                return;
            }

            // Append the current direction to the path
            path.Add(direction);

            // Check if we have found the exit
            if (m[row, col] == 'e')
            {
                PrintPath(path);
            }

            if (m[row, col] == ' ')
            {
                // Temporary mark the current cell as visited
                m[row, col] = 's';

                // Recursively explore all possible directions
                FindPathToExit(row, col - 1, 'L'); // left
                FindPathToExit(row - 1, col, 'U'); // up
                FindPathToExit(row, col + 1, 'R'); // right
                FindPathToExit(row + 1, col, 'D'); // down

                // Mark back the current cell as free
                m[row, col] = ' ';
            }   

            // Remove the last direction from the path
            path.RemoveAt(path.Count - 1);
        }

        static bool InRange(int row, int col)
        {
            bool rowInRange = row >= 0 && row < m.GetLength(0);
            bool colInRange = col >= 0 && col < m.GetLength(1);
            return rowInRange && colInRange;
        }

        private static void PrintLabyrinth(int currentRow, int currentCol)
        {
            for (int row = -1; row <= m.GetLength(0); row++)
            {
                Console.WriteLine();
                for (int col = -1; col <= m.GetLength(1); col++)
                {
                    if ((row == currentRow) && (col == currentCol))
                    {
                        Console.BackgroundColor = ConsoleColor.Cyan;
                        Console.Write("x");
                        Console.BackgroundColor = ConsoleColor.Black;
                    }
                    else if (!InRange(row, col))
                    {
                        Console.Write(" ");
                    }
                    else if (m[row, col] == ' ')
                    {
                        Console.Write("-");
                    }
                    else
                    {
                        Console.Write(m[row, col]);
                    }
                    Console.Write(" ");
                }
            }
            Console.WriteLine();
            Console.ReadKey();
        }
    }
}