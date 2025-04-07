using System;
using System.Threading;

public class StretchingActivity : Activity
{
    // List of stretches to guide the user
    private List<string> stretches = new List<string>
    {
        "Stretch your arms above your head and reach towards the sky.",
        "Stretch your legs by bending over and touching your toes.",
        "Stretch your back by gently arching backward.",
        "Stretch your neck by tilting your head side to side."
    };

    public override void StartActivity()
    {
        // Display the starting message
        StartMessage("Stretching Activity", "This activity will guide you through some stretches to improve flexibility and reduce tension.");

        int timeElapsed = 0;

        // Loop through the stretches until the duration is met
        while (timeElapsed < Duration)
        {
            foreach (string stretch in stretches)
            {
                Console.WriteLine(stretch);
                PauseWithAnimation(5); // Wait for 5 seconds for the user to complete each stretch
                timeElapsed += 5; // Increase time by 5 seconds after each stretch
                if (timeElapsed >= Duration) break; // Exit if we've reached the desired duration
            }
        }

        // End the activity with a completion message
        EndMessage("Stretching");
    }
}
