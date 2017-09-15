using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Mini2
{
    class Solution
    {
        private static Tree<long> theTree = new Tree<long>(1);
        private static SortedDictionary<long, bool> existing = new SortedDictionary<long, bool>();
        private static readonly long MAX_NODE = (long)Math.Pow(10, 18);

        static void Main()
        {
            var P = long.Parse(Console.ReadLine());
            var numbers = Console.ReadLine().Split(' ').Select(long.Parse).ToList();
            
            FillTree(theTree, P);
            existing[1] = true;
            var keys = existing.Keys;
            var resultList = new List<int>();
            numbers.ForEach(x =>
            {
                var pairs = 0;
                var possible = keys;
                foreach (var key in possible)
                {
                    if (pairs > 2 || key >= x)
                    {
                        break;
                    }
                    var pairKey = x - key;
                    if (existing.ContainsKey(pairKey))
                    {
                        pairs++;
                    }
                }

                if (pairs == 2)
                {
                    resultList.Add(1);
                }
                else
                {
                    resultList.Add(0);
                }
            });

            Console.WriteLine(string.Join(" ", resultList));
        }

        private static void FillTree(Tree<long> tree, long p)
        {
//            Stack<Tree<long>> stack = new Stack<Tree<long>>();
//            stack.Push(tree);
//
//            while (stack.Count > 0)
//            {
//                Tree<long> current = stack.Pop();
//
//                var val = current.Value;
//                existing[val] = true;
//
//                if (val > MAX_NODE)
//                {
//                    continue;
//                }
//
//                var left = new Tree<long>(val * p);
//                var right = new Tree<long>(val * p + 1);
//                current.Left = left;
//                current.Right = right;
//                stack.Push(left);
//                stack.Push(right);
//            }


            var val = tree.Value;
            existing[val] = true;
            if (val > MAX_NODE)
            {
                return;
            }

            var left = new Tree<long>(val * p);
            var right = new Tree<long>(val * p + 1);
            tree.Left = left;
            tree.Right = right;

            var t1 = Task.Factory.StartNew(() => FillTree(left, p));
            var t2 = Task.Factory.StartNew(() => FillTree(right, p));
            Task.WaitAll(t1, t2);
        }

        class Tree<T>
        {
            public Tree(T value)
                : this(value, null, null)
            {
            }

            public Tree(T value, Tree<T> left, Tree<T> right)
            {
                this.Value = value;
                this.Left = left;
                this.Right = right;
            }

            public T Value { get; set; }

            public Tree<T> Left { get; set; }

            public Tree<T> Right { get; set; }
        }
    }
}
