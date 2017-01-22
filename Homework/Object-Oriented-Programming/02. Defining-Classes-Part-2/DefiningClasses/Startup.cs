using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Attributes;

namespace DefiningClasses
{
    class Startup
    {
        static void Main()
        {
            // TEST PATH STORAGE
            Stack<Point3D> seq = new Stack<Point3D>();
            seq.Push(new Point3D(23, 11, 2));
            seq.Push(new Point3D(-23, 2, 11));
            seq.Push(new Point3D(23, 43, 89));

            Path.PathStorage.SavePath(seq, "path.txt");

            // TEST GENERIC LIST
            GenericList<int> myList = new GenericList<int>(8);

            myList.Add(23);
            myList.Add(12);
            myList.Add(55);
            myList.Add(78);
            myList.Add(-1);

            Console.WriteLine(myList.ToString());
            int currentCount = myList.Count;
            Console.WriteLine("Count: " + currentCount);
            Console.WriteLine("Index of 23: " + myList.IndexOf(23));
            Console.WriteLine("Index of 12: " + myList.IndexOf(12));
            myList.Insert(108, 2);
            Console.WriteLine("After insertion: " + myList);
            myList.RemoveAt(2);
            Console.WriteLine("Removed: " + myList);
            myList.Clear();
            Console.WriteLine("Cleared: " + myList);

            try
            {
                GenericList<string> newList = new GenericList<string>(4);
                newList.Add(null);
                // myList.Insert(23, 105);
                // myList.RemoveAt(-12);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            myList.Add(23);
            myList.Add(12);
            myList.Add(55);
            myList.Add(78);
            myList.Add(-1);

            // should resize
            myList.Add(44);
            myList.Add(5);
            myList.Add(7);
            myList.Add(886);
            myList.Add(-12);
            Console.WriteLine("Resize: ");
            Console.WriteLine(myList.ToString());
            Console.WriteLine(myList.Capacity);

            // min/max
            Console.WriteLine("Max: " + myList.Max<int>());
            Console.WriteLine("Min: " + myList.Min<int>());

            // Matrix operators
            Matrix<decimal> m1 = new Matrix<decimal>(2, 2);
            m1[0, 0] = 34;
            m1[0, 1] = 16;
            m1[1, 0] = -2;
            m1[1, 1] = -3;

            Matrix<decimal> m2 = new Matrix<decimal>(2, 2);
            m2[0, 0] = 16;
            m2[0, 1] = 34;
            m2[1, 0] = 2;
            m2[1, 1] = 0;

            Console.WriteLine("Operator overloading: ");
            Console.WriteLine(new string('-', 23) + "Add");
            Console.WriteLine(m1 + m2);
            Console.WriteLine(new string('-', 23) + "Subtract");
            Console.WriteLine(m1 - m2);
            Console.WriteLine(new string('-', 23) + "Multiply");
            Console.WriteLine(m1 * m2);

            Console.WriteLine((bool)m1);
            Console.WriteLine((bool)m2);

            // Show version at runtime
            Console.Write("Version: ");
            var atr = typeof(SimpleValidator).GetCustomAttributes(typeof(MyVersion), true).FirstOrDefault() as MyVersion;
            Console.WriteLine(atr != null ? atr.Version : "no version attribute");

        }

    }
}