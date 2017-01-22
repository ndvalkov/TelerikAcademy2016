using System;

class Display
{
    private double size;
    private int numberOfColors;

    public double Size
    {
        get { return this.size; }
        set
        {
            SimpleValidator.CheckNotPositive((decimal)value, "size");

            this.size = value;
        }
    }

    public int NumberOfColors
    {
        get { return this.numberOfColors; }
        set
        {
            SimpleValidator.CheckNotPositive((decimal)value, "numberOfColors");

            this.numberOfColors = value;
        }
    }
}
