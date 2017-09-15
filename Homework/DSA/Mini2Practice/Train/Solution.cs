using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Train
{
    class Solution
    {
        static void Main()
        {
            var line = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            // potential passengers
            var N = line[0];
            // train capacity
            var M = line[1];
            // numer of stops
            var L = line[2];

            var trainStations = new SortedDictionary<int, Dictionary<string, List<int>>>();
            for (int i = 0; i < N; i++)
            {
                var points = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

                var from = points[0];
                var to = points[1];
                if (!trainStations.ContainsKey(from))
                {
                    trainStations[from] = new Dictionary<string, List<int>>();
                    var station = trainStations[from];

                    if (!station.ContainsKey("barding"))
                    {
                        station["barding"] = new List<int>();
                    }

                    if (!station.ContainsKey("exiting"))
                    {
                        station["exiting"] = new List<int>();
                    }
                }

                if (!trainStations.ContainsKey(to))
                {
                    trainStations[to] = new Dictionary<string, List<int>>();
                    var station = trainStations[to];

                    if (!station.ContainsKey("barding"))
                    {
                        station["barding"] = new List<int>();
                    }

                    if (!station.ContainsKey("exiting"))
                    {
                        station["exiting"] = new List<int>();
                    }
                }

                trainStations[from]["barding"].Add(1);
                trainStations[to]["exiting"].Add(1);
            }



            Console.WriteLine();
        }
    }
}
