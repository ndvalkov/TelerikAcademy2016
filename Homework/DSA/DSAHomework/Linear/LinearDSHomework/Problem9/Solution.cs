using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem9
{
    class Solution
    {
        // We are given the following sequence:
        //S1 = N;
        //S2 = S1 + 1;
        //S3 = 2*S1 + 1;
        //S4 = S1 + 2;
        //S5 = S2 + 1;
        //S6 = 2*S2 + 1;
        //S7 = S2 + 2;
        //...
        //Using the Queue<T> class write a program to print its first 50 members for given N.
        //Example: N= 2 → 2, 3, 5, 4, 4, 7, 5, 6, 11, 7, 5, 9, 6, ...

        static void Main()
        {
            var N = 2;
            var q = new Queue<int>();

            q.Enqueue(2);

            var popped = new List<int>();
            for (int i = 0; i < 50; i++)
            {
                var top = q.Peek();
                q.Enqueue(top + 1);
                q.Enqueue(2 * top + 1);
                q.Enqueue(top + 2);
                popped.Add(q.Dequeue());
            }

            popped.AddRange(q);
            Console.WriteLine(string.Join(" ", popped));
        }
    }
}
