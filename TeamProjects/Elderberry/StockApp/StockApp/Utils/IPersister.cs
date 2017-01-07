namespace StockApp.Utils
{
    interface IPersister
    {
        void AddRecord(string record);
        void ClearRecords();
        string GetRecords();
    }
}
