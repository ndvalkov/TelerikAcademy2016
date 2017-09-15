using System;
using System.Collections.Generic;
using WorkshopXMLAndJSON.Models.Enum;

namespace WorkshopXMLAndJSON.Models.Json
{
    public class CarJsonModel
    {
        public int Year { get; set; }

        public Transmission TransmissionType { get; set; }

        public string ManufacturerName { get; set; }

        public string Model { get; set; }

        public decimal Price { get; set; }

        public DealerJsonModel Dealer { get; set; }

        public static Func<CarJsonModel, Car> FromJsonModel
        {
            get
            {
                return jsomModel => new Car
                {
                    Model = jsomModel.Model,
                    Dealer = new Dealer
                    {
                        Name = jsomModel.Dealer.Name,
                        Cities = new List<City> { new City { Name = jsomModel.Dealer.City } }
                    },
                    Manufaturer = new Manufacturer
                    {
                        Name = jsomModel.ManufacturerName
                    },
                    Price = jsomModel.Price,
                    TransmissionType = jsomModel.TransmissionType,
                    Year = jsomModel.Year
                };
            }
        }

        
    }
}