using System;
using System.Linq;

public class ScriptureMemorizer
{
    private Scripture scripture;
    private Random random;
    
    public ScriptureMemorizer(Scripture scripture)
    {
        this.scripture = scripture;
        this.random = new Random();
    }
    
    public void Start()
    {
        // Display the full scripture
        scripture.DisplayScripture();

        // Start the guessing process
        string input = "";
        while (scripture.GetVerses().Any(v => v.GetWords().Any(w => !w.IsHidden())))
        {
            Console.WriteLine("\nPress Enter to guess a hidden word or type 'quit' to exit.");
            input = Console.ReadLine();

            if (input.ToLower() == "quit")
            {
                break;
            }

            // Show the current scripture with hidden words
            scripture.DisplayScripture();

            // Prompt the user to guess the hidden words
            Console.WriteLine("Guess a hidden word:");
            string userGuess = Console.ReadLine().Trim().ToLower();

            // Check if the guess is correct and hide the word
            if (CheckGuess(userGuess))
            {
                Console.WriteLine("Correct! A word has been hidden.");
            }
            else
            {
                Console.WriteLine("Incorrect. Try again.");
            }
            
            // Continue hiding random words until all words are hidden
            HideRandomWord();
            scripture.DisplayScripture();
        }
        
        Console.WriteLine("\nAll words are hidden. Memorization complete!");
    }

    private bool CheckGuess(string guess)
    {
        // Loop through the words and check if the guess matches any of the hidden words
        var visibleWords = scripture.GetVerses()
                                     .SelectMany(v => v.GetWords())
                                     .Where(w => !w.IsHidden())
                                     .ToList();
        
        foreach (Word word in visibleWords)
        {
            if (word.GetText().ToLower() == guess)
            {
                word.Hide(); // Hide the word if the guess is correct
                return true;
            }
        }
        return false;
    }

    private void HideRandomWord()
    {
        // Get all words that are not hidden
        var visibleWords = scripture.GetVerses()
                                     .SelectMany(v => v.GetWords())
                                     .Where(w => !w.IsHidden())
                                     .ToList();
        
        if (visibleWords.Any())
        {
            // Select a random word and hide it
            Word wordToHide = visibleWords[random.Next(visibleWords.Count)];
            wordToHide.Hide();
        }
    }
}
