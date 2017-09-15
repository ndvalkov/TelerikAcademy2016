using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem1
{
    class Solution
    {
        private static double MJ;
        private static double MH;

        static void Main()
        {
            var line = Console.ReadLine().Split(' ').Select(double.Parse).ToList();

            // trees in the jungle
            var N = line[0];
            // max X
            MJ = line[1];
            // max Y
            MH = line[2];

            var trees = new List<Point>();
            for (int i = 0; i < N; i++)
            {
                var next = Console.ReadLine().Split(' ').Select(double.Parse).ToList();
                trees.Add(new Point { X = next[0], Y = next[1] });
            }

            var ordered = trees.OrderBy(p => p.X).ToArray();

            var startPoint = ordered.Last();
            var endPoint = ordered.First();

            var steps = 0;

            while (!startPoint.Equals(endPoint))
            {
                var lowerBound = startPoint.X - MJ;
                var indexOfLB = ordered.LowerBound(new Point { X = lowerBound, Y = 0 });

                var canJump = false;
                for (int i = indexOfLB; i < ordered.Count(); i++)
                {
                    var nextPoint = ordered[i];
                    if (nextPoint.Equals(startPoint))
                    {
                        break;
                    }
                    canJump = CanJumpBetween(startPoint, nextPoint);
                    if (canJump)
                    {
                        startPoint = nextPoint;
                        steps++;
                        break;
                    }
                }

                if (canJump == false)
                {
                    break;
                }
            }

            if (!startPoint.Equals(endPoint))
            {
                Console.WriteLine(-1);
            }
            else
            {
                Console.WriteLine(steps);
            }

            
            // Console.WriteLine();

            // var canJump = CanJumpBetween();
        }

        private static bool CanJumpBetween(Point p1, Point p2)
        {
            var xDif = p1.X - p2.X;
            var hDif = p1.Y - p2.Y;
            return xDif <= MJ && hDif <= MH;
        }

        class Point : IComparable<Point>
        {
            public double X { get; set; }

            public double Y { get; set; }

            public double DistanceTo(Point other)
            {
                var dx = this.X - other.X;
                var dy = this.Y - other.Y;
                return Math.Sqrt(dx * dx + dy * dy);
            }

            public int CompareTo(Point other)
            {
                if (this.X.CompareTo(other.X) == 0)
                {
                    return this.Y.CompareTo(other.Y);
                }

                return this.X.CompareTo(other.X);
            }
        }
    }

    static class BinarySearch
    {
        public static int BinarySearchFindWhateverIterative<T>(this T[] array, T value)
            where T : IComparable<T>
        {
            //return array.BinarySearchFindWhatever(value, 0, array.Length);

            int left = 0;
            int right = array.Length;

            while (left < right)
            {
                int middle = (left + right) / 2;
                int cmp = array[middle].CompareTo(value);
                if (cmp < 0)
                {
                    left = middle + 1;
                }
                else if (cmp > 0)
                {
                    right = middle;
                }
                else
                {
                    return middle;
                }
            }

            return -1;
        }

        public static int LowerBound<T>(this T[] array, T value)
            where T : IComparable<T>
        {
            return array.Bound(mid => mid.CompareTo(value) < 0);
        }

        public static int UpperBound<T>(this T[] array, T value)
            where T : IComparable<T>
        {
            return array.Bound(mid => mid.CompareTo(value) <= 0);
        }

        private static int Bound<T>(this T[] array, Func<T, bool> f)
        {
            int left = 0;
            int right = array.Length;

            while (left < right)
            {
                int middle = (left + right) / 2;
                //if (array[middle].CompareTo(value) < 0)
                if (f(array[middle]))
                {
                    left = middle + 1;
                }
                else
                {
                    right = middle;
                }
            }

            return left;
        }

        public static int BinarySearchFindWhateverRecursive<T>(this T[] array, T value)
            where T : IComparable<T>
        {
            return array.BinarySearchFindWhateverRecursive(value, 0, array.Length);
        }

        private static int BinarySearchFindWhateverRecursive<T>(this T[] array, T value, int left, int right)
            where T : IComparable<T>
        {
            if (left >= right)
            {
                return -1;
            }

            int middle = (left + right) / 2;
            int cmp = array[middle].CompareTo(value);
            if (cmp < 0)
            {
                return array.BinarySearchFindWhateverRecursive(value, middle + 1, right);
            }
            if (cmp > 0)
            {
                return array.BinarySearchFindWhateverRecursive(value, left, middle);
            }
            return middle;
        }

        public static void BinarySearchSort<T>(this T[] array)
            where T : IComparable<T>
        {
            var sorted = new List<T>();

            foreach (var value in array)
            {
                int index = sorted.ToArray().UpperBound(value);
                sorted.Insert(index, value);
            }

            sorted.CopyTo(array);
        }
    }
}