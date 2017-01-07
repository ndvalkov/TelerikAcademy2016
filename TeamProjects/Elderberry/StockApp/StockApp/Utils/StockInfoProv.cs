using System;
using System.Net;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;

namespace StockApp.Utils
{
    class StockInfoProv
    {
        public static readonly string[] tickers = { "YHOO", "TSLA", "AMZN", "ORCL" };
        public static readonly string urlYahoo =
        $"https://query.yahooapis.com/v1/public/yql?q=select%20*%20from%20csv%20where%20url%3D'http%3A%2F%2Fdownload.finance.yahoo.com%2Fd%2Fquotes.csv%3Fs%3D{tickers[0]}%26f%3Dsl1d1t1c1ohgv%26e%3D.csv'%20and%20columns%3D'symbol%2Cprice%2Cdate%2Ctime%2Cchange%2Ccol1%2Chigh%2Clow%2Ccol2'&format=json&env=store%3A%2F%2Fdatatables.org%2Falltableswithkeys";
        public static readonly string urlTsla =
       $"https://query.yahooapis.com/v1/public/yql?q=select%20*%20from%20csv%20where%20url%3D'http%3A%2F%2Fdownload.finance.yahoo.com%2Fd%2Fquotes.csv%3Fs%3D{tickers[1]}%26f%3Dsl1d1t1c1ohgv%26e%3D.csv'%20and%20columns%3D'symbol%2Cprice%2Cdate%2Ctime%2Cchange%2Ccol1%2Chigh%2Clow%2Ccol2'&format=json&env=store%3A%2F%2Fdatatables.org%2Falltableswithkeys";
        public static readonly string urlAmzn =
               $"https://query.yahooapis.com/v1/public/yql?q=select%20*%20from%20csv%20where%20url%3D'http%3A%2F%2Fdownload.finance.yahoo.com%2Fd%2Fquotes.csv%3Fs%3D{tickers[2]}%26f%3Dsl1d1t1c1ohgv%26e%3D.csv'%20and%20columns%3D'symbol%2Cprice%2Cdate%2Ctime%2Cchange%2Ccol1%2Chigh%2Clow%2Ccol2'&format=json&env=store%3A%2F%2Fdatatables.org%2Falltableswithkeys";
        public static readonly string urlOrcl =
               $"https://query.yahooapis.com/v1/public/yql?q=select%20*%20from%20csv%20where%20url%3D'http%3A%2F%2Fdownload.finance.yahoo.com%2Fd%2Fquotes.csv%3Fs%3D{tickers[3]}%26f%3Dsl1d1t1c1ohgv%26e%3D.csv'%20and%20columns%3D'symbol%2Cprice%2Cdate%2Ctime%2Cchange%2Ccol1%2Chigh%2Clow%2Ccol2'&format=json&env=store%3A%2F%2Fdatatables.org%2Falltableswithkeys";

        public static void Start()
        {
            string jsonYahoo = string.Empty;
            string jsonTsla = string.Empty;
            string jsonAMZN = string.Empty;
            string jsonORCL = string.Empty;

            using (var web = new WebClient())
            {
                // TODO: Implement custom Exceptions?
                try
                {
                    jsonYahoo = web.DownloadString(urlYahoo);
                    jsonTsla = web.DownloadString(urlTsla);
                    jsonAMZN = web.DownloadString(urlAmzn);
                    jsonORCL = web.DownloadString(urlOrcl);
                }
                catch (ArgumentNullException e)
                {
                    // TODO: Refactor
                    MessageBoxButtons buttons = MessageBoxButtons.OK;
                    MessageBox.Show("Unable to download Stock market info", "", buttons);
                    return;
                }
                catch (WebException e)
                {
                    MessageBoxButtons buttons = MessageBoxButtons.OK;
                    MessageBox.Show("Unable to download Stock market info", "", buttons);
                    return;
                }
                catch (NotSupportedException e)
                {
                    MessageBoxButtons buttons = MessageBoxButtons.OK;
                    MessageBox.Show("Unable to download Stock market info", "", buttons);
                    return;
                }
                catch (Exception e)
                {
                    MessageBoxButtons buttons = MessageBoxButtons.OK;
                    MessageBox.Show("Unable to download Stock market info", "", buttons);
                    return;
                }
            }


            // Google adds a comment before the json for some unknown reason, so we need to remove it
            // jsonYahoo = jsonYahoo.Replace("//", "");

            // TODO: Make use of the populated objects
            var parsedObject1 = JArray.Parse("[" + jsonYahoo + "]");
            var parsedObject2 = JArray.Parse("[" + jsonTsla + "]");
            var parsedObject3 = JArray.Parse("[" + jsonAMZN + "]");
            var parsedObject4 = JArray.Parse("[" + jsonORCL + "]");

            /*foreach (var i in v)
            {
                var ticker = i.SelectToken("t");
                var price = (decimal)i.SelectToken("l");

                Console.WriteLine($"{ticker} : {price}");
            }*/
        }
    }
}