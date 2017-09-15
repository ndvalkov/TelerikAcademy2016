using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheRings
{
    class Solution
    {
        private static int combinations = 0;
        private static long totalCombos = 1;
        private static string input = @"6
0
1
2
3
4
4";
        static void Main()
        {
            // GeneratePermutations(new int[] { 2, 3, 4 }, 0);
            // Console.WriteLine(combinations);

            var N = int.Parse(Console.ReadLine());

            var rootIndex = -1;
            var listOfRings = Enumerable.Range(1, N)
                .Select(x => new Tree<int>(x))
                .ToList();
            for (int i = 1; i <= N; i++)
            {
                var ringTo = int.Parse(Console.ReadLine());
                if (ringTo == 0)
                {
                    rootIndex = i - 1;
                    continue;
                }
                listOfRings[ringTo - 1].AddChild(listOfRings[i - 1]);
            }

            Bfs(listOfRings[rootIndex]);
            Console.WriteLine(totalCombos);
        }

        class Tree<T>
        {
            private T value;

            private Tree<T> left;
            private Tree<T> right;

            public List<Tree<T>> Nodes { get; set; }

            public T GetValue()
            {
                return value;
            }

            public Tree(T value)
            {
                this.value = value;
                Nodes = new List<Tree<T>>();
            }

            public void AddChild(T value)
            {
                Nodes.Add(new Tree<T>(value));
            }

            public void AddChild(Tree<T> value)
            {
                Nodes.Add(value);
            }

            public override string ToString()
            {
                return this.value.ToString();
            }
        }

        static void Bfs<T>(Tree<T> root)
        {
            var q = new Queue<Tree<T>>();
            q.Enqueue(root);

            while (q.Count > 0)
            {
                var x = q.Dequeue();

                if (x.Nodes.Count != 0)
                {

                    var nodeArr = Enumerable.Range(1, x.Nodes.Count).ToArray();
                    GeneratePermutations(nodeArr, 0);
                    totalCombos *= combinations;
                    combinations = 0;

                    foreach (var node in x.Nodes)
                    {
                        q.Enqueue(node);
                    }


                    // Console.WriteLine();

                }
            }
        }

        static void GeneratePermutations<T>(T[] arr, int k)
        {
            if (k >= arr.Length)
            {
                // Console.WriteLine(string.Join(" ", arr));
                combinations++;
            }
            else
            {
                GeneratePermutations(arr, k + 1);
                for (int i = k + 1; i < arr.Length; i++)
                {
                    Swap(ref arr[k], ref arr[i]);
                    GeneratePermutations(arr, k + 1);
                    Swap(ref arr[k], ref arr[i]);
                }
            }
        }

        static void Swap<T>(ref T first, ref T second)
        {
            T oldFirst = first;
            first = second;
            second = oldFirst;
        }
    }
}