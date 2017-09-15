using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem1
{
    class Solution
    {
        private static int nodesVisited = 0;
        private static int exitRow;
        private static int exitCol;
        private static string exitKey;

        static void Main()
        {
            var line = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            var N = line[0];
            var M = line[1];
            var B = line[2];

            var beers = new List<Tuple<int, int>>();
            beers.Add(new Tuple<int, int>(0, 0));
            for (int i = 0; i < B; i++)
            {
                line = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
                var row = line[0];
                var col = line[1];
                beers.Add(new Tuple<int, int>(row, col));
            }

            exitRow = N - 1;
            exitCol = M - 1;
            beers.Add(new Tuple<int, int>(exitRow, exitCol));
            exitKey = exitRow + "" + exitCol;
            var vertices = GetGraphWithAdjecencyList(beers);
            var dists = Dijkstra(vertices, "00");
            
            var shortestToEnd = dists[exitKey];
            Console.WriteLine(nodesVisited);
            nodesVisited++;
            // Console.WriteLine(shortestToEnd - (nodesVisited * 5));

            // PrintMatrix(matrix);
            // Console.WriteLine(matrix[exitRow, exitCol] == -1 ? 0 : matrix[exitRow, exitCol]);


        }


        private static Dictionary<string, int> Dijkstra(Dictionary<string, LinkedList<Node<string, int>>> vertices, string start)
        {
            // regular for is better
            //var d = Enumerable.Range(1, vertices.Length)
            //    .Select(_ => int.MaxValue)
            //    .ToArray();
            const int INFINITY = int.MaxValue;

            var keys = vertices.Keys;
            var d = new Dictionary<string, int>();

            foreach (var key in keys)
            {
                d[key] = INFINITY;
            }

            d[start] = 0;

            var used = new HashSet<string>();
            var queue = new PriorityQueue<Node<string, int>>();
            queue.Enqueue(new Node<string, int>(start, 0));

            // repeat N times
            while (queue.IsEmpty == false)
            {
                //1. get best node to continue
                var node = queue.Dequeue();
                while (queue.IsEmpty == false &&
                    used.Contains(node.To))
                {
                    node = queue.Dequeue();
                }

                used.Add(node.To);

                // update distances for neightbours of best

                var nexts = vertices[node.To];
                foreach (var next in nexts)
                {
                    var currentDistance = d[next.To];
                    var newDistance = d[node.To] + next.Distance;

                    if (currentDistance <= newDistance) { continue; }

                    if (next.To == exitKey)
                    {
                        nodesVisited++;
                    }
                    d[next.To] = newDistance;
                    queue.Enqueue(new Node<string, int>(next.To, newDistance));
                }

            }
            return d;
        }

        class Node<T1, T2> : IComparable<Node<T1, T2>> where T2 : IComparable
        {
            public Node(T1 to, T2 distance)
            {
                To = to;
                Distance = distance;
            }

            public T1 To { get; set; }

            public T2 Distance { get; set; }

            public int CompareTo(Node<T1, T2> other)
            {
                return this.Distance.CompareTo(other.Distance);
            }
        }

        private static Dictionary<string, LinkedList<Node<string, int>>> GetGraphWithAdjecencyList(List<Tuple<int, int>> beers)
        {
            var vertices =
                new Dictionary<string, LinkedList<Node<string, int>>>();

            for (int i = 0; i < beers.Count; i++)
            {
                for (int j = 0; j < beers.Count; j++)
                {
                    var fromNode = beers[i];
                    var from = fromNode.Item1 + "" + fromNode.Item2;
                    var toNode = beers[j];
                    var to = toNode.Item1 + "" + toNode.Item2;

                    if (!vertices.ContainsKey(from))
                    {
                        vertices[from] = new LinkedList<Node<string, int>>();
                    }
                    if (!vertices.ContainsKey(to))
                    {
                        vertices[to] = new LinkedList<Node<string, int>>();
                    }

                    var distance = Math.Abs(fromNode.Item1 - toNode.Item1) + Math.Abs(fromNode.Item2 - toNode.Item2);
                    vertices[from].AddLast(new Node<string, int>(to, distance));
                    vertices[to].AddLast(new Node<string, int>(from, distance));
                }
            }

            return vertices;
        }

        public class PriorityQueue<T>
        where T : IComparable<T>
        {
            private List<T> heap;
            private Func<T, T, bool> compare;

            public PriorityQueue()
            {
                this.heap = new List<T>
            {
                default(T)
            };

                this.compare = (x, y) => x.CompareTo(y) < 0;
            }

            public T Top
            {
                get
                {
                    return this.heap[1];
                }
                set
                {
                    this.heap[1] = value;
                }
            }

            public int Count
            {
                get
                {
                    return this.heap.Count - 1;
                }
                set
                {
                    throw new NotImplementedException();
                }
            }

            public bool IsEmpty
            {
                get
                {
                    return this.Count == 0;
                }
                set
                {
                    throw new NotImplementedException();
                }
            }

            public void Enqueue(T value)
            {
                var index = heap.Count; // index where inserted
                heap.Add(value);

                while (index > 1 && compare(value, heap[index / 2]))
                {
                    heap[index] = heap[index / 2];
                    index /= 2;
                }

                heap[index] = value;
            }

            public T Dequeue()
            {
                var toReturn = heap[1];
                var value = heap[heap.Count - 1];
                heap.RemoveAt(heap.Count - 1);

                if (!this.IsEmpty)
                {
                    this.HeapifyDown(1, value);
                }

                return toReturn;
            }

            private void HeapifyDown(int index, T value)
            {
                while (index * 2 + 1 < heap.Count)
                {
                    var smallerKidIndex = compare(heap[index * 2], heap[index * 2 + 1])
                        ? index * 2
                        : index * 2 + 1;
                    if (compare(heap[smallerKidIndex], value))
                    {
                        heap[index] = heap[smallerKidIndex];
                        index = smallerKidIndex;
                    }
                    else
                    {
                        break;
                    }
                }

                if (index * 2 < heap.Count)
                {
                    var smallerKidIndex = index * 2;
                    if (compare(heap[smallerKidIndex], value))
                    {
                        heap[index] = heap[smallerKidIndex];
                        index = smallerKidIndex;
                    }
                }

                heap[index] = value;
            }
        }

        static void PrintMatrix<T>(T[,] matrix)
        {
            for (var i = 0; i < matrix.GetLength(0); i++)
            {
                for (var j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write("{0,4} ", matrix[i, j]);
                    // Console.Write("{0} ", matrix[i, j]);
                }
                Console.WriteLine();
            }
        }

        static bool InRange(long[,] tiles, int row, int col)
        {
            bool rowInRange = row >= 0 && row < tiles.GetLength(0);
            bool colInRange = col >= 0 && col < tiles.GetLength(1);
            return rowInRange && colInRange;
        }

        private static T GetCellValue<T>(T[,] tiles, int row, int col)
        {
            return tiles[row, col];
        }
    }
}