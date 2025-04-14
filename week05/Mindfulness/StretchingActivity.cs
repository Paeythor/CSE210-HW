using System;
using System.Threading;

public class StretchingActivity : Activity
{
    
    private List<string> stretches = new List<string>
    {
        "Stretch your arms above your head and reach towards the sky.",
        "Stretch your legs by bending over and touching your toes.",
        "Stretch your back by gently arching backward.",
        "Stretch your neck by tilting your head side to side."
    };

    public override void StartActivity()
    {
        
        StartMessage("Stretching Activity", "This activity will guide you through some stretches to improve flexibility and reduce tension.");

        int timeElapsed = 0;

        
        while (timeElapsed < Duration)
        {
            foreach (string stretch in stretches)
            {
                Console.WriteLine(stretch);
                PauseWithAnimation(5); 
                timeElapsed += 5; 
                if (timeElapsed >= Duration) break; 
            }
        }

        
        EndMessage("Stretching");
    }
}
