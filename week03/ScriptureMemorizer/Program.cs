using System;

class Program
{
    static void Main()
    {
        // Initialize the Word and Verse classes
        Word word = new Word();
        Verse verse = new Verse();

        // Display the available words/keywords
        word.DisplayWords();

        Console.WriteLine("\nEnter a word to start guessing:");

        // Get the word from the user
        string inputWord = Console.ReadLine().Trim();

        // Try to get the scripture reference for the entered word
        if (word.TryGetReference(inputWord, out string reference))
        {
            // Start the guessing process for the selected word
            GuessVerse(inputWord, reference, verse);
        }
        else
        {
            Console.WriteLine("Word not found. Please try again.");
        }
    }

    static void GuessVerse(string inputWord, string reference, Verse verse)
    {
        string fullVerse = verse.GetFullVerse(reference);
        string displayVerse = new string('_', fullVerse.Length); // Initially hide the verse
        
        Console.Clear();
        Console.WriteLine($"You selected the word: {inputWord}");
        Console.WriteLine("Guess the verse letter by letter.");

        // Loop to allow the user to guess letter by letter
        char[] displayArray = displayVerse.ToCharArray();
        bool isComplete = false;

        while (!isComplete)
        {
            // Display the current state of the verse
            Console.Clear();
            Console.WriteLine("Current verse:");
            Console.WriteLine(new string(displayArray));
            
            Console.WriteLine("\nEnter a letter to guess:");
            char guess = Console.ReadKey(true).KeyChar;

            bool correctGuess = false;

            // Check if the guessed letter matches any of the characters in the full verse
            for (int i = 0; i < fullVerse.Length; i++)
            {
                if (fullVerse[i] == guess && displayArray[i] == '_') // Only replace _ with the guessed letter
                {
                    displayArray[i] = guess;
                    correctGuess = true;
                }
            }

            // Check if the user has guessed the whole verse
            isComplete = !displayArray.Contains('_');

            if (correctGuess)
            {
                Console.WriteLine($"Good guess! Current verse: {new string(displayArray)}");
            }
            else
            {
                Console.WriteLine($"Wrong guess! Current verse: {new string(displayArray)}");
            }

            // Delay to let the user see their progress
            System.Threading.Thread.Sleep(500);
        }

        Console.WriteLine("\nCongratulations! You've guessed the verse correctly!");
        Console.WriteLine("Full verse: " + fullVerse);
    }
}
