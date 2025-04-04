// Program.cs
using System.IO;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main()
    {
        List<Scripture> scriptures = LoadScripturesFromFile("/Users/krypton/Desktop/CSE210-HW/week03/ScriptureMemorizer/Scriptures.txt");

        if (scriptures.Count == 0)
        {
            Console.WriteLine("No scriptures found in the file.");
            return;
        }

        bool keepRunning = true;
        Random random = new Random();

        while (keepRunning)
        {
            Scripture scripture = scriptures[random.Next(scriptures.Count)];

            while (!scripture.AllWordsHidden())
            {
                Console.Clear();
                Console.WriteLine(scripture.GetDisplayText());
                Console.WriteLine("\nPress Enter to hide words, type 'next' for another scripture, or 'quit' to exit.");

                string input = Console.ReadLine().ToLower();
                if (input == "quit")
                {
                    keepRunning = false;
                    break;
                }
                else if (input == "next")
                {
                    break; // Break out of inner loop to get a new scripture
                }

                scripture.HideRandomWords();
            }

            if (scripture.AllWordsHidden())
            {
                Console.Clear();
                Console.WriteLine(scripture.GetDisplayText());
                Console.WriteLine("\nAll words are now hidden! Well done memorizing.");
                Console.WriteLine("Press Enter for a new scripture or type 'quit' to exit.");

                string input = Console.ReadLine().ToLower();
                if (input == "quit")
                {
                    keepRunning = false;
                }
            }
        }
    }

    static List<Scripture> LoadScripturesFromFile(string filePath)
    {
        List<Scripture> scriptures = new List<Scripture>();
        string line;

        try
        {
            // Pass the file path and file name to the StreamReader constructor
            StreamReader sr = new StreamReader(filePath);

            // Read the first line of text
            line = sr.ReadLine();

            // Continue to read until you reach the end of the file
            while (line != null)
            {
                // Skip empty lines
                if (string.IsNullOrWhiteSpace(line))
                {
                    line = sr.ReadLine();
                    continue;
                }

                string[] parts = line.Split('|');
                if (parts.Length == 3)
                {
                    string referenceText = parts[0].Trim();
                    string topic = parts[1].Trim(); // currently unused but could be added to Scripture class
                    string text = parts[2].Trim();

                    Reference reference = Reference.Parse(referenceText);
                    scriptures.Add(new Scripture(reference, text));
                }

                // Read the next line
                line = sr.ReadLine();
            }

            // Close the file
            sr.Close();
        }
        catch (Exception e)
        {
            Console.WriteLine("Exception: " + e.Message);
        }
        finally
        {
            Console.WriteLine("Executing finally block.");
        }

        return scriptures;
    }
}
