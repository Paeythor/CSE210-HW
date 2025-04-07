using System;

public class Running : Activity
{
    public double Distance { get; set; } 

    public Running(DateTime date, int durationInMinutes, double distance)
        : base(date, durationInMinutes)
    {
        Distance = distance;
    }

    public override double GetDistance()
    {
        return Distance;
    }

    public override double GetSpeed()
    {
        return (Distance / DurationInMinutes) * 60; 
    }


    public override double GetPace()
    {
        return DurationInMinutes / Distance;  
    }
}
