using System;

namespace VariablesHomework
{
    public class Startup
    {
        static void Main()
        {
            var stats = new Statistics();
            stats.PrintAggregates(new double[] {23, 4, 1}, 2);
            stats.PrintAggregates(new double[] {23, -2, 4, 1}, 4);
            stats.PrintAggregates(new double[] {23, 4, 1}, 1);
            // stats.PrintAggregates(new double[] {23, 4, 1}, 4);
            // stats.PrintAggregates(default(double[]), 2);
            // stats.PrintAggregates(new double[] { 23, 4, 1 }, -1);
        }
    }
}