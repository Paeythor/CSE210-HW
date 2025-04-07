public class ReflectionActivity : Activity
{
    private List<string> prompts = new List<string>
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private List<string> reflectionQuestions = new List<string>
    {
        "Why was this experience meaningful to you?",
        "How did you feel when it was complete?",
        "What did you learn about yourself through this experience?"
    };

    public override void StartActivity()
    {
        StartMessage("Reflection Activity", "This activity will help you reflect on times in your life when you have shown strength and resilience.");
        
        Random rand = new Random();
        string prompt = prompts[rand.Next(prompts.Count)];
        Console.WriteLine(prompt);
        PauseWithAnimation(3); // Pause for a few seconds before prompting questions

        foreach (string question in reflectionQuestions)
        {
            Console.WriteLine(question);
            PauseWithAnimation(5); // Wait 5 seconds after each question for reflection
        }

        EndMessage("Reflection");
    }
}
