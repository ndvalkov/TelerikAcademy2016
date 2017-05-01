namespace MathSimpleHomework
{
    using System;
    using System.Diagnostics;
    using System.Net;

    public class MathSimpleTest
    {
        public static void Main()
        {
            var type = typeof(int);
            BenchmarkSimpleMathFor(type);
            type = typeof(long);
            // BenchmarkSimpleMathFor(type);
            type = typeof(float);
            // BenchmarkSimpleMathFor(type);
            type = typeof(double);
            // BenchmarkSimpleMathFor(type);
            type = typeof(decimal);
            // BenchmarkSimpleMathFor(type);
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

        public static void BenchmarkSimpleMathFor(Type primitiveType)
        {
            var startValue = 5;
            var outTimes = 5;
            var iterations = 1000;

            Console.WriteLine($"----------START BENCHMARK FOR {primitiveType}---------");
            Console.WriteLine();
            Console.WriteLine($"Add {primitiveType}:");
            BenchmarkAdd(Convert.ChangeType(startValue, primitiveType), outTimes, iterations);
            Console.WriteLine("---------------");
            Console.WriteLine($"Subtract {primitiveType}:");
            BenchmarkSubtract(Convert.ChangeType(startValue, primitiveType), outTimes, iterations);
            Console.WriteLine("---------------");
            Console.WriteLine($"Increment {primitiveType}:");
            BenchmarkIncrement(Convert.ChangeType(startValue, primitiveType), outTimes, iterations);
            Console.WriteLine("---------------");
            Console.WriteLine($"Multiply {primitiveType}:");
            BenchmarkMultiply(Convert.ChangeType(startValue, primitiveType), outTimes, iterations);
            Console.WriteLine("---------------");
            Console.WriteLine($"Divide {primitiveType}:");
            BenchmarkMultiply(Convert.ChangeType(startValue, primitiveType), outTimes, iterations);
            Console.WriteLine();
            Console.WriteLine("----------END---------");
            Console.WriteLine();
        }

        public static void BenchmarkAdd<T>(T startValue, int outTimes, int iterations)
        {
            DisplayExecutionTime(() =>
            {
                dynamic result = startValue;
                var step = 1;
                Loop(() =>
                {
                    try
                    {
                        checked
                        {
                            result = result + step;
                            step++;
                        }

                        /*if (double.IsInfinity(result))
                        {
                            throw new ArithmeticException();
                        }*/
                    }
                    catch (OverflowException)
                    {
                        result = startValue;
                        step = 1;
                    }
                    catch (ArithmeticException)
                    {
                        result = startValue;
                        step = 1;
                    }
                }, iterations);
            }, outTimes);
        }

        public static void BenchmarkSubtract<T>(T startValue, int outTimes, int iterations)
        {
            DisplayExecutionTime(() =>
            {
                dynamic result = startValue;
                var step = 1;
                Loop(() =>
                {
                    try
                    {
                        checked
                        {
                            result = result - step;
                            step++;
                        }
                    }
                    catch (OverflowException)
                    {
                        result = startValue;
                        step = 1;
                    }
                }, iterations);
            }, outTimes);
        }

        public static void BenchmarkIncrement<T>(T startValue, int outTimes, int iterations)
        {
            DisplayExecutionTime(() =>
            {
                dynamic result = startValue;
                Loop(() => { result++; }, iterations);
            }, outTimes);
        }

        public static void BenchmarkMultiply<T>(T startValue, int outTimes, int iterations)
        {
            DisplayExecutionTime(() =>
            {
                dynamic result = startValue;
                var step = 1;
                Loop(() =>
                {
                    try
                    {
                        checked
                        {
                            result = result * step;
                            step++;
                        }
                    }
                    catch (OverflowException)
                    {
                        result = startValue;
                    }
                }, iterations);
            }, outTimes);
        }

        public static void BenchmarkDivide<T>(T startValue, int outTimes, int iterations)
        {
            DisplayExecutionTime(() =>
            {
                dynamic result = startValue;
                var step = 1;
                Loop(() =>
                {
                    try
                    {
                        checked
                        {
                            result = result / step;
                            step++;
                        }
                    }
                    catch (OverflowException)
                    {
                        result = startValue;
                    }
                }, iterations);
            }, outTimes);
        }

        private static void Loop(Action action, int iterations)
        {
            for (var i = 0; i < iterations; i++)
            {
                action();
            }
        }
    }
}