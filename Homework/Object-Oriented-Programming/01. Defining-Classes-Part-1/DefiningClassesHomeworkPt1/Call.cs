using System;

class Call
{
    private string phoneDialled;
    private int durationInSeconds;
    private DateTime dateOfCall;
    private DateTime timeOfCall;

    public Call(string phoneDialled, int duration)
    {
        this.PhoneDialled = phoneDialled;
        this.DurationInSeconds = duration;
        this.DateOfCall = DateTime.Today;
        this.TimeOfCall = DateTime.Now;
    }

    public string PhoneDialled
    {
        get { return this.phoneDialled; }
        set
        {
            SimpleValidator.CheckNullOrEmpty(value, "phone dialled");
            SimpleValidator.CheckNullOrWhiteSpace(value, "phone dialled");
            SimpleValidator.CheckPhoneNumberIsValid(value, "phone dialled");

            this.phoneDialled = value;
        }
    }

    public int DurationInSeconds
    {
        get { return this.durationInSeconds; }
        set
        {
            SimpleValidator.CheckNotPositive(value, "Duration in seconds");
            this.durationInSeconds = value;
        }
    }

    public DateTime TimeOfCall
    {
        get { return this.timeOfCall; }
        private set
        {
            // SimpleValidator.CheckDateTimeIsValid(value, "time of call");

            this.timeOfCall = value;
        }
    }

    public DateTime DateOfCall
    {
        get { return this.dateOfCall; }
        private set
        {
            // SimpleValidator.CheckDateTimeIsValid(value, "date of call");

            this.dateOfCall = value;
        }
    }

    public override string ToString()
    {
        return "PhoneDialled: " + this.PhoneDialled + Environment.NewLine
            + "Duration: " + this.DurationInSeconds + Environment.NewLine
            + "DateOfCall: " + this.DateOfCall.ToShortDateString() + Environment.NewLine
            + "TimeOfCall: " + this.TimeOfCall.ToShortTimeString() + Environment.NewLine;
    }
}
