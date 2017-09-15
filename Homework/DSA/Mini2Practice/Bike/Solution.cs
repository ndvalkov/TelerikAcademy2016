using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Bike
{
    class Solution
    {
        private static float currentLowestDamage = Int32.MaxValue;

        static void Main()
        {
            var R = int.Parse(Console.ReadLine());
            var C = int.Parse(Console.ReadLine());

            var tiles = new float[R, C];

            for (int i = 0; i < R; i++)
            {
                var line = Console.ReadLine().Split().Select(float.Parse).ToArray();

                for (int j = 0; j < C; j++)
                {
                    tiles[i, j] = line[j];
                }
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
    }
}
