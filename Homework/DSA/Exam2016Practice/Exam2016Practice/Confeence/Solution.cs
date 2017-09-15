using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Confeence
{
    class Solution
    {
        static void Main()
        {
            var line = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            var N = line[0];
            var M = line[1];

            var uf = new UnionFind(N);
            for (int i = 0; i < M; i++)
            {
                line = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
                uf.Union(line[0], line[1]);
            }

            Dictionary<int, List<int>> companies = new Dictionary<int, List<int>>();
            for (int i = 0; i < N; i++)
            {
                var company = uf.Find(i);
                if (!companies.ContainsKey(company))
                {
                    companies[company] = new List<int>();
                }

                companies[company].Add(i);
            }

            var keys = companies.Keys.ToList();
            var res = 0;

            if (keys.Count < 2)
            {
                // all in
                Console.WriteLine(res);
            }
            else
            {

                res = 1;
                var counts = keys.Select(x => companies[x].Count)
                    .ToList();
                counts.Sort((x, y) => y - x);

                if (counts[0] == 1)
                {
                    Console.WriteLine(Combination(counts.Count, 2));
                    return;
                }

                var ones = 0;
                var sumOfNotOnes = 0;
                for (int i = 0; i < counts.Count; i++)
                {
                    var cur = counts[i];
                    if (cur > 1)
                    {
                        res *= cur;
                        sumOfNotOnes += cur;
                    }
                    else
                    {
                        if (i == 1)
                        {
                            res = sumOfNotOnes;
                        }
                        else
                        {
                            res += sumOfNotOnes;
                        }
                        
                        ones++;
                    }
                }

                var toAdd = 0;
                if (ones > 1)
                {
                    toAdd = (int) Combination(ones, 2);
                }

                Console.WriteLine(res + toAdd);
            }
        }

        public static long Combination(long n, long k)
        {
            double sum = 0;
            for (long i = 0; i < k; i++)
            {
                sum += Math.Log10(n - i);
                sum -= Math.Log10(i + 1);
            }
            return (long) Math.Pow(10, sum);
        }
    }

    public class UnionFind
    {
        private int[] array;

        public UnionFind(int n)
        {
            array = new int[n];
            for (int i = 0; i < n; i++)
            {
                array[i] = -1;
            }
        }

        public int FindIterative(int x)
        {
            while (array[x] >= 0)
            {
                x = array[x];
            }
            return x;
        }

        public int Find(int x)
        {
            //return array[x] < 0 ? x : array[x] = Find(array[x]);
            if (array[x] < 0)
            {
                return x;
            }
            array[x] = Find(array[x]);
            return array[x];
        }

        public bool InTheSameSet(int x, int y)
        {
            return Find(x) == Find(y);
        }

        public bool Union(int x, int y)
        {
            x = Find(x);
            y = Find(y);
            if (x == y)
            {
                return false;
            }
            array[x] = y;
            return true;
        }

        public void Print()
        {
            Console.WriteLine(string.Join(" ", array));
        }
    }
}