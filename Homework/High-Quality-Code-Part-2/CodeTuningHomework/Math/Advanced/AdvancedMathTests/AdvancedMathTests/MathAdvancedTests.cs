namespace AdvancedMathTests
{
    using System;
    using System.Diagnostics;

    public class MathAdvancedTests
    {
        public static void Main()
        {
            var type = typeof(float);
            BenchmarkSimpleMathFor(type);
            type = typeof(double);
            // BenchmarkSimpleMathFor(type);
            type = typeof(decimal);
            // BenchmarkSimpleMathFor(type);
        }

        public static void BenchmarkSimpleMathFor(Type primitiveType)
        {
            var startValue = 5;
            var outTimes = 5;
            var iterations = 1000;

            Console.WriteLine($"----------START BENCHMARK FOR {primitiveType}---------");
            Console.WriteLine();
            Console.WriteLine($"Square {primitiveType}:");
            BenchmarkSquare(Convert.ChangeType(startValue, primitiveType), outTimes, iterations);
            Console.WriteLine("---------------");
            Console.WriteLine($"Math.Log {primitiveType}:");
            BenchmarkLog(Convert.ChangeType(startValue, primitiveType), outTimes, iterations);
            Console.WriteLine("---------------");
            Console.WriteLine($"Math.Sin {primitiveType}:");
            BenchmarkSin(Convert.ChangeType(startValue, primitiveType), outTimes, iterations);
            Console.WriteLine();
            Console.WriteLine("----------END---------");
            Console.WriteLine();
        }

        public static void BenchmarkSin<T>(T startValue, int outTimes, int iterations)
        {
            DisplayExecutionTime(() =>
            {
                dynamic result = startValue;
                Loop(() => { result = Math.Sin(result); }, iterations);
            }, outTimes);
        }

        public static void BenchmarkLog<T>(T startValue, int outTimes, int iterations)
        {
            DisplayExecutionTime(() =>
            {
                dynamic result = startValue;
                Loop(() => { result = Math.Log(result); }, iterations);
            }, outTimes);
        }

        public static void BenchmarkSquare<T>(T startValue, int outTimes, int iterations)
        {
            DisplayExecutionTime(() =>
            {
                dynamic result = startValue;
                Loop(() => { result = FindSquareRoot(result); }, iterations);
            }, outTimes);
        }

        public static void DisplayExecutionTime(Action action, int times)
        {
            for (int i = 0; i < times; i++)
            {
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                action();
                stopwatch.Stop();
                Console.WriteLine(stopwatch.Elapsed);
            }
        }

        private static void Loop(Action action, int iterations)
        {
            for (var i = 0; i < iterations; i++)
            {
                action();
            }
        }

        public static float FindSquareRoot(float number)
        {
            float result = 0;
            float diff = 0;
            float minDiff = Math.Abs(result * result - number);
            int count = 0;
            float tempResult = 0;
            while (true)
            {
                tempResult = Convert.ToSingle(count) / 1000;
                diff = Math.Abs(tempResult * tempResult - number);
                if (diff <= minDiff)
                {
                    minDiff = diff;
                    result = tempResult;
                }
                else
                    return result;
                count++;
            }
        }

        public static double FindSquareRoot(double number)
        {
            double result = 0;
            double diff = 0;
            double minDiff = Math.Abs(result * result - number);
            int count = 0;
            double tempResult = 0;
            while (true)
            {
                tempResult = Convert.ToDouble(count) / 1000;
                diff = Math.Abs(tempResult * tempResult - number);
                if (diff <= minDiff)
                {
                    minDiff = diff;
                    result = tempResult;
                }
                else
                    return result;
                count++;
            }
        }

        public static decimal FindSquareRoot(decimal number)
        {
            decimal result = 0;
            decimal diff = 0;
            decimal minDiff = Math.Abs(result * result - number);
            int count = 0;
            decimal tempResult = 0;
            while (true)
            {
                tempResult = Convert.ToDecimal(count) / 1000;
                diff = Math.Abs(tempResult * tempResult - number);
                if (diff <= minDiff)
                {
                    minDiff = diff;
                    result = tempResult;
                }
                else
                    return result;
                count++;
            }
        }
    }
}