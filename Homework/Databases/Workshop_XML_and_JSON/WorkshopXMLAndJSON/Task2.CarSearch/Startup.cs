using System.Collections.Generic;
using System.Xml.Linq;
using WorkshopXMLAndJSON.Contracts;
using WorkshopXMLAndJSON.Models;
using WorkshopXMLAndJSON.Models.Enum;

namespace Task2.CarSearch
{
    public class Startup
    {
        public static void Main()
        {
            // Seed();





        }

        private static void Seed()
        {
            var carSeed = new List<ICar>();

            for (int i = 0; i < 10; i++)
            {
                carSeed.Add(new Car()
                {
                    Model = $"{i} Skyactiv",
                    Year = 2000 + i,
                    Price = 1000m * i,
                    TransmissionType = i % 2 == 0 ? Transmission.Manual : Transmission.Automatic,
                    Manufaturer = i % 3 == 0 ? new Manufacturer() { Name = "Mazda" } : new Manufacturer() { Name = "Ferarri" },
                    Dealer = i % 4 == 0 ? new Dealer() { Name = "Auto Motor" } : new Dealer() { Name = "Peugeot LTD" }
                });
            }

            GenerateXmlData(carSeed.ToArray());
        } 

        private static void GenerateXmlData(IEnumerable<ICar> cars)
        {
            XElement root = new XElement("cars");

            foreach (var car in cars)
            {
                XElement carElement = new XElement("car",
                    new XElement("model", car.Model),
                    new XElement("price", car.Price),
                    new XElement("year", car.Year),
                    new XElement("transmissionType", car.TransmissionType),
                    new XElement("dealer", 
                        new XElement("name", car.Dealer.Name)),
                    new XElement("manufacturer",
                        new XElement("name", car.Manufaturer.Name))
                    );

                root.Add(carElement);
            }

            root.Save("../../Data/cars.xml");
        }
    }
}