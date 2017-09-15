using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Words
{
    class Solution
    {
        private static volatile int res = 0;

        static void Main()
        {
            var word = Console.ReadLine();
            var text = Console.ReadLine();
            var windowHashCache = new Hash[word.Length + 1];

            var ps = GeneratePrefixAndSuffixes(word);
            
            Parallel.ForEach(ps, x =>
            {
                var pattern1 = x.Item1;
                var pattern2 = x.Item2;

                var pattern1Hash = new Hash(pattern1);

                if (windowHashCache[pattern1.Length] == null)
                {
                    windowHashCache[pattern1.Length] = new Hash(text, pattern1.Length);
                }

                var pattern1Occurrences = CountOccurencesOfPattern(text, pattern1, pattern1Hash, windowHashCache[pattern1.Length]);

                var pattern2Hash = new Hash(pattern2);

                if (windowHashCache[pattern2.Length] == null)
                {
                    windowHashCache[pattern2.Length] = new Hash(text, pattern2.Length);
                }

                var pattern2Occurrences = CountOccurencesOfPattern(text, pattern2, pattern2Hash, windowHashCache[pattern2.Length]);

                res += pattern1Occurrences * pattern2Occurrences;
            });

//            ps.ForEach(x =>
//            {
//                var pattern1 = x.Item1;
//                var pattern2 = x.Item2;
//
//                var pattern1Hash = new Hash(pattern1);
//                var windowHash = new Hash(text, pattern1.Length);
//
//                var pattern2Hash = new Hash(pattern2);
//                var window2Hash = new Hash(text, pattern2.Length);
//
//                var pattern1Occurrences = 0;
//                var pattern2Occurrences = 0;
//                var t1 = Task.Factory.StartNew(() => pattern1Occurrences = CountOccurencesOfPattern(text, pattern1, pattern1Hash, windowHash));
//                var t2 = Task.Factory.StartNew(() => pattern2Occurrences = CountOccurencesOfPattern(text, pattern2, pattern2Hash, window2Hash));
//                Task.WaitAll(t1, t2);
//
//                res += pattern1Occurrences * pattern2Occurrences;
//            });

            var wordHash = new Hash(word);
            var textHash = new Hash(text, word.Length);
            var countWholeWord = CountOccurencesOfPattern(text, word, wordHash, textHash);
            res += countWholeWord;
            Console.WriteLine(res);
        }

        private static int CountOccurencesOfPattern(string text, string pattern, Hash patternHash, Hash windowHash)
        {
            var count = 0;
            if (patternHash.Equals(windowHash))
            {
                count++;
            }

            for (int i = 0; i < text.Length - pattern.Length; i++)
            {
                windowHash.Roll(
                    text[i + pattern.Length],
                    text[i]);

                if (patternHash.Equals(windowHash))
                {
                    count++;
                }
            }

            return count;
        }

        private static List<Tuple<string, string>> GeneratePrefixAndSuffixes(string word)
        {

            var preAndSuff = new List<Tuple<string, string>>();
            for (int i = 1; i < word.Length; i++)
            {
                var prefix = word.Substring(0, i);
                var suffix = word.Substring(i, word.Length - i);
                preAndSuff.Add(new Tuple<string, string>(prefix, suffix));
            }

            return preAndSuff;
        }
    }

    class Hash
    {
        private SingleRollingHash hash1;
        private SingleRollingHash hash2;

        public Hash(string str)
            : this(str, str.Length)
        {
        }

        public Hash(string str, int length)
        {
            this.hash1 = new SingleRollingHash(211, 1000000007, str, length);
            this.hash2 = new SingleRollingHash(359, 1000000009, str, length);
        }

        public void Roll(char right, char left)
        {
            this.hash1.Roll(right, left);
            this.hash2.Roll(right, left);
        }

        public override bool Equals(object obj)
        {
            var other = obj as Hash;
            return this.hash1.Equals(other.hash1) && this.hash2.Equals(other.hash2);
        }
    }

    class SingleRollingHash
    {
        private readonly int Base;
        private readonly int Mod;
        private readonly long BasePower;
        private long hash;

        public SingleRollingHash(int base1, int mod, string str)
            : this(base1, mod, str, str.Length)
        {
        }

        public SingleRollingHash(int base1, int mod, string str, int endIndex)
        {
            this.Base = base1;
            this.Mod = mod;

            this.BasePower = 1;
            this.hash = 0;

            for (int i = 0; i < endIndex; ++i)
            {
                this.AddRight(str[i]);
                this.BasePower = this.BasePower * this.Base % this.Mod;
            }
            // Console.WriteLine($"hash of {str.Substring(0, endIndex)} is {this.hash}");
        }

        public override bool Equals(object obj)
        {
            var other = obj as SingleRollingHash;
            return /*this.Base == other.Base && this.Mod == other.Mod &&*/ this.hash == other.hash;
        }

        public void Roll(char right, char left)
        {
            this.AddRight(right);
            this.RemoveLeft(left);
        }

        private void AddRight(char c)
        {
            this.hash = (this.hash * this.Base + c) % this.Mod;
        }

        private void RemoveLeft(char c)
        {
            this.hash = (this.Mod + this.hash - c * this.BasePower % this.Mod) % this.Mod;
        }
    }
}