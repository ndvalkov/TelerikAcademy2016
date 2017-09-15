using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portals
{
    class Solution
    {
        private static long maxSum = long.MinValue;

        static void Main()
        {
            var line = Console.ReadLine().Trim().Split(null).Select(int.Parse).ToList();
            var startX = line[0];
            var startY = line[1];
            line = Console.ReadLine().Trim().Split(null).Select(int.Parse).ToList();
            var R = line[0];
            var C = line[1];

            var lab = new int[R, C];

            for (int i = 0; i < R; i++)
            {
                var row = Console.ReadLine().Trim().Split(null);
                for (int j = 0; j < row.Length; j++)
                {
                    var c = row[j];
                    if (c == "#")
                    {
                        lab[i, j] = -1;
                    }
                    else
                    {
                        lab[i, j] = c[0] - '0';
                    }
                }
            }
            // PrintMatrix(lab);

            var visited = new bool[R, C];
            FindMaxTeleportPower(lab, startX, startY, visited, 0);
            Console.WriteLine(maxSum);
        }

        private static void FindMaxTeleportPower(int[,] lab, int row, int col, bool[,] visited, long currentMax)
        {
            var isVisited = GetCellValue(visited, row, col);
            var cellValue = GetCellValue(lab, row, col);
            if (isVisited || cellValue == -1)
            {
                return;
            }

            visited[row, col] = true;
//            Console.WriteLine("row"  + row + "col" + col);
//            Console.WriteLine("-------------");

            currentMax += cellValue;
            if (currentMax > maxSum)
            {
                maxSum = currentMax;
            }

            if (InRange(lab, row - cellValue, col))
            {
                visited[row, col] = true;
                FindMaxTeleportPower(lab, row - cellValue, col, visited, currentMax);
                visited[row, col] = false;
            }

            if (InRange(lab, row, col + cellValue))
            {
                visited[row, col] = true;
                FindMaxTeleportPower(lab, row, col + cellValue, visited, currentMax);
                visited[row, col] = false;
            }

            if (InRange(lab, row + cellValue, col))
            {
                visited[row, col] = true;
                FindMaxTeleportPower(lab, row + cellValue, col, visited, currentMax);
                visited[row, col] = false;
            }

            if (InRange(lab, row, col - cellValue))
            {
                visited[row, col] = true;
                FindMaxTeleportPower(lab, row, col - cellValue, visited, currentMax);
                visited[row, col] = false;
            }

            
        }

        static void PrintMatrix<T>(T[,] matrix)
        {
            for (var i = 0; i < matrix.GetLength(0); i++)
            {
                for (var j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write("{0,4} ", matrix[i, j]);
                    // Console.Write("{0} ", matrix[i, j]);
                }
                Console.WriteLine();
            }
        }

        static bool InRange(int[,] tiles, int row, int col)
        {
            bool rowInRange = row >= 0 && row < tiles.GetLength(0);
            bool colInRange = col >= 0 && col < tiles.GetLength(1);
            return rowInRange && colInRange;
        }

        private static T GetCellValue<T>(T[,] tiles, int row, int col)
        {
            return tiles[row, col];
        }
    }
}
