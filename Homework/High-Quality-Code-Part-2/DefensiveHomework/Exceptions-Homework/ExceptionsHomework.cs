namespace Exceptions_Homework
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class ExceptionsHomework
    {
        public static void Main()
        {
            try
            {
                var substr = Subsequence("Hello!".ToCharArray(), 2, 3);
                Console.WriteLine(substr);

                var subarr = Subsequence(new int[] { -1, 3, 2, 1 }, 0, 2);
                Console.WriteLine(string.Join(" ", subarr));

                var allarr = Subsequence(new int[] { -1, 3, 2, 1 }, 0, 4);
                Console.WriteLine(string.Join(" ", allarr));

                var emptyarr = Subsequence(new int[] { -1, 3, 2, 1 }, 0, 0);
                Console.WriteLine(string.Join(" ", emptyarr));

                Console.WriteLine(ExtractEnding("I love C#", 2));
                Console.WriteLine(ExtractEnding("Nakov", 4));
                Console.WriteLine(ExtractEnding("beer", 4));
                // Console.WriteLine(ExtractEnding("Hi", 100));

                bool is23Prime = CheckPrime(23);
                Console.WriteLine(is23Prime ? "23 is prime." : "23 is not prime.");
                bool is33Prime = CheckPrime(33);
                Console.WriteLine(is33Prime ? "33 is prime." : "33 is not prime.");

                List<Exam> peterExams = new List<Exam>()
                {
                    new SimpleMathExam(2),
                    new CSharpExam(55),
                    new CSharpExam(100),
                    new SimpleMathExam(1),
                    new CSharpExam(0),
                };
                Student peter = new Student("Peter", "Petrov", peterExams);
                double peterAverageResult = peter.CalcAverageExamResultInPercents();
                Console.WriteLine("Average results = {0:p0}", peterAverageResult);
            }
            catch (ArgumentNullException ex)
            {
                PrintErrorMessage(ex);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                PrintErrorMessage(ex);
            }
            catch (InvalidOperationException ex)
            {
                PrintErrorMessage(ex);
            }
            catch (Exception ex)
            {
                PrintErrorMessage(ex);
            }
        }

        public static T[] Subsequence<T>(T[] arr, int startIndex, int count)
        {
            if (arr == null)
            {
                throw new ArgumentNullException("Argument arr cannot be null");
            }

            if (startIndex < 0 || startIndex >= arr.Length)
            {
                throw new ArgumentOutOfRangeException("Invalid start index");
            }

            if (count < 0 || count > arr.Length - startIndex)
            {
                throw new ArgumentOutOfRangeException("Invalid count");
            }

            List<T> result = new List<T>();
            for (int i = startIndex; i < startIndex + count; i++)
            {
                if (arr[i] == null)
                {
                    throw new InvalidOperationException("Elements of the array should not be null");
                }

                result.Add(arr[i]);
            }

            return result.ToArray();
        }

        public static string ExtractEnding(string str, int count)
        {
            if (str == null)
            {
                throw new ArgumentNullException("Str cannot be null");
            }

            if (count < 0 || count > str.Length)
            {
                throw new ArgumentOutOfRangeException("Invalid count");
            }

            StringBuilder result = new StringBuilder();
            for (int i = str.Length - count; i < str.Length; i++)
            {
                result.Append(str[i]);
            }

            return result.ToString();
        }

        public static bool CheckPrime(int number)
        {
            bool isPrime = true;

            if (number < 2)
            {
                return !isPrime;
            }

            for (int divisor = 2; divisor <= Math.Sqrt(number); divisor++)
            {
                if (number % divisor == 0)
                {
                    isPrime = false;
                    break;
                }
            }

            return isPrime;
        }

        private static void PrintErrorMessage(Exception ex)
        {
            Console.WriteLine($"-------------");
            Console.WriteLine($"Calculation failed: \r\n{ex.Message}");
            Console.WriteLine($"-------------");
            Console.WriteLine(ex.StackTrace);
        }
    }
}