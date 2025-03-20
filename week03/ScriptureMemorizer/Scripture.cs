using System;
using System.Collections.Generic;
using System.Linq;

public class Scripture
{
    public Reference Reference;
    public List<Word> Words;

    public Scripture(string reference, string text)
    {
        this.Reference = new Reference(reference);
        this.Words = text.Split(' ').Select(word => new Word(word)).ToList();
    }

    // Start the scripture memorization process
    public void Start()
    {
        while (true)
        {
            ClearConsole();
            DisplayScripture();
            Console.WriteLine("\nPress Enter to continue or type 'quit' to exit.");

            string userInput = Console.ReadLine();
            if (userInput.ToLower() == "quit")
            {
                break;
            }

            HideRandomWord();

            // If all words are hidden, end the program
            if (Words.All(word => word.IsHidden))
            {
                ClearConsole();
                DisplayScripture();
                Console.WriteLine("\nAll words are hidden. Press any key to exit.");
                Console.ReadKey();
                break;
            }
        }
    }

    // Clear the console screen
    private void ClearConsole()
    {
        Console.Clear();
    }

    // Display the scripture with hidden words
    private void DisplayScripture()
    {
        Console.WriteLine(Reference.Text);
        foreach (var word in Words)
        {
            Console.Write(word.IsHidden ? new string('_', word.Text.Length) : word.Text);
            Console.Write(" ");
        }
        Console.WriteLine();
    }

    // Randomly hide a word
    private void HideRandomWord()
    {
        var random = new Random();
        var visibleWords = Words.Where(word => !word.IsHidden).ToList();
        if (visibleWords.Any())
        {
            var wordToHide = visibleWords[random.Next(visibleWords.Count)];
            wordToHide.Hide();
        }
    }
}
