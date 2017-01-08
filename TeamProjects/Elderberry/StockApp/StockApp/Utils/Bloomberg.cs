using System;
using System.Collections.Generic;
using unirest_net.http;

namespace StockApp.Utils
{
    static class Bloomberg
    {
        public static readonly string[] tickers = { "YHOO", "TSLA", "AMZN", "ORCL" };
        
        private static string currentRecord = String.Empty;

        public static void Start()
        {
            // Request data on first usage
            ExecuteJSONRequest();
           
            StockPersister stockPersister = StockPersister.Instance;
            stockPersister.AddRecord(currentRecord);

            // Request data on interval
            RequestTimer mt = new RequestTimer();
            mt.StartWithCallback(2000, OnTimerElapsed);
        }

        private static void ExecuteJSONRequest()
        {
            HttpResponse<string> response = Unirest.get("https://bloomberg-quote-api.p.mashape.com/quote?id=GOOG%3AUS")
            .header("X-Mashape-Key", "tlWmZMkHhbmshYg6oRZTzhREhCBMp1yPzJZjsnvqI8RZ3iKIsh")
            .header("Accept", "application/json")
            .asJson<string>();

            Console.WriteLine();

        }

        private static void BuildRecord(IEnumerable<string> tickers)
        {
            currentRecord = string.Join(Environment.NewLine, tickers);
        }

        private static void OnTimerElapsed(object sender, EventArgs eventArgs)
        {
            StockPersister stockPersister = StockPersister.Instance;
            stockPersister.AddRecord(currentRecord);
        }
    }
}
