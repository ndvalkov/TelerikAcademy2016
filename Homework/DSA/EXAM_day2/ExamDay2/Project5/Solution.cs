using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

namespace Project5
{
    class Solution
    {
        static void Main()
        {
            string command = Console.ReadLine();

            var sb = new StringBuilder();
            var ob = new OrderedBag<long>();
            while (command != "EXIT")
            {
                if (command == "FIND")
                {
                    var len = ob.Count;
                    var medianIndex = len / 2;
                    if (len % 2 == 1)
                    {
                        sb.AppendLine(ob[medianIndex].ToString());
                    }
                    else
                    {
                        var first = ob[medianIndex];
                        var second = ob[medianIndex - 1];
                        var median = (first + second) / 2d;
                        var formatted = string.Format("{0:0.0}", median);
                        sb.AppendLine(median % 1 == 0 ? ((int)median).ToString() : formatted);
                    }
                }
                else
                {
                    var cmdParams = command.Split(' ');
                    ob.Add(long.Parse(cmdParams[1]));
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(sb.ToString().TrimEnd());
        }
    }
}
