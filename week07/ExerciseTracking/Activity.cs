using System;

public abstract class Activity
{
    // Shared attributes
    public DateTime Date { get; set; }
    public int DurationInMinutes { get; set; }  // Duration in minutes

    // Constructor to initialize shared properties
    public Activity(DateTime date, int durationInMinutes)
    {
        Date = date;
        DurationInMinutes = durationInMinutes;
    }

    // Abstract methods that will be overridden by derived classes
    public abstract double GetDistance();  // Will be implemented in derived classes
    public abstract double GetSpeed();     // Will be implemented in derived classes
    public abstract double GetPace();      // Will be implemented in derived classes

    // Summary method that will use other methods to generate a summary
    public virtual string GetSummary()
    {
        return $"{Date.ToString("dd MMM yyyy")} {this.GetType().Name} ({DurationInMinutes} min) - Distance {GetDistance():F2}, Speed: {GetSpeed():F2}, Pace: {GetPace():F2} min per unit";
    }
}
