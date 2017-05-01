using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace AdvancedTask1
{
    class FunctionalNumeralSystem
    {
        private static readonly string[] FunctionalNumerals =
        {
            "ocaml", "haskell", "scala", "f#", "lisp", "rust", "ml",
            "clojure", "erlang", "standardml", "racket", "elm", "mercury",
            "commonlisp", "scheme", "curry"
        };

        private static readonly string[] HexLetters = {"A", "B", "C", "D", "E", "F"};
        private static readonly List<string> FunctionalNumeralsList = new List<string>(FunctionalNumerals);
        private static readonly List<string> HexLettersList = new List<string>(HexLetters);

        public static void Main()
        {
            string input = ReadInput();
            string[] funcNumbers = ParseInput(input);

            string[] hexNumbers = new string[3];
            ulong[] decNumbers = new ulong[3];

            for (int i = 0; i < funcNumbers.Length; i++)
            {
                hexNumbers[i] = ToHexString(funcNumbers[i]);
                decNumbers[i] = HexToDecimal(hexNumbers[i]);
            }

            var product = CalculateProduct(decNumbers);
            Console.WriteLine(product);
        }

        private static string[] ParseInput(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                throw new ArgumentException("Parse input cannot be null or empty");
            }

            string[] result = input.Split(new[] {", "}, StringSplitOptions.None);
            return result;
        }

        private static string ReadInput()
        {
            string input = null;

            do
            {
                input = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Please, enter some input value.");
                }
                else
                {
                    break;
                }
            } while (true);

            return input;
        }

        private static BigInteger CalculateProduct(ulong[] numbers)
        {
            if (numbers == null)
            {
                throw new ArgumentNullException("Invalid argument");
            }

            BigInteger product = numbers[0];

            for (int i = 1; i < numbers.Length; i++)
            {
                product *= numbers[i];
            }

            return product;
        }

        private static string ToHexString(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Invalid argument");
            }

            StringBuilder sb = new StringBuilder();
            string result = string.Empty;

            for (int i = 0; i < value.Length; i++)
            {
                sb.Append(value[i]);
                string currentValue = sb.ToString();
                int currentIndex = FunctionalNumeralsList.IndexOf(currentValue);

                if (currentIndex >= 0)
                {
                    if (currentIndex > 9)
                    {
                        result += HexLettersList[currentIndex - 10];
                    }
                    else
                    {
                        result += currentIndex;
                    }

                    sb.Clear();
                }
            }

            return result;
        }

        private static ulong HexToDecimal(string hex)
        {
            if (string.IsNullOrWhiteSpace(hex))
            {
                throw new ArgumentException("Invalid argument");
            }

            string hexChars = "0123456789ABCDEF";
            hex = hex.ToUpper();

            ulong result = 0;
            for (int i = 0; i < hex.Length; i++)
            {
                result += (ulong) hexChars.IndexOf(hex[i]) << ((hex.Length - 1 - i) * 4);
            }

            return result;
        }
    }
}