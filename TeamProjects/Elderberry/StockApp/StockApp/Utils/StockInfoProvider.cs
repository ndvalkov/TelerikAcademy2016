using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace StockApp.Utils
{
    // TODO: Remove class, use the other provider
    public static class StockInfoProvider
    {
        // http://stackoverflow.com/questions/38355075/has-yahoo-finance-web-service-disappeared-api-changed-down-temporarily --> last comment
        private const string StockInfoPath =
            @"https://query.yahooapis.com/v1/public/yql?q=select%20*%20from%20csv%20where%20url%3D'http%3A%2F%2Fdownload.finance.yahoo.com%2Fd%2Fquotes.csv%3Fs%3DACA.PA%26f%3Dsl1d1t1c1ohgv%26e%3D.csv'%20and%20columns%3D'symbol%2Cprice%2Cdate%2Ctime%2Cchange%2Ccol1%2Chigh%2Clow%2Ccol2'&format=json&env=store%3A%2F%2Fdatatables.org%2Falltableswithkeys";

        public static void Start()
        {
            RunAsync().Wait();
        }

        public static async Task RunAsync()
        {
            var client = HttpClient.Instance;
            client.BaseAddress = new Uri(StockInfoPath);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                StockInfo stockInfo = await GetProductAsync(StockInfoPath);

                Console.WriteLine(stockInfo);
            }
            catch (Exception e)
            {
                // TODO: Implement custom Exception
                Console.WriteLine(e.Message);
            }
        }

        static async Task<StockInfo> GetProductAsync(string path)
        {
            StockInfo stock = null;
            HttpResponseMessage response = await HttpClient.Instance.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                stock = await response.Content.ReadAsAsync<StockInfo>();
            }
            return stock;
        }
    }
}
