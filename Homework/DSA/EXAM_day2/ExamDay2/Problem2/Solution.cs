using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem2
{
    class Solution
    {
        static void Main()
        {
            // number of dependencies
            var N = int.Parse(Console.ReadLine());

            // var dependencies = new Dictionary<string, Tree<string>>();
            var allPeople = new Dictionary<string, Dictionary<string, Tree<string>>>();
            var sb = new StringBuilder();

            for (int i = 0; i < N; i++)
            {
                var line = Console.ReadLine().Split(' ');
                var personX = line[0];
                var personY = line[1];
                var subjectZ = line[2];

                if (!allPeople.ContainsKey(subjectZ))
                {
                    var parent = new Tree<string>(personY);
                    var child = new Tree<string>(personX);
                    parent.AddChild(child);

                    allPeople[subjectZ] = new Dictionary<string, Tree<string>>();
                    allPeople[subjectZ][personX] = child;
                    allPeople[subjectZ][personY] = parent;
                }
                else
                {
                    Tree<string> child = null;
                    if (allPeople[subjectZ].ContainsKey(personX))
                    {
                        child = allPeople[subjectZ][personX];
                    }
                    else
                    {
                        child = new Tree<string>(personX);
                        allPeople[subjectZ][personX] = child;
                    }

                    Tree<string> parent = null;
                    if (allPeople[subjectZ].ContainsKey(personY))
                    {
                        parent = allPeople[subjectZ][personY];
                    }
                    else
                    {
                        parent = new Tree<string>(personY);
                        allPeople[subjectZ][personY] = parent;
                    }

                    parent.AddChild(child);
                }

            }

            // number of commands
            var M = int.Parse(Console.ReadLine());

            for (int i = 0; i < M; i++)
            {
                var line = Console.ReadLine().Split(' ');
                var depending = line[0];
                var on = line[1];

                var dependingNode = allPeople[on][depending];

                var parent = dependingNode.Parent;
                var deps = new LinkedList<string>();
                deps.AddFirst(dependingNode.GetValue());

                while (parent != null)
                {
                    deps.AddFirst(parent.GetValue());
                    parent = parent.Parent;
                }

                sb.AppendLine(string.Join(", ", deps));
            }

            var res = sb.ToString().TrimEnd();
            Console.WriteLine(res);
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
                value.Parent = this;
            }

            public override string ToString()
            {
                return this.value.ToString();
            }
        }

        
    }
}
