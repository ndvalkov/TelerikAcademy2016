using System;
using Methods.Contracts;

namespace Methods.Utils
{
    public class Logger : ILogger
    {
        private const int PAD_SPACES = 8;

        public Logger()
        {
        }

        public enum Format
        {
            Standard,
            Percent,
            Padded,
            NoFormat
        }

        public void Log(double number, Format format = Format.NoFormat)
        {
            switch (format)
            {
                case Format.Standard:
                    Console.WriteLine("{0:f2}", number);
                    break;
                case Format.Percent:
                    Console.WriteLine("{0:p0}", number);
                    break;
                case Format.Padded:
                    Console.WriteLine($"{{0,{PAD_SPACES}}}", number);
                    break;
                case Format.NoFormat:
                    Console.WriteLine(number);
                    break;
                default:
                    throw new ArgumentException("Invalid argument format");
            }
        }

        public void Log(string text)
        {
            Console.WriteLine(text);
        }
    }
}