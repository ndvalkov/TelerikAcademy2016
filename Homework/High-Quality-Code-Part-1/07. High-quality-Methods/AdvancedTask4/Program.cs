using System;

namespace AdvancedTask4
{
    class PeshoCode
    {
        private const char STATEMENT_SYMBOL = '.';
        private const char QUESTION_SYMBOL = '?';
        private const char SPACE_SYMBOL = ' ';

        private static int signPosition;

        private enum SentenceType
        {
            None,
            Statement,
            Question
        }

        public static void Main()
        {
            var word = ReadInput();
            var linesInput = ReadInput();
            var numberOfLines = ParseInt(linesInput);

            string[] lines = new string[numberOfLines];

            for (var i = 0; i < numberOfLines; i++)
            {
                lines[i] = ReadInput();
            }

            var text = string.Join("\n", lines);
            var wordPosition = text.IndexOf(word, StringComparison.Ordinal);
            var sentenceType = DetectType(wordPosition, text);
            var sum = CalculateSum(text, word, wordPosition, sentenceType);

            Console.WriteLine(sum);
        }

        private static ulong CalculateSum(string text, string word,
            int wordPosition, SentenceType sentenceType)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                throw new ArgumentException("The text parameter cannot be null or empty");
            }

            if (string.IsNullOrWhiteSpace(word))
            {
                throw new ArgumentException("The word parameter cannot be null or empty");
            }

            var sum = 0UL;

            if (sentenceType == SentenceType.Question)
            {
                for (var i = wordPosition + word.Length; i < signPosition; i++)
                {
                    if (text[i] == SPACE_SYMBOL)
                    {
                        continue;
                    }

                    sum += char.ToUpper(text[i]);
                }
            }
            else if (sentenceType == SentenceType.Statement)
            {
                int currentPos = wordPosition - 1;
                int beginPos;

                while (true)
                {
                    if (char.IsUpper(text[currentPos]))
                    {
                        beginPos = currentPos;
                        break;
                    }
                    currentPos--;
                }

                for (var i = beginPos; i < wordPosition; i++)
                {
                    if (text[i] == SPACE_SYMBOL)
                    {
                        continue;
                    }

                    sum += char.ToUpper(text[i]);
                }
            }
            else
            {
                throw new InvalidOperationException("Cannot calculate sum for a missing sentence type");
            }

            return sum;
        }

        private static int ParseInt(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                throw new ArgumentException("Parse input cannot be null or empty");
            }

            try
            {
                var result = int.Parse(input);
                return result;
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid format of the input");
                throw;
            }
            catch (OverflowException)
            {
                Console.WriteLine("The number is too big");
                throw;
            }
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

        private static SentenceType DetectType(int wordPosition, string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                throw new ArgumentException("Text cannot be null or empty");
            }

            var sentenceType = SentenceType.None;

            while (wordPosition < text.Length)
            {
                if (text[wordPosition] == STATEMENT_SYMBOL)
                {
                    signPosition = wordPosition;
                    sentenceType = SentenceType.Statement;
                }

                if (text[wordPosition] == QUESTION_SYMBOL)
                {
                    signPosition = wordPosition;
                    sentenceType = SentenceType.Question;
                }

                wordPosition++;
            }

            return sentenceType;
        }
    }
}