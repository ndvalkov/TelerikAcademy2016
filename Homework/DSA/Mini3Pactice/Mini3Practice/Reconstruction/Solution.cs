using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reconstruction
{
    class Solution
    {
        static Dictionary<char, int> prices = new Dictionary<char, int>();

        static void Main()
        {
            var N = int.Parse(Console.ReadLine());

            // roads
            var M = new int[N, N];
            for (int i = 0; i < N; i++)
            {
                var row = Console.ReadLine();
                for (int j = 0; j < row.Length; j++)
                {
                    M[i, j] = row[j] - '0';
                }
            }

            GenPrices();
            // cost of build
            var B = new int[N, N];
            for (int i = 0; i < N; i++)
            {
                var row = Console.ReadLine();
                for (int j = 0; j < row.Length; j++)
                {
                    B[i, j] = prices[row[j]];
                }
            }

            // cost of destroy
            var D = new int[N, N];
            for (int i = 0; i < N; i++)
            {
                var row = Console.ReadLine();
                for (int j = 0; j < row.Length; j++)
                {
                    D[i, j] = prices[row[j]];
                }
            }
            PrintMatrix(M);
            Console.WriteLine("=====");
            PrintMatrix(B);
            Console.WriteLine("=====");
            PrintMatrix(D);

        }



        private static void GenPrices()
        {
            var p = 0;
            for (char c = 'A'; c <= 'Z'; c++)
            {
                prices[c] = p++;
            }

            for (char c = 'a'; c <= 'z'; c++)
            {
                prices[c] = p++;
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
