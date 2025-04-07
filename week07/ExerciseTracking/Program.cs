using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        var activities = new List<Activity>
        {
            new Running (DateTime.Today, 30, 3.0),  // 30 minutes, 3 miles
            new Cycling (DateTime.Today, 45, 15.0),  // 45 minutes, 15 miles per hour
            new Swimming (DateTime.Today, 30, 20)    // 30 minutes, 20 laps
        };

        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}
