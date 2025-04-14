public class BreathingActivity : Activity
{
    public override void StartActivity()
    {
        StartMessage("Breathing Activity", "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.");
        
        int timeElapsed = 0;
        while (timeElapsed < Duration)
        {
            Console.WriteLine("Breathe in...");
            PauseWithAnimation(4); 
            Console.WriteLine("Breathe out...");
            PauseWithAnimation(4); 
            timeElapsed += 8; 
        }

        EndMessage("Breathing");
    }
}
