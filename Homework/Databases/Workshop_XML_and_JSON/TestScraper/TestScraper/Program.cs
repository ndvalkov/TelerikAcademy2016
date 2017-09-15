using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace TestScraper
{
    class Program
    {
        static void Main(string[] args)
        {
            var scraper = new IMDb("Shaw");
            Console.WriteLine(scraper.Directors);
        }
    }
}
