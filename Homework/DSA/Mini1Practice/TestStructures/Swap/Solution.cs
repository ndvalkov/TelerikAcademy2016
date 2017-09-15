using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swap
{
    class Solution
    {
        static void Main()
        {
            var N = int.Parse(Console.ReadLine());
            var nums = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            var nodesList = Enumerable.Range(1, N).Select(x => new DoublyLinkedNode<int>(x)).ToList();

            nodesList[0].Prev = null;
            nodesList[0].Next = nodesList[1];
            nodesList[nodesList.Count - 1].Next = null;
            nodesList[nodesList.Count - 1].Prev = nodesList[nodesList.Count - 2];

            for (int i = 1; i < nodesList.Count - 1; i++)
            {
                nodesList[i].Prev = nodesList[i - 1];
                nodesList[i].Next = nodesList[i + 1];
            }

            var first = nodesList[0];
            var last = nodesList[nodesList.Count - 1];
            nums.ForEach((n) =>
            {
                var mid = nodesList[n - 1];

                if (mid.Equals(first))
                {
                    first = mid.Next;
                    first.Prev = null;

                    last.Next = mid;

                    mid.Next = null;
                    mid.Prev = last;

                    last = mid;
                    return;
                }

                if (mid.Equals(last))
                {
                    last = mid.Prev;
                    last.Next = null;

                    first.Prev = mid;

                    mid.Prev = null;
                    mid.Next = first;

                    first = mid;
                    return;
                }

                var newLast = mid.Prev;
                var newFirst = mid.Next;

                mid.Next = first;
                mid.Prev = last;

                first.Prev = mid;
                last.Next = mid;

                newLast.Next = null;
                newFirst.Prev = null;

                first = newFirst;
                last = newLast;
            });


            var result = new List<int>();
            result.Add(first.Value);
            while (first.Next != null)
            {
                result.Add(first.Next.Value);
                first = first.Next;
            }

            Console.WriteLine(string.Join(" ", result));
        }

        public class DoublyLinkedNode<T>
        {
            public T Value { get; set; }

            public DoublyLinkedNode<T> Prev { get; internal set; }

            public DoublyLinkedNode<T> Next { get; internal set; }

            internal DoublyLinkedNode(T value)
            {
                Value = value;
                Prev = null;
                Next = null;
            }
        }
    }
}
