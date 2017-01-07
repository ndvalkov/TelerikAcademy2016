namespace StockApp.Utils
{
    public class HttpClient
    {
        private static System.Net.Http.HttpClient instance;

        private HttpClient() { }

        public static System.Net.Http.HttpClient Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new System.Net.Http.HttpClient();
                }
                return instance;
            }
        }
    }
}
