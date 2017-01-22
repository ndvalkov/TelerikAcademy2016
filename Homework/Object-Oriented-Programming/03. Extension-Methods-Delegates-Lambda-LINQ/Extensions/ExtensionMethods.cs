using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Extensions
{
    public static class ExtensionMethods
    {
        public static string Print<T>(this IEnumerable<T> list, string separator = ", ")
        {
            return string.Join(separator, list);
        }

        public static string SubString(this StringBuilder sb, int index, int length)
        {
            return sb.ToString().Substring(index, length);
        }

        public static T Sum<T>(this IEnumerable<T> list)
            where T : struct
        {
            if (!list.Any())
            {
                throw new InvalidOperationException("Cannot find sum of an empty list");
            }

            var sum = Convert.ToDecimal(default(T));
            var result = default(T);

            try
            {
                foreach (var item in list)
                {
                    decimal current = Convert.ToDecimal(item);
                    sum = checked(sum + current);
                }

                result = (T) (dynamic) sum;
            }
            catch (OverflowException e)
            {
                Console.WriteLine(e.Message);
            }

            return result;
        }

        public static T Product<T>(this IEnumerable<T> list)
            where T : struct
        {
            if (!list.Any())
            {
                throw new InvalidOperationException("Cannot find product of an empty list");
            }

            var product = 1m;
            var result = default(T);

            try
            {
                foreach (var item in list)
                {
                    decimal current = Convert.ToDecimal(item);
                    product = checked(product * current);
                }

                result = (T) (dynamic) product;
            }
            catch (OverflowException e)
            {
                Console.WriteLine(e.Message);
            }

            return result;
        }

        public static T Min<T>(this IEnumerable<T> list)
            where T : struct, IComparable<T>
        {
            if (!list.Any())
            {
                throw new InvalidOperationException("Cannot find min value of an empty list");
            }

            T min = (T) (dynamic) double.MaxValue;

            foreach (var item in list)
            {
                if (item.CompareTo(min) < 0)
                {
                    min = item;
                }
            }

            return min;
        }

        public static T Max<T>(this IEnumerable<T> list)
            where T : struct, IComparable<T>
        {
            if (!list.Any())
            {
                throw new InvalidOperationException("Cannot find max value of an empty list");
            }

            T max = (T) (dynamic) double.MinValue;

            foreach (var item in list)
            {
                if (item.CompareTo(max) > 0)
                {
                    max = item;
                }
            }

            return max;
        }

        public static T Average<T>(this IEnumerable<T> list)
            where T : struct
        {
            if (!list.Any())
            {
                throw new InvalidOperationException("Cannot find average value of an empty list");
            }

            var sum = Convert.ToDouble(default(T));

            foreach (var item in list)
            {
                double current = Convert.ToDouble(item);
                sum += current;
            }

            return (T) (dynamic) (sum / list.Count());
        }

        public static Person[] SortFirstNameBeforeLast(this Person[] list)
        {
            return list
                .Where(person => string.Compare(person.FirstName,
                                     person.LastName,
                                     StringComparison.Ordinal) < 0)
                .ToArray();
        }
    }
}