using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Doc
{
    class Solutin
    {
        private static string line = null;
        private static volatile int steps = 0;
        private static int counter = 0;

        static void Main()
        {
            // var ss = GetShortestDistance('z', 'g');
            // Console.WriteLine(ss);

            line = Console.ReadLine();

            var left = 0;
            var right = line.Length - 1;

            if (line.Length < 1000)
            {
                ProcessPali(left, right);
            }
            else
            {
                // divide and conquer
                var quater = line.Length / 4;
                var limitLeft = left + quater;
                var limitRight = right + quater;

                ThreadStart secondTask = () => ProcessPaliParallel(left, right, limitLeft, limitRight);
                var secondThread = new Thread(secondTask);
                secondThread.Start();
                ThreadStart thirdTask = () => ProcessPali(limitLeft, limitRight);
                var thirdThread = new Thread(thirdTask);
                thirdThread.Start();

                secondThread.Join();
                thirdThread.Join();
            }

            Console.WriteLine(steps);
        }

        private static void ProcessPaliParallel(int left, int right, int limitLeft, int limitRight)
        {
            while (left != right)
            {
                if (left == limitLeft && right == limitRight)
                {
                    break;
                }

                if (!char.IsLetter(line[left]) && left < limitLeft)
                {
                    left++;
                    continue;
                }

                if (!char.IsLetter(line[right]) && right > limitRight)
                {
                    right--;
                    continue;
                }

                var leftToLower = line[left].ToString().ToLower()[0];
                var rightToLower = line[right].ToString().ToLower()[0];

                var newSteps = GetShortestDistance(leftToLower, rightToLower);

                steps += newSteps;

                if (left < limitLeft)
                {
                    left++;
                }

                if (right > limitRight)
                {
                    right--;
                }
            }
        }

        private static void ProcessPali(int left, int right)
        {
            while (left != right)
            {
                if (!char.IsLetter(line[left]))
                {
                    left++;
                    continue;
                }

                if (!char.IsLetter(line[right]))
                {
                    right--;
                    continue;
                }

                var leftToLower = line[left].ToString().ToLower()[0];
                var rightToLower = line[right].ToString().ToLower()[0];

                var newSteps = GetShortestDistance(leftToLower, rightToLower);
                steps += newSteps;

                left++;
                right--;
            }
        }

        private static int GetShortestDistance(char x, char y)
        {
            var d1 = Math.Abs(x - y);

            if (d1 >= 13)
            {
                return 26 - d1;
            }
            else
            {
                return d1;
            }
        }

        private static char Increase(char letter)
        {
            letter = letter.ToString().ToLower()[0];
            return (letter == 'z' ? 'a' : (char) (letter + 1));
        }

        private static char Decrease(char letter)
        {
            letter = letter.ToString().ToLower()[0];
            return (letter == 'a' ? 'z' : (char) (letter - 1));
        }
    }
}