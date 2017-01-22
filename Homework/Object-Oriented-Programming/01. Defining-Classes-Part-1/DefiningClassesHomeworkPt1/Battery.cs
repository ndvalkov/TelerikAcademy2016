using System;

class Battery
{
    private string model;
    private BatteryType type;
    private double hoursIdle;
    private double hoursTalk;

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
    public BatteryType Type
    {
        get { return this.type; }
        set
        {
            SimpleValidator.CheckInEnumRange(typeof(BatteryType), (int)value, "battery type");

            this.type = value;
        }
    }
    public double HoursIdle 
    {
        get { return this.hoursIdle; }
        set
        {
            SimpleValidator.CheckNotPositive((decimal)value, "hours idle");

            this.hoursIdle = value;
        }
    }
    public double HoursTalk
    {
        get { return this.hoursTalk; }
        set
        {
            SimpleValidator.CheckNotPositive((decimal)value, "hours talk");

            this.hoursTalk = value;
        }
    }
}
