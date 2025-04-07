using System;

public class Swimming : Activity
{
    public int Laps { get; set; }  // Number of laps

    public Swimming(DateTime date, int durationInMinutes, int laps)
        : base(date, durationInMinutes)
    {
        Laps = laps;
    }

    public override double GetDistance()
    {
        return Laps * 50 / 1000 * 0.62;  // Convert laps to miles (50m per lap)
    }

    public override double GetSpeed()
    {
        return (GetDistance() / DurationInMinutes) * 60;  // Speed in miles per hour
    }

    public override double GetPace()
    {
        return DurationInMinutes / GetDistance();  // Pace in minutes per mile
    }
}
