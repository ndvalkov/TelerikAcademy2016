using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem4
{
    class Solution
    {
        static List<string> combinations = new List<string>();
        static Expression sm = new Expression(null);

        static void Main()
        {
            var digits = string.Join(" ", Console.ReadLine().ToCharArray());
            var number = int.Parse(Console.ReadLine());
            var operators = "+-*";
            var placeholder = new StringBuilder();

            GenerateValidExpressions(digits, number, placeholder, 0);

            var validCombos = combinations.Where(x =>
                {
                    return !x.Split(new char[] { '-', '+', '*' })
                        .Any(y => !IsValidNumber(y));
                })
                .ToArray();

            Console.WriteLine(validCombos.Length);
            Console.WriteLine(string.Join("\n", validCombos));
        }

        private static bool IsValidNumber(string str)
        {
            var res = str.StartsWith("0") && str.Length > 1;
            return !res;
        }

        private static void GenerateValidExpressions(string digits, int number, StringBuilder placeholder, int index)
        {
            if (index > digits.Length - 1)
            {
                var ex = placeholder.ToString();
                var newRes = sm.ParseExpression(ex);
                if (newRes == number)
                {
                    combinations.Add(ex);
                }
                return;
            }

            if (digits[index] != ' ')
            {
                placeholder.Append(digits[index]);
                GenerateValidExpressions(digits, number, placeholder, index + 1);
                placeholder.Remove(placeholder.Length - 1, 1);
            }
            else
            {
                GenerateValidExpressions(digits, number, placeholder, index + 1);

                placeholder.Append('+');
                GenerateValidExpressions(digits, number, placeholder, index + 1);
                placeholder.Remove(placeholder.Length - 1, 1);

                placeholder.Append('-');
                GenerateValidExpressions(digits, number, placeholder, index + 1);
                placeholder.Remove(placeholder.Length - 1, 1);

                placeholder.Append('*');
                GenerateValidExpressions(digits, number, placeholder, index + 1);

                placeholder.Remove(placeholder.Length - 1, 1);
            }
        }
    }

    class Expression
    {
        private string program;
        private int index;
        private Dictionary<string, double> variables;
        private StringBuilder output;

        public Expression(string program)
        {
            this.program = program;
            this.index = 0;
            this.variables = new Dictionary<string, double>();
            this.output = new StringBuilder();
        }

        public void Eval()
        {
            try
            {
                this.program
                    .Split('\n')
                    .Select(line => line.Trim())
                    .ToList()
                    .ForEach(line =>
                    {
                        if (string.IsNullOrWhiteSpace(line))
                        {
                            return;
                        }

                        this.index = 0;
                        this.ParseExpression(line);
                    });
            }
            catch (Exception ex)
            {
                this.output.AppendLine(ex.Message);
            }

            Console.WriteLine(this.output.ToString());
        }

        public double ParseExpression(string str)
        {
            Func<string, double> parseFunc = this.ParseAssignment;

            this.index = 0;
            var result = parseFunc(str);
            if (index < str.Length)
            {
                throw new ArgumentException("Unexpected {str[index]} at index {index}.");
            }
            return result;
        }

        private double ParseParentheses(string str)
        {
            Func<string, double> parseFunc = this.ParseAssignment;

            SkipWhiteSpace(str);
            if (str[index] == '(')
            {
                ++index;
                var result = parseFunc(str);
                SkipWhiteSpace(str);
                if (str[index] != ')')
                {
                    throw new ArgumentException("No matching ) for ( at index {index}.");
                }
                ++index;
                return result;
            }
            else if (str[index] == '[')
            {
                ++index;
                var result = Math.Floor(parseFunc(str));
                SkipWhiteSpace(str);
                if (str[index] != ']')
                {
                    throw new ArgumentException("No matching ] for [ at index {index}.");
                }
                ++index;
                return result;
            }
            else if (str[index] == '|')
            {
                ++index;
                var result = Math.Abs(parseFunc(str));
                SkipWhiteSpace(str);
                if (str[index] != '|')
                {
                    throw new ArgumentException("No matching | for | at index {index}.");
                }
                ++index;
                return result;
            }
            else // functions
            {
                if (index + 5 < str.Length && str.Substring(index, 5) == "print")
                {
                    index += 5;
                    SkipWhiteSpace(str);
                    if (str[index] == '(')
                    {
                        var paramList = new List<string>();
                        do
                        {
                            ++index;
                            SkipWhiteSpace(str);
                            if (str[index] == ')')
                            {
                                break;
                            }
                            var stringValue = this.ParseString(str) ?? parseFunc(str).ToString();
                            paramList.Add(stringValue);
                            SkipWhiteSpace(str);
                        } while (str[index] == ',');

                        if (str[index] != ')')
                        {
                            throw new ArgumentException("No matching ) for ( at index {index}.");
                        }
                        ++index;
                        this.output.AppendLine(string.Join(" ", paramList));
                        return 0;
                    }
                }
                if (index + 10 < str.Length && str.Substring(index, 10) == "readNumber")
                {
                    index += 10;
                    SkipWhiteSpace(str);
                    if (str[index] != '(')
                    {
                        throw new ArgumentException("Expected ( at index {index}");
                    }
                    ++index;
                    SkipWhiteSpace(str);
                    if (str[index] != ')')
                    {
                        throw new ArgumentException("Expected ) at index {index}");
                    }
                    SkipWhiteSpace(str);
                    ++index;

                    Console.WriteLine(this.output.ToString());
                    this.output.Clear();
                    var number = double.Parse(Console.ReadLine());
                    return number;
                }
                if (index + 4 < str.Length && str.Substring(index, 4) == "sqrt")
                {
                    index += 4;
                    SkipWhiteSpace(str);
                    if (str[index] == '(')
                    {
                        ++index;
                        var result = Math.Sqrt(parseFunc(str));
                        if (str[index] != ')')
                        {
                            throw new ArgumentException("No matching ) for ( at index {index}.");
                        }
                        ++index;
                        return result;
                    }
                }
                if (index + 3 < str.Length && str.Substring(index, 3) == "log")
                {
                    index += 3;
                    SkipWhiteSpace(str);
                    if (str[index] == '(')
                    {
                        ++index;
                        var a = parseFunc(str);
                        SkipWhiteSpace(str);
                        if (str[index] != ',')
                        {
                            if (str[index] != ')')
                            {
                                throw new ArgumentException("Expected ,");
                            }
                            ++index;
                            return Math.Log(a, 10);
                        }
                        ++index;
                        var newBase = parseFunc(str);
                        SkipWhiteSpace(str);
                        if (str[index] != ')')
                        {
                            throw new ArgumentException("No matching ) for ( at index {index}.");
                        }
                        ++index;
                        return Math.Log(a, newBase);
                    }
                }
            }

            var variable = this.ParseVariable(str);

            if (variable == null)
            {
                return this.ParseNumber(str);
            }

            return this.variables[variable];
        }

        private double ParsePower(string str)
        {
            Func<string, double> parseFunc = this.ParseParentheses;

            var result = parseFunc(str);
            SkipWhiteSpace(str);
            if (index < str.Length)
            {
                if (str[index] == '^')
                {
                    ++index;
                    result = Math.Pow(result, this.ParsePower(str));
                    SkipWhiteSpace(str);
                }
                else if (index + 1 < str.Length && str[index] == '*' && str[index + 1] == '*')
                {
                    index += 2;
                    result = Math.Pow(result, parseFunc(str));
                    SkipWhiteSpace(str);
                }
            }
            return result;
        }

        private double ParseMultiplication(string str)
        {
            Func<string, double> parseFunc = this.ParsePower;

            var result = parseFunc(str);
            SkipWhiteSpace(str);
            while (index < str.Length)
            {
                if (str[index] == '*')
                {
                    ++index;
                    result *= parseFunc(str);
                    SkipWhiteSpace(str);
                }
                else if (str[index] == '/')
                {
                    ++index;
                    result /= parseFunc(str);
                    SkipWhiteSpace(str);
                }
                else
                {
                    break;
                }
            }

            return result;
        }

        private double ParseSum(string str)
        {
            Func<string, double> parseFunc = this.ParseMultiplication;

            var result = parseFunc(str);
            SkipWhiteSpace(str);
            while (index < str.Length)
            {
                if (str[index] == '+')
                {
                    ++index;
                    result += parseFunc(str);
                    SkipWhiteSpace(str);
                }
                else if (str[index] == '-')
                {
                    ++index;
                    result -= parseFunc(str);
                    SkipWhiteSpace(str);
                }
                else
                {
                    break;
                }
            }

            return result;
        }

        private double ParseAssignment(string str)
        {
            this.SkipWhiteSpace(str);
            var startIndex = index;
            var variable = this.ParseVariable(str);
            if (variable == null)
            {
                return this.ParseSum(str);
            }

            this.SkipWhiteSpace(str);
            if (index >= str.Length || str[index] != '=')
            {
                this.index = startIndex;
                return this.ParseSum(str);
            }

            ++index;

            var value = this.ParseAssignment(str);

            this.variables[variable] = value;
            return value;
        }

        private double ParseNumber(string str)
        {
            SkipWhiteSpace(str);

            double number = 0;
            bool isPartial = false;
            double significance = 0.1;
            bool isNegative = false;

            if (str[index] == '-')
            {
                isNegative = true;
                ++index;
            }
            else if (str[index] == '+')
            {
                ++index;
            }

            for (; index < str.Length; ++index)
            {
                if (!isPartial)
                {
                    if (IsDigit(str[index]))
                    {
                        number *= 10;
                        number += str[index] - '0';
                    }
                    else if (str[index] == '.')
                    {
                        isPartial = true;
                    }
                    else
                    {
                        break;
                    }
                }
                else // isPartial == true
                {
                    if (IsDigit(str[index]))
                    {
                        number += (str[index] - '0') * significance;
                        significance /= 10;
                    }
                    else
                    {
                        break;
                    }
                }
            }

            if (isNegative)
            {
                return -number;
            }
            return number;
        }

        private string ParseVariable(string str)
        {
            this.SkipWhiteSpace(str);

            if (index < str.Length && !IsDigit(str[index]) && IsVariableChar(str[index]))
            {
                var startIndex = index;
                ++index;
                while (index < str.Length && IsVariableChar(str[index]))
                {
                    ++index;
                }

                return str.Substring(startIndex, index - startIndex);
            }

            return null;
        }

        private string ParseString(string str)
        {
            this.SkipWhiteSpace(str);
            if (str[index] == '"')
            {
                var endIndex = index;
                ++index;
                do
                {
                    ++endIndex;
                    endIndex = str.IndexOf('"', endIndex);
                } while (str[endIndex - 1] == '\\');

                var stringValue = str.Substring(index, endIndex - index);
                index = endIndex + 1;
                return stringValue;
            }

            return null;
        }

        private void SkipWhiteSpace(string str)
        {
            while (index < str.Length && str[index] == ' ')
            {
                ++index;
            }
        }

        private static bool IsDigit(char c)
        {
            return '0' <= c && c <= '9';
        }

        private static bool IsVariableChar(char c)
        {
            return (('0' <= c && c <= '9')
                    || ('a' <= c && c <= 'z')
                    || ('A' <= c && c <= 'Z')
                    || c == '_');
        }
    }
}