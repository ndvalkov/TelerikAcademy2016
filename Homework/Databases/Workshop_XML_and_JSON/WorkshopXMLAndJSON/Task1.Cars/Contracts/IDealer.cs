using System.Collections.Generic;

namespace WorkshopXMLAndJSON.Contracts
{
    public interface IDealer
    {
        IEnumerable<ICity> Cities { get; set; }

        string Name { get; set; }
    }
}