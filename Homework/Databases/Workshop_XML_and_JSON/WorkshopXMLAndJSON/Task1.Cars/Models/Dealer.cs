using System.Collections;
using System.Collections.Generic;
using WorkshopXMLAndJSON.Contracts;

namespace WorkshopXMLAndJSON.Models
{
    public class Dealer : IDealer
    {
        public string Name { get; set; }

        public IEnumerable<ICity> Cities { get; set; }
    }
}