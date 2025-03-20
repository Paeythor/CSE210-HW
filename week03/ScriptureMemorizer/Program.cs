using System;

public class Program
{
    public static void Main()
    {
        // Create a Scripture object
        var scripture = new Scripture("John 3:16", "For God so loved the world that He gave His one and only Son, that whoever believes in Him shall not perish but have eternal life.");

        // Run the game
        scripture.Start();
    }
}