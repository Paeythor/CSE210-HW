using System;
using System.Collections.Generic;

public class Word
{
    private Dictionary<string, string> wordDictionary;

    public Word()
    {
        wordDictionary = new Dictionary<string, string>
        {
            { "Purpose", "Moses 1:39" },
            { "Light", "Matthew 5:14–16" },
            { "Obedience", "1 Nephi 3:7" }
        };
    }

    public bool TryGetReference(string word, out string reference)
    {
        return wordDictionary.TryGetValue(word, out reference);
    }

    public void DisplayWords()
    {
        Console.WriteLine("Available keywords:");
        foreach (var word in wordDictionary.Keys)
        {
            Console.WriteLine("- " + word);
        }
    }
}
