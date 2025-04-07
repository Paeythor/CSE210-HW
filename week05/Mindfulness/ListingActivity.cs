public class ListingActivity : Activity
{
    private List<string> prompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?"
    };

    public override void StartActivity()
    {
        StartMessage("Listing Activity", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.");
        
        Random rand = new Random();
        string prompt = prompts[rand.Next(prompts.Count)];
        Console.WriteLine(prompt);
        PauseWithAnimation(3); // Pause for a few seconds before starting the listing

        List<string> responses = new List<string>();
        DateTime startTime = DateTime.Now;
        DateTime futureTime = startTime.AddSeconds(Duration);

        while (DateTime.Now < futureTime)
        {
            Console.WriteLine("Enter something you are grateful for or a personal strength (or type 'done' to finish):");
            string response = Console.ReadLine();
            if (response.ToLower() == "done") break;
            responses.Add(response);
        }

        Console.WriteLine($"You listed {responses.Count} items.");
        EndMessage("Listing");
    }
}
