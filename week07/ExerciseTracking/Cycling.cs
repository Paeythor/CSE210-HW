using System;

public class Cycling : Activity
{
    public double Speed { get; set; }  // Speed in miles per hour or kilometers per hour

    public Cycling(DateTime date, int durationInMinutes, double speed)
        : base(date, durationInMinutes)
    {
        Speed = speed;
    }

    public override double GetDistance()
    {
        return (Speed * DurationInMinutes) / 60;  // Distance in miles or kilometers
    }

    public override double GetSpeed()
    {
        return Speed;
    }

    public override double GetPace()
    {
        return 60 / Speed;  // Pace in minutes per mile or per kilometer
    }
}
