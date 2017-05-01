using System;
using System.Collections.Generic;

namespace AdvancedTask2
{
    public class Dealer
    {
        private const string CARDS = "23456789TJQKA";
        private const string SIGNS = "cdhs";
        private const int CARDS_IN_A_DECK = 52;
        private const string FULL_MESSAGE = "Full deck";
        private const string WA_MESSAGE = "Wa wa!";

        private static readonly List<string> Deck = new List<string>();

        private static long wholeDeckMask = 0;
        private static long evenMask = 0;

        public static void Main()
        {
            GenerateDeck();

            var input = ReadInput();
            var numberOfHands = ParseInt(input);

            for (var i = 0; i < numberOfHands; i++)
            {
                var currentInput = ReadInput();
                var currentHand = ParseLong(currentInput);
                wholeDeckMask = currentHand | wholeDeckMask;
                evenMask = evenMask ^ (wholeDeckMask & currentHand);
            }

            var isWholeDeck = CheckWholeDeck(wholeDeckMask);
            var maskStr = Convert.ToString(evenMask, 2);

            PrintFinalMessage(isWholeDeck);
            PrintEvenCards(maskStr);
        }

        private static void PrintFinalMessage(bool isWholeDeck)
        {
            Console.WriteLine(isWholeDeck ? FULL_MESSAGE : WA_MESSAGE);
        }

        private static long ParseLong(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                throw new ArgumentException("Parse input cannot be null or empty");
            }

            try
            {
                var result = long.Parse(input);
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

        private static void PrintEvenCards(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Parse input cannot be null or empty");
            }

            var evenCards = new List<string>();

            for (var i = value.Length - 1; i >= 0; i--)
            {
                if (value[i] == '0')
                {
                    evenCards.Add(Deck[52 - i - 1]);
                }
            }

            Console.WriteLine(string.Join(" ", evenCards));
        }

        private static bool CheckWholeDeck(long maskWhole)
        {
            string setBits = new string('1', 52);
            return Convert.ToString(maskWhole, 2) == setBits;
        }

        private static void GenerateDeck()
        {
            int cardsLength = CARDS.Length;
            int currentCardIndex = 0;
            int currentSignIndex = 0;

            for (int i = 0; i < CARDS_IN_A_DECK; i++)
            {
                if (currentCardIndex == cardsLength)
                {
                    currentCardIndex = 0;
                    currentSignIndex++;
                }

                Deck.Add(string.Empty + CARDS[currentCardIndex] + SIGNS[currentSignIndex]);

                currentCardIndex++;
            }
        }
    }
}