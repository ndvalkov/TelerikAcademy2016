using WorkshopXMLAndJSON.Contracts;
using WorkshopXMLAndJSON.Models.Enum;

namespace WorkshopXMLAndJSON.Models
{
    public class Car : ICar
    {
        public string Model { get; set; }

        public IDealer Dealer { get; set; }

        public IManufacturer Manufaturer { get; set; }

        public decimal Price { get; set; }

        public Transmission TransmissionType { get; set; }

        public int Year { get; set; }

        public override string ToString()
        {
            return $@"
Model: {this.Model}
Transmission: {this.TransmissionType}
Price: {this.Price}
";
        }
    }
}