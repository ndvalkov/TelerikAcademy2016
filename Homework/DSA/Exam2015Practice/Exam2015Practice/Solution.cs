using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

namespace Exam2015Practice
{
    class Solution
    {
        private static string input = @"add TheMightyThor God 100
add Artanis Protoss 250
add Fenix Protoss 200
add Spiderman MutatedHuman 180
add XelNaga God 500
add Wolverine MutatedHuman 200
add Zeratul Protoss 300
add Spiderman MutatedHuman 180
power 3
find Protoss
find God
remove Kerrigan
remove XelNaga
power 3
find Kerrigan
find God
end
";

        public class Unit : IComparable<Unit>
        {
            public Unit(string unitName, string unitType, int unitAttack)
            {
                this.UNIT_NAME = unitName;
                this.UNIT_TYPE = unitType;
                this.UNIT_ATTACK = unitAttack;
            }

            public string UNIT_NAME { get; set; }

            public string UNIT_TYPE { get; set; }

            public int UNIT_ATTACK { get; set; }

            public int CompareTo(Unit other)
            {
                var result = other.UNIT_ATTACK.CompareTo(this.UNIT_ATTACK);
                if (result == 0)
                {
                    result = string.Compare(this.UNIT_NAME, other.UNIT_NAME, StringComparison.Ordinal);
                }

                return result;
            }

            public override string ToString()
            {
                return this.UNIT_NAME + " " + this.UNIT_TYPE + " " + this.UNIT_ATTACK;
            }
        }

        static void FakeInput()
        {
            Console.SetIn(new StringReader(input));
        }

        private static Dictionary<string, SortedSet<Unit>> unitSystemByType = new Dictionary<string, SortedSet<Unit>>();
        private static Dictionary<string, Unit> existingUnits = new Dictionary<string, Unit>();
        private static SortedSet<Unit> unitSystemByAttack = new SortedSet<Unit>();

        static void Main()
        {
            // FakeInput();

            StringBuilder sb = new StringBuilder();
            while (true)
            {
                var line = Console.ReadLine();
                if (line == "end")
                {
                    break;
                }

                var props = line.Split(' ').ToArray();

                switch (props[0].ToLower())
                {
                    case "add":
                        var un = props[1];
                        var ut = props[2];
                        var ua = int.Parse(props[3]);

                        var unit = new Unit(un, ut, ua);

                        if (existingUnits.ContainsKey(unit.UNIT_NAME))
                        {
                            sb.AppendLine(string.Format("FAIL: {0} already exists!", un));
                        }
                        else
                        {
                            if (!unitSystemByType.ContainsKey(ut))
                            {
                                unitSystemByType[ut] = new SortedSet<Unit>();
                            }

                            unitSystemByType[ut].Add(unit);
                            unitSystemByAttack.Add(unit);
                            existingUnits.Add(unit.UNIT_NAME, unit);
                            sb.AppendLine(string.Format("SUCCESS: {0} added!", un));
                        }
                        break;
                    case "remove":
                        var nameToRemove = props[1];
                        if (!existingUnits.ContainsKey(nameToRemove))
                        {
                            sb.AppendLine(string.Format("FAIL: {0} could not be found!", nameToRemove));
                        }
                        else
                        {
                            var unitToRemove = existingUnits[nameToRemove];
                            var type = unitToRemove.UNIT_TYPE;

                            unitSystemByType[type].Remove(unitToRemove);
                            unitSystemByAttack.Remove(unitToRemove);
                            existingUnits.Remove(nameToRemove);

                            sb.AppendLine(string.Format("SUCCESS: {0} removed!", nameToRemove));
                        }
                        break;
                    case "find":
                        var unitType = props[1];
                        var unitFormat = "{0}[{1}]({2})";

                        var top = new List<string>();
                        if (unitSystemByType.ContainsKey(unitType))
                        {
                            top =
                                unitSystemByType[unitType].Take(10)
                                    .Select(
                                        x =>
                                        {
                                            return string.Format(unitFormat, x.UNIT_NAME, x.UNIT_TYPE, x.UNIT_ATTACK);
                                        })
                                    .ToList();
                        }

                        sb.AppendLine(string.Format("RESULT: {0}", string.Join(", ", top)));
                        break;
                    case "power":
                        var numerOfUnits = int.Parse(props[1]);
                        var topPw = new List<string>();
                        var unitFormatP = "{0}[{1}]({2})";

                        topPw =
                            unitSystemByAttack.Take(numerOfUnits)
                                .Select(
                                    x => { return string.Format(unitFormatP, x.UNIT_NAME, x.UNIT_TYPE, x.UNIT_ATTACK); })
                                .ToList();

                        sb.AppendLine(string.Format("RESULT: {0}", string.Join(", ", topPw)));
                        break;
                }
            }

            Console.WriteLine(sb.ToString());
        }
    }
}