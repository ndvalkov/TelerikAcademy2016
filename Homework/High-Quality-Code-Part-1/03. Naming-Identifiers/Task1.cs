using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NamingHomework
{
    class SimpleLoggerTest
    {
        const int MAX_COUNT = 6;

        public static void Main()
        {
            SimpleLoggerTest.Logger logger =
              new SimpleLoggerTest.Logger();
            logger.Log(true);
        }

        class Logger
        {
            public void Log(bool value)
            {
                string valueToString = value.ToString();
                Console.WriteLine(valueToString);
            }
        }
    }
}
