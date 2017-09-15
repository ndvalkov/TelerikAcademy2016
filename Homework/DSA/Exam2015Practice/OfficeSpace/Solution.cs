using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

namespace OfficeSpace
{
    class Solution
    {
        static List<int> timesOfDepenencies = new List<int>();
        static PriorityQueue<int> pq = new PriorityQueue<int>();

        static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var times = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            var tasks = times.Select(x => new Tree<int>(x)).ToArray();

            for (int i = 1; i <= n; i++)
            {
                var dep = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
                var currentTaskNode = tasks[i - 1];
                if (dep[0] != 0)
                {
                    dep.ForEach(x =>
                    {
                        currentTaskNode.AddChild(tasks[x - 1]);
                        tasks[x - 1].Parent = currentTaskNode;
                    });
                }
            }

            var root = tasks.Where(x => x.Parent == null && x.Nodes.Count > 0).ToArray();

            if (root.Length == 0)
            {
                if (tasks.All(x => x.Nodes.Count == 0))
                {
                    Console.WriteLine(times.Max());
                }
                else
                {
                    Console.WriteLine(-1);
                }
            }
            else
            {
                Bfs(root[0]);

                if (timesOfDepenencies.Count == 0)
                {
                    Console.WriteLine(times.Max());
                }
                else
                {
                    Console.WriteLine(timesOfDepenencies.Sum() + root[0].GetValue());
                }
            }
        }

        static void Bfs(Tree<int> root)
        {
            var q = new Queue<Tree<int>>();
            q.Enqueue(root);

            while (q.Count > 0)
            {
                var x = q.Dequeue();

                if (x.Nodes.Count != 0)
                {
                    
                    foreach (var node in x.Nodes)
                    {
                        q.Enqueue(node);
                        pq.Enqueue(node.GetValue());
                    }

                    timesOfDepenencies.Add(pq.Dequeue());
                    pq.Queue.Clear();
                }
            }
        }
    }

    class Tree<T>
    {
        private T value;

        public List<Tree<T>> Nodes { get; set; }

        public Tree<T> Parent { get; set; }

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

    class PriorityQueue<T> where T : IComparable<T>
    {
        public OrderedBag<T> Queue { get; set; }

        public int Count
        {
            get
            {
                return Queue.Count;
            }
        }

        public PriorityQueue()
        {
            Queue = new OrderedBag<T>();
        }

        public void Enqueue(T element)
        {
            Queue.Add(element);
        }

        public T Dequeue()
        {
            T element = Queue.RemoveLast();
            return element;
        }
    }
}
