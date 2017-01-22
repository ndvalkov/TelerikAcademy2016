using System;
using System.Collections.Generic;

class GSM
{
    private static string iPhone4S;

    private string model;
    private string manufacturer;
    private decimal price;
    private string owner;
    private Battery battery;
    private Display display;

    private List<Call> callHistory = new List<Call>();

    public GSM(string model, string manufacturer)
    {
        this.Model = model;
        this.Manufacturer = manufacturer;
    }

    public GSM(string model, string manufacturer, decimal price)
        : this(model, manufacturer)
    {
        this.Price = price;
    }

    public GSM(string model, string manufacturer, decimal price, string owner)
        : this(model, manufacturer, price)
    {
        this.Owner = owner;
    }

    public static string IPhone4S
    {
        get { return iPhone4S; }
        set
        {
            SimpleValidator.CheckNullOrEmpty(value, "iPhone4S description");
            SimpleValidator.CheckNullOrWhiteSpace(value, "iPhone4S description");

            iPhone4S = value;
        }
    }

    public string Model
    {
        get { return this.model; }
        set
        {
            SimpleValidator.CheckNullOrEmpty(value, "model");
            SimpleValidator.CheckNullOrWhiteSpace(value, "model");

            this.model = value;
        }
    }

    public string Manufacturer
    {
        get { return this.manufacturer; }
        set
        {
            SimpleValidator.CheckNullOrEmpty(value, "manufacturer");
            SimpleValidator.CheckNullOrWhiteSpace(value, "manufacturer");

            this.manufacturer = value;
        }
    }

    public decimal Price
    {
        get { return this.price; }
        set
        {
            SimpleValidator.CheckNotPositive(value, "price");

            this.price = value;
        }
    }

    public string Owner
    {
        get { return this.owner; }
        set
        {
            SimpleValidator.CheckNullOrEmpty(value, "owner");
            SimpleValidator.CheckNullOrWhiteSpace(value, "owner");

            this.owner = value;
        }
    }

    public Battery Battery
    {
        get { return this.battery; }
        set
        {
            SimpleValidator.CheckNull(value, "battery");

            this.battery = value;
        }
    }

    public Display Display
    {
        get { return this.display; }
        set
        {
            SimpleValidator.CheckNull(value, "display");

            this.display = value;
        }
    }

    public List<Call> CallHistory
    {
        get 
        { 
            return new List<Call>(callHistory); 
        }
        private set
        {
            // SimpleValidator.CheckNull(value, "call history");

            this.callHistory = value;
        }
    }

    public void AddCall(Call call)
    {
        SimpleValidator.CheckNull(call, "call");
        callHistory.Add(call);
    }

    public void DeleteLastCall()
    {
        callHistory.RemoveAt(callHistory.Count - 1);
    }

    public void DeleteCallAtPosition(int pos)
    {
        if (pos < 0 || pos > callHistory.Count - 1)
        {
            throw new ArgumentException("Must be a valid position within the call history");
        }

        callHistory.RemoveAt(pos);
    }

    public void ClearHistory()
    {
        callHistory.Clear();
    }

    public decimal CalculateTotalPriceOfCalls(decimal pricePerMinute)
    {
        decimal result = 0m;
        decimal pricePerSecond = pricePerMinute / 60;
        
        foreach (var item in callHistory)
        {
            result += (item.DurationInSeconds * pricePerSecond);
        }

        return result;
    }

    public void PrintHistory()
    {
        if (callHistory.Count == 0)
        {
            Console.WriteLine("The call history is empty");
        }
        else
        {
            foreach (var item in callHistory)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }

    public override string ToString()
    {
        return "GSM model: " + this.Model + Environment.NewLine
            + "Manufacturer: " + this.Manufacturer + Environment.NewLine
            + "Price: " + this.Price + Environment.NewLine
            + "Owner: " + this.Owner + Environment.NewLine
            + "Battery: " + this.Battery + Environment.NewLine
            + "Display: " + this.Display + Environment.NewLine;
    }
}