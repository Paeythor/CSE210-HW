using System;
using System.Threading;

public abstract class Activity
{
    public int Duration { get; set; }

    // Base method to start any activity, will be overridden by derived classes.
    public abstract void StartActivity();

    // Common start message to all activities
    protected void StartMessage(string activityName, string description)
    {
        Console.WriteLine($"{activityName}: {description}");
        Console.WriteLine("Please enter the duration for the activity in seconds:");
        Duration = int.Parse(Console.ReadLine());
        Console.WriteLine("Get ready...");
        PauseWithAnimation(3); // Pause for 3 seconds before starting the activity
    }

    // Common end message for all activities
    protected void EndMessage(string activityName)
    {
        Console.WriteLine($"Great job! You've completed the {activityName} activity.");
        Console.WriteLine($"You spent {Duration} seconds on this activity.");
        PauseWithAnimation(3); // Pause for 3 seconds before finishing
    }

    // Pause method with an animation (spinner or countdown) during the pause
    protected void PauseWithAnimation(int seconds)
    {
        DateTime endTime = DateTime.Now.AddSeconds(seconds);
        string[] spinner = new string[] { "|", "/", "-", "\\" };
        int spinnerIndex = 0;

        while (DateTime.Now < endTime)
        {
            Console.WriteLine(spinner[spinnerIndex]);
            Console.WriteLine("  Time left: " + (int)(endTime - DateTime.Now).TotalSeconds + "s");
            Thread.Sleep(500); // Pause for 0.5 second
            Console.WriteLine("\b \b"); // Erase the previous character
            spinnerIndex = (spinnerIndex + 1) % spinner.Length; // Cycle through the spinner
        }
        // Final countdown display (when time is up)
        Console.WriteLine("Time's up!");
    }
    
}
