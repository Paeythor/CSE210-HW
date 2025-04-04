// Reference.cs
using System;

class Reference
{
    public string Book { get; }
    public int Chapter { get; }
    public int StartVerse { get; }
    public int? EndVerse { get; } // Nullable for single-verse references

    public Reference(string book, int chapter, int startVerse, int? endVerse = null)
    {
        Book = book;
        Chapter = chapter;
        StartVerse = startVerse;
        EndVerse = endVerse;
    }

    public static Reference Parse(string referenceText)
    {
        // Example: "Moses 1:39" or "Matthew 5:14–16"
        string[] parts = referenceText.Split(' ');
        if (parts.Length < 2)
        {
            throw new FormatException("Invalid reference format.");
        }

        string book = parts[0]; // Get the book name
        string[] chapterAndVerses = parts[1].Split(':'); // Split at ':'

        if (chapterAndVerses.Length < 2)
        {
            throw new FormatException("Invalid reference format.");
        }

        int chapter = int.Parse(chapterAndVerses[0]); // Parse chapter number
        string[] verses = chapterAndVerses[1].Split('–'); // Handle single/multi-verse

        int startVerse = int.Parse(verses[0]);
        int? endVerse = verses.Length > 1 ? int.Parse(verses[1]) : (int?)null;

        return new Reference(book, chapter, startVerse, endVerse);
    }

    public override string ToString()
    {
        return EndVerse.HasValue ? $"{Book} {Chapter}:{StartVerse}–{EndVerse}" : $"{Book} {Chapter}:{StartVerse}";
    }
}
