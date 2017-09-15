using WorkshopXMLAndJSON.Models.Enum;

namespace WorkshopXMLAndJSON.Contracts
{
    public interface ICar
    {
        IDealer Dealer { get; set; }

        IManufacturer Manufaturer { get; set; }

        string Model { get; set; }

        decimal Price { get; set; }

        Transmission TransmissionType { get; set; }

        int Year { get; set; }
    }
}