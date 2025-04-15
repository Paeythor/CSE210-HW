using System;
using System.Threading;

public abstract class Activity
{
    public int Duration { get; set; }

    
    public abstract void StartActivity();

    
    protected void StartMessage(string activityName, string description)
    {
        Console.WriteLine($"{activityName}: {description}");
        Console.WriteLine("Please enter the duration for the activity in seconds:");
        Duration = int.Parse(Console.ReadLine());
        Console.WriteLine("Get ready...");
        PauseWithAnimation(3); 
    }

    
    protected void EndMessage(string activityName)
    {
        Console.WriteLine($"Great job! You've completed the {activityName} activity.");
        Console.WriteLine($"You spent {Duration} seconds on this activity.");
        PauseWithAnimation(3); 
    }

    
    protected void PauseWithAnimation(int seconds)
    {
        DateTime endTime = DateTime.Now.AddSeconds(seconds);
        string[] spinner = new string[] { "|", "/", "-", "\\" };
        int spinnerIndex = 0;

        while (DateTime.Now < endTime)
        {
            Console.WriteLine(spinner[spinnerIndex]);
            Console.WriteLine("  Time left: " + (int)(endTime - DateTime.Now).TotalSeconds + "s");
            Thread.Sleep(500); 
            Console.WriteLine("\b \b"); 
            spinnerIndex = (spinnerIndex + 1) % spinner.Length; 
        }
        
        Console.WriteLine("Time's up!");
    }
    
}
