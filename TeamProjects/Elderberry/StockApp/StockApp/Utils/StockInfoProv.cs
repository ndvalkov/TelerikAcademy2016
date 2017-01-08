using System;
using System.Collections.Generic;
using System.Net;
using System.Windows.Forms;

namespace StockApp.Utils
{
    static class StockInfoProv
    {
        // http://stackoverflow.com/questions/27794418/free-json-formatted-stock-quote-api-live-or-historical
        // For Milena: You can try with this url
        public const string TestURL = "http://www.google.com/finance/info?q=NSE:AIAENG,ATULAUTO";

        public static readonly string[] tickers = { "YHOO", "TSLA", "AMZN", "ORCL" };
        public static readonly string urlYahoo =
        $"https://query.yahooapis.com/v1/public/yql?q=select%20*%20from%20csv%20where%20url%3D'http%3A%2F%2Fdownload.finance.yahoo.com%2Fd%2Fquotes.csv%3Fs%3D{tickers[0]}%26f%3Dsl1d1t1c1ohgv%26e%3D.csv'%20and%20columns%3D'symbol%2Cprice%2Cdate%2Ctime%2Cchange%2Ccol1%2Chigh%2Clow%2Ccol2'&format=json&env=store%3A%2F%2Fdatatables.org%2Falltableswithkeys";
        public static readonly string urlTsla =
       $"https://query.yahooapis.com/v1/public/yql?q=select%20*%20from%20csv%20where%20url%3D'http%3A%2F%2Fdownload.finance.yahoo.com%2Fd%2Fquotes.csv%3Fs%3D{tickers[1]}%26f%3Dsl1d1t1c1ohgv%26e%3D.csv'%20and%20columns%3D'symbol%2Cprice%2Cdate%2Ctime%2Cchange%2Ccol1%2Chigh%2Clow%2Ccol2'&format=json&env=store%3A%2F%2Fdatatables.org%2Falltableswithkeys";
        public static readonly string urlAmzn =
               $"https://query.yahooapis.com/v1/public/yql?q=select%20*%20from%20csv%20where%20url%3D'http%3A%2F%2Fdownload.finance.yahoo.com%2Fd%2Fquotes.csv%3Fs%3D{tickers[2]}%26f%3Dsl1d1t1c1ohgv%26e%3D.csv'%20and%20columns%3D'symbol%2Cprice%2Cdate%2Ctime%2Cchange%2Ccol1%2Chigh%2Clow%2Ccol2'&format=json&env=store%3A%2F%2Fdatatables.org%2Falltableswithkeys";
        public static readonly string urlOrcl =
               $"https://query.yahooapis.com/v1/public/yql?q=select%20*%20from%20csv%20where%20url%3D'http%3A%2F%2Fdownload.finance.yahoo.com%2Fd%2Fquotes.csv%3Fs%3D{tickers[3]}%26f%3Dsl1d1t1c1ohgv%26e%3D.csv'%20and%20columns%3D'symbol%2Cprice%2Cdate%2Ctime%2Cchange%2Ccol1%2Chigh%2Clow%2Ccol2'&format=json&env=store%3A%2F%2Fdatatables.org%2Falltableswithkeys";
        
        private static string currentRecord = string.Empty;

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
            string jsonYahoo = string.Empty;
            string jsonTsla = string.Empty;
            string jsonAMZN = string.Empty;
            string jsonORCL = string.Empty;

            // string jsonTest = string.Empty;

            using (var web = new WebClient())
            {
                bool hasFailed = false;
                string msg = string.Empty;

                // TODO: Implement custom Exceptions?
                try
                {
                    // jsonTest = web.DownloadString(TestURL);

                    jsonYahoo = web.DownloadString(urlYahoo);
                    jsonTsla = web.DownloadString(urlTsla);
                    jsonAMZN = web.DownloadString(urlAmzn);
                    jsonORCL = web.DownloadString(urlOrcl);
                }
                catch (ArgumentNullException e)
                {
                    hasFailed = true;
                    msg = e.Message;
                }
                catch (WebException e)
                {
                    hasFailed = true;
                    msg = e.Message;
                }
                catch (NotSupportedException e)
                {
                    hasFailed = true;
                    msg = e.Message;
                }
                catch (Exception e)
                {
                    hasFailed = true;
                    msg = e.Message;
                }

                if (hasFailed)
                {
                    MessageBoxButtons buttons = MessageBoxButtons.OK;
                    MessageBox.Show("Unable to download Stock market info", msg, buttons);
                    return;
                }
                
                IEnumerable<string> tickers = new List<string>(new [] { jsonYahoo, jsonTsla, jsonAMZN, jsonORCL });
                BuildRecord(tickers);
            }
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