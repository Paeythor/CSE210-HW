using System;
using System.Collections.Generic;

public class Scripture
{
    private string reference;
    private List<Verse> verses;

    public Scripture(string reference, string text)
    {
        this.reference = reference;
        this.verses = new List<Verse> { new Verse(text) };
    }
    
    public Scripture(string reference, List<string> texts)
    {
        this.reference = reference;
        this.verses = new List<Verse>();
        foreach (var text in texts)
        {
            this.verses.Add(new Verse(text));
        }
    }

    public string GetReference()
    {
        return reference;
    }

    public List<Verse> GetVerses()
    {
        return verses;
    }

    public void DisplayScripture()
    {
        Console.Clear();
        Console.WriteLine(reference);
        foreach (Verse verse in verses)
        {
            verse.Display();
        }
    }
}
