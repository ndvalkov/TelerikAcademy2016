using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Wintellect.PowerCollections;

namespace Exam2016Practice
{
    // 1. Player ranking
    public class Solution
    {
        private static string input = @"add Player0 Type30 35 1
add Player1 Type26 45 2
add Player1 Type12 45 3
find Type12
ranklist 1 7
add Pencho Type12 33 2
find Type12
ranklist 1 3
end";

        private static string output = @"Added player Ivan to position 1
Added player Pesho to position 2
Added player Georgi to position 3
Added player Stamat to position 2
Added player Stamat to position 1
Type Aggressive: Ivan(20); Stamat(40); Stamat(22)
1. Stamat(40); 2. Ivan(20); 3. Stamat(22); 4. Pesho(25); 5. Georgi(30)
Added player Pencho to position 2
Type Neutral: Georgi(30); Pencho(33)
1. Stamat(40); 2. Pencho(33); 3. Ivan(20)
";

        private static Deque<Player> playerRanking = new Deque<Player>();

        static void Main()
        {
            // FakeInput();

            StringBuilder sb = new StringBuilder();
            while (true)
            {
                var line = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(line) || line == "end")
                {
                    break;
                }

                var props = line.Split(' ').ToArray();

                switch (props[0].ToLower())
                {
                    case "add":
                        var playerName = props[1];
                        var playerType = props[2];
                        var playerAge = int.Parse(props[3]);
                        var playerPosition = int.Parse(props[4]);

                        var player = new Player(playerName, playerType, playerAge);
                        if (playerPosition > playerRanking.Count + 1)
                        {
                            playerRanking.AddToBack(player);
                        }
                        else if (playerPosition == 1)
                        {
                            playerRanking.AddToFront(player);
                        }
                        else
                        {
                            playerRanking.Insert(playerPosition - 1, player);
                        }

                        sb.AppendLine(string.Format("Added player {0} to position {1}", playerName, playerPosition));
                        break;
                    case "find":
                        var playerTypeToFind = props[1];

                        var playersOfType = playerRanking
                            .Where(x => x.PLAYER_TYPE == playerTypeToFind)
                            .OrderBy(x => x.PLAYER_NAME)
                            .ThenByDescending(x => x.PLAYER_AGE)
                            .Take(5)
                            .ToList();

                        // $"{player.PLAYER_NAME}({player.PLAYER_AGE})"
                        var newSorted = playersOfType
                            .Select(x => string.Format("{0}({1})", x.PLAYER_NAME, x.PLAYER_AGE))
                            .ToList();

                        var res = string.Format("Type {0}: ", playerTypeToFind) + string.Join("; ", newSorted);
                        sb.AppendLine(res);
                        break;
                    case "ranklist":
                        var start = int.Parse(props[1]);
                        var end = int.Parse(props[2]);

                        var ranks = playerRanking.Range(start - 1, end - start + 1)
                            .Select((v, i) => string.Format("{0}. {1}({2})", i + 1, v.PLAYER_NAME, v.PLAYER_AGE))
                            .ToList();

                        sb.AppendLine(string.Join("; ", ranks));
                        break;
                }
            }

           // Console.WriteLine();
           Console.Write(sb.ToString());
           
            // File.WriteAllText("../../../test.txt", sb.ToString());
        }

        public class Player
        {
            public Player(string playerName, string playerType, int playerAge)
            {
                if (playerName.Length < 1 || playerName.Length > 20)
                {
                    throw new ArgumentException("Argument ...");
                }

                if (playerType.Length < 1 || playerType.Length > 10)
                {
                    throw new ArgumentException("Argument ...");
                }

                if (playerAge < 10 || playerAge > 50)
                {
                    throw new ArgumentException("Argument ...");
                }

                this.PLAYER_NAME = playerName;
                this.PLAYER_TYPE = playerType;
                this.PLAYER_AGE = playerAge;
            }

            public string PLAYER_NAME { get; set; }

            public string PLAYER_TYPE { get; set; }

            public int PLAYER_AGE { get; set; }

            public override string ToString()
            {
                return this.PLAYER_NAME + " " + this.PLAYER_AGE + " " + this.PLAYER_TYPE;
            }
        }

        static void FakeInput()
        {
            Console.SetIn(new StringReader(input));
        }
    }
}