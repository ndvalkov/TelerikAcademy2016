using System;
using System.Linq;
using System.Collections.Generic;

class Tests
{
    public static void Main()
    {
        GSMTest.Init();
        GSMTest.Check_Correct_ToString();
        GSMTest.Check_Correct_IPhone4S_Info();

        GSMCallHistoryTest.Init();
        GSMCallHistoryTest.Display_Calls_Info();
        GSMCallHistoryTest.Check_Correct_Calculate_Calls();
        GSMCallHistoryTest.Check_Remove_Longest_And_Calculate_Calls();
        GSMCallHistoryTest.Check_Clear_Call_History();
    }

    private static class GSMTest
    {
        private static GSM[] testInstances;
        
        public static void Init()
        {
            testInstances = new GSM[3];
            
            testInstances[0] = new GSM("Telenor Smart", "Telenor BG");
            testInstances[1] = new GSM("Samsung Galaxy", "Samsung LTD", 223.15m);
            testInstances[2] = new GSM("Nokia", "Nokia INC", 123.45m, "Pesho Peshev");

            GSM.IPhone4S = "IPhone4S characteristics.";
        }
        
        public static void Check_Correct_ToString()
        {
            foreach (var item in testInstances)
            {
                Console.WriteLine(item.ToString());
            }
        }

        public static void Check_Correct_IPhone4S_Info()
        {
            Console.WriteLine(GSM.IPhone4S);
        }
    }

    private static class GSMCallHistoryTest
    {
        private static GSM testInstance;

        public static void Init()
        {
            testInstance = new GSM("Nokia", "Nokia INC", 123.45m, "Pesho Peshev");
            GSM.IPhone4S = "IPhone4S characteristics.";

            testInstance.AddCall(new Call("0894121212", 233));
            testInstance.AddCall(new Call("0898121555", 2333));
            testInstance.AddCall(new Call("0897121265", 12));
        }

        public static void Display_Calls_Info()
        {
            testInstance.PrintHistory();
        }

        public static void Check_Correct_Calculate_Calls()
        {
            decimal pricePerMinute = 0.37m;
            decimal result = testInstance.CalculateTotalPriceOfCalls(pricePerMinute);
            Console.WriteLine(Math.Round(result, 2));
        }

        public static void Check_Remove_And_Calculate_Calls()
        {
            decimal pricePerMinute = 0.37m;
            decimal result = testInstance.CalculateTotalPriceOfCalls(pricePerMinute);
            Console.WriteLine(Math.Round(result, 2));
        }

        public static void Check_Remove_Longest_And_Calculate_Calls()
        {
            List<Call> callHistory = testInstance.CallHistory;

            var item = callHistory.OrderBy(e => e.DurationInSeconds).Last();
            var pos = testInstance.CallHistory.IndexOf(item);

            testInstance.DeleteCallAtPosition(pos);

            Check_Correct_Calculate_Calls();
        }

        public static void Check_Clear_Call_History()
        {
            testInstance.ClearHistory();
            testInstance.PrintHistory();
        }
    }
}