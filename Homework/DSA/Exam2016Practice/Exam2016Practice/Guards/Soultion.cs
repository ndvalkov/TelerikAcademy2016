using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Guards
{
    class Soultion
    {
        // public const string DIRS = "UDLR";
        public static Dictionary<char, int> dirs = new Dictionary<char, int>();
        private static int ThreadsRunning = 0;

        //        private static void Benchmark(Action act, int iterations)
        //        {
        //            GC.Collect();
        //            act.Invoke(); // run once outside of loop to avoid initialization costs
        //            Stopwatch sw = Stopwatch.StartNew();
        //            for (int i = 0; i < iterations; i++)
        //            {
        //                act.Invoke();
        //            }
        //            sw.Stop();
        //            Console.WriteLine($"Ellapsed: {(sw.ElapsedMilliseconds.ToString())}");
        //            //  Console.WriteLine($"Ellapsed: {sw.ElapsedMilliseconds}");
        //        }

        public static void Main()
        {
            var line = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var rows = line[0];
            var cols = line[1];

            var dp = new int[rows + 1, cols + 1];
            dirs['U'] = -1;
            dirs['R'] = -2;
            dirs['D'] = -3;
            dirs['L'] = -4;

            var line2 = int.Parse(Console.ReadLine());
            for (int i = 0; i < line2; i++)
            {
                var guards = Console.ReadLine().Split(' ');

                var gRow = int.Parse(guards[0]);
                var gCol = int.Parse(guards[1]);
                var gDir = guards[2][0];
                dp[gRow + 1, gCol + 1] = -1;

                if (gDir == 'U')
                {
                    dp[gRow, gCol + 1] = -2;
                }
                else if (gDir == 'R')
                {
                    dp[gRow + 1, gCol + 2] = -2;
                }
                else if (gDir == 'D')
                {
                    dp[gRow + 2, gCol + 1] = -2;
                }
                else
                {
                    dp[gRow + 2, gCol] = -2;
                }
            }

            //            Benchmark(() =>
            //            {
            GenerateDP(dp);
            //            }, 300);
            // GenerateDP(dp);
            // PrintMatrix(dp);
            Console.WriteLine(dp[rows, cols] == 0 ? "Meow" : dp[rows, cols].ToString());
        }

        private static void GenerateDP(int[,] dp)
        {
            GenerateDP(dp, 1, 1);

        }

        private static void GenerateDP(int[,] dp, int row, int col)
        {
            if (!InRange(row, col, dp) || (dp[row, col] == -1))
            {
                return;
            }

            var timeIncrement = 1;

            if (dp[row, col] == -2)
            {
                timeIncrement = 3;
            }

            var rightTime = dp[row, col - 1] <= 0 ? int.MaxValue : dp[row, col - 1] + timeIncrement;
            var downTime = dp[row - 1, col] <= 0 ? int.MaxValue : dp[row - 1, col] + timeIncrement;

            if (row == 1 && col == 1)
            {
                rightTime = downTime = 1;
            }

            var time = Math.Min(rightTime, downTime);
            dp[row, col] = time;
            // Console.WriteLine("----------------");
            // PrintMatrix(dp);
            // right

            GenerateDP(dp, row, col + 1);
            GenerateDP(dp, row + 1, col);

            //            if (ThreadsRunning < 8)
            //            {
            //                //                Parallel.Invoke(
            //                //    () => GenerateDP(dp, row, col + 1),
            //                //    () => GenerateDP(dp, row + 1, col));
            //                // ThreadsRunning += 2;
            //                var t1 = Task.Factory.StartNew(() => GenerateDP(dp, row, col + 1));
            //                var t2 = Task.Factory.StartNew(() => GenerateDP(dp, row + 1, col));
            //                Task.WaitAll(t1, t2);
            //                ThreadsRunning += 2;
            //                //                                            ThreadStart secondTask = () => GenerateDP(dp, row, col + 1);
            //                //                                            var secondThread = new Thread(secondTask);
            //                //                                            secondThread.Start();
            //                //                                            ThreadsRunning++;
            //                //                                            ThreadStart thirdTask = () => GenerateDP(dp, row + 1, col);
            //                //                                            var thirdThread = new Thread(thirdTask);
            //                //                                            thirdThread.Start();
            //                //                                            ThreadsRunning++;
            //                //                            
            //                //                                            secondThread.Join();
            //                //                                            thirdThread.Join();
            //            }
            //            else
            //            {
            //                GenerateDP(dp, row, col + 1);
            //                GenerateDP(dp, row + 1, col);
            //            }
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

        static bool InRange(int row, int col, int[,] grid)
        {
            bool rowInRange = row >= 1 && row < grid.GetLength(0);
            bool colInRange = col >= 1 && col < grid.GetLength(1);
            return rowInRange && colInRange;
        }
    }
}