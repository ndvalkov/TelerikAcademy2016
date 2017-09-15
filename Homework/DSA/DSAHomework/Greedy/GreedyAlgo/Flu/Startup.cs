using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Flu
{
    public class Startup
    {
        public static void Main(string[] args)
        {
            var fluR = int.Parse(Console.ReadLine());
            var N = int.Parse(Console.ReadLine());

            List<Point> points = new List<Point>();
            for (int i = 0; i < N; i++)
            {
                var coords = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                var x = coords[0];
                var y = coords[1];

                var p = new Point(x, y);
                points.Add(p);
            }

            var origins = new List<Point>();
            origins.Add(points[0]);

            var visited = new HashSet<Point>();
            var all = new SortedSet<Point>(origins);

            while (all.Count != 1)
            {
                var l = all.ToList();

                var foundCloseP = false;

                


                all.ExceptWith(visited);
            }


        }

        private static double GetDistance(double x1, double y1, double x2, double y2)
        {
            return Math.Sqrt(Math.Pow((x2 - x1), 2) + Math.Pow((y2 - y1), 2));
        }
    }
}
