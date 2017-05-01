using System;
using System.Linq;

namespace VariablesHomework
{
    public class Statistics
    {
        /// <summary>
        /// From a given array of double values calculates the aggregate values min, max, and average on
        /// a subrange starting from the start and with length equal to the parameter fromStart.
        /// Prints the results.
        /// </summary>
        /// <param name="numbers">A <see cref="double"/> array representing the target array of numbers.</param>
        /// <param name="fromStart">A <see cref="int"/> representing the count of numbers from the start.</param>
        public void PrintAggregates(double[] numbers, int fromStart)
        {
            if (numbers == null)
            {
                throw new ArgumentNullException("Invalid argument");
            }

            if (fromStart < 0 || fromStart > numbers.Length)
            {
                throw new ArgumentOutOfRangeException("Invalid argument range");
            }

            double[] subrange = GetSubrange(numbers, 0, fromStart);

            Print(subrange.Max());
            Print(subrange.Min());
            Print(subrange.Average());
        }

        protected internal double[] GetSubrange(double[] numbers, int start, int count)
        {
            if (numbers == null)
            {
                throw new ArgumentNullException("Invalid argument");
            }

            if (start < 0 || count < 0 || count > numbers.Length ||
                (numbers.Length - start < count))
            {
                throw new ArgumentOutOfRangeException("Invalid argument range");
            }

            double[] subrange = numbers
                .ToList()
                .GetRange(start, count)
                .ToArray();

            return subrange;
        }

        private void Print(double value)
        {
            Console.WriteLine(value);
        }
    }
}