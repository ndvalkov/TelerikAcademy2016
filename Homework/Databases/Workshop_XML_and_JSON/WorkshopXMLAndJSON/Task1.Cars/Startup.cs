using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WorkshopXMLAndJSON.Models;
using WorkshopXMLAndJSON.Models.Json;

namespace WorkshopXMLAndJSON
{
    public class Startup
    {
        public static void Main()
        {
            var dataNumber = 1;
            var sb = new StringBuilder();
            var carModels = new List<CarJsonModel>();

            do
            {
                try
                {
                    var json = File.ReadAllText($"../../Data/data.{dataNumber}.json");
                    var carModel = ParseCarModelFromJson(json);
                    
                    carModels.Add(carModel);

                    sb.AppendLine(json);
                    dataNumber++;
                }
                catch (FileNotFoundException)
                {
                    break;
                }
            } while (true);

            var cars = carModels.Select(CarJsonModel.FromJsonModel);
           // Console.WriteLine(sb.ToString());
           Console.WriteLine(string.Join("\r\n------\r\n", cars));
        }

        private static CarJsonModel ParseCarModelFromJson(string json)
        {
            var car = JsonConvert.DeserializeObject<CarJsonModel>(json);
            return car;
        }
    }
}