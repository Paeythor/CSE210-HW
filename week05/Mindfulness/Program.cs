using System;
using System.Threading;

public class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Mindfulness Program!");
        Console.WriteLine("Choose an activity:");
        Console.WriteLine("1. Breathing Activity");
        Console.WriteLine("2. Reflection Activity");
        Console.WriteLine("3. Listing Activity");
        Console.WriteLine("4. Stretching Activity"); // Added Stretching Activity
        Console.WriteLine("5. Exit");

        string choice = Console.ReadLine();

        Activity activity = null;

        switch (choice)
        {
            case "1":
                activity = new BreathingActivity();
                break;
            case "2":
                activity = new ReflectionActivity();
                break;
            case "3":
                activity = new ListingActivity();
                break;
            case "4":
                activity = new StretchingActivity(); // Instantiate StretchingActivity
                break;
            case "5":
                return; // Exit program
            default:
                Console.WriteLine("Invalid choice, please try again.");
                break;
        }

        if (activity != null)
        {
            activity.StartActivity();
        }
    }
}
