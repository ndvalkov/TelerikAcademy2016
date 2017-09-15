using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem7
{
    class Solution
    {
        static void Main()
        {
            var first = Console.ReadLine().Split(' ');
            var second = Console.ReadLine().Split(' ');
            var third = Console.ReadLine().Split(' ');

            var fly1X = double.Parse(first[0]);
            var fly1Y = double.Parse(first[1]);

            var fly2X = double.Parse(second[0]);
            var fly2Y = double.Parse(second[1]);

            var fly3X = double.Parse(third[0]);
            var fly3Y = double.Parse(third[1]);

            var vA = new Point(fly1X, fly1Y);
            var vB = new Point(fly2X, fly2Y);
            var vC = new Point(fly3X, fly3Y);

            var res = Circumcenter(vA, vB, vC);

            var formattedX = string.Format("{0:F4}", res.x);
            var formattedY = string.Format("{0:F4}", res.y);
            Console.WriteLine(formattedX + " " + formattedY);
        }

        public static Point Circumcenter(Point a, Point b, Point c)
        {
            var EPSILON = 1.0 / 1048576.0;
            var ax = a.x;
             var
            ay = a.y;
            var bx = b.x;
            var by = b.y;
            var cx = c.x;
            var cy = c.y;
            var fabsy1y2 = Math.Abs(ay - by);
            var fabsy2y3 = Math.Abs(by - cy);
            var xc = 0d;
            var yc = 0d;
            var m1 = 0d;
            var m2 = 0d;
            var mx1 = 0d;
            var mx2 = 0d;
            var my1 = 0d;
            var my2 = 0d;
            var dx = 0d;
            var dy = 0d;

            /* Check for coincident points */
            if (fabsy1y2 < EPSILON && fabsy2y3 < EPSILON)
            {
                // coincide
            }

            if (fabsy1y2 < EPSILON)
            {
                m2 = -((cx - bx) / (cy - by));
                mx2 = (bx + cx) / 2.0;
                my2 = (by + cy) / 2.0;
                xc = (bx + ax) / 2.0;
                yc = m2 * (xc - mx2) + my2;
            }

            else if (fabsy2y3 < EPSILON)
            {
                m1 = -((bx - ax) / (by - ay));
                mx1 = (ax + bx) / 2.0;
                my1 = (ay + by) / 2.0;
                xc = (cx + bx) / 2.0;
                yc = m1 * (xc - mx1) + my1;
            }

            else
            {
                m1 = -((bx - ax) / (by - ay));
                m2 = -((cx - bx) / (cy - by));
                mx1 = (ax + bx) / 2.0;
                mx2 = (bx + cx) / 2.0;
                my1 = (ay + by) / 2.0;
                my2 = (by + cy) / 2.0;
                xc = (m1 * mx1 - m2 * mx2 + my2 - my1) / (m1 - m2);
                yc = (fabsy1y2 > fabsy2y3) ?
                m1 * (xc - mx1) + my1 :
                m2 * (xc - mx2) + my2;
            }

            dx = bx - xc;
            dy = by - yc;

            return new Point(xc, yc);
        }

        public class Point
        {
            public Point(double x, double y)
            {
                this.x = x;
                this.y = y;
            }

            public double x { get; set; }

            public double y { get; set; }

            public double DistanceTo(Point other)
            {
                var dx = this.x - other.x;
                var dy = this.y - other.y;
                return (float) Math.Sqrt(dx * dx + dy * dy);
            }
        }
    }
}