using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

public class Scripture
{
    private string _book;
    private int _chapter;
    private int _verse;
    private string _text;

    // Getters and Setters for Book, Chapter, Verse, and Text
    public string GetBook()
    {
        return _book;
    }

    public void SetBook(string book)
    {
        _book = book;
    }

    public int GetChapter()
    {
        return _chapter;
    }

    public void SetChapter(int chapter)
    {
        _chapter = chapter;
    }

    public int GetVerse()
    {
        return _verse;
    }

    public void SetVerse(int verse)
    {
        _verse = verse;
    }

    public string GetText()
    {
        return _text;
    }

    public void SetText(string text)
    {
        _text = text;
    }

    // Convert the scripture's text into a list of 'Word' objects
    public List<Word> GetWords()
    {
        return _text.Split(' ').Select(word => new Word(word)).ToList();
    }

    // Method to split a scripture reference like "Book 1:1" into its components
    public static (string bookName, int chapter, int verse) SplitReference(string reference)
    {
        // Regex to match standard reference format like "Book 1:1"
        var referencePattern = new Regex(@"^(?<bookName>[\w\s]+)\s(?<chapter>\d+):(?<verse>\d+)$");
        var match = referencePattern.Match(reference);

        if (match.Success)
        {
            string bookName = match.Groups["bookName"].Value;
            int chapter = int.Parse(match.Groups["chapter"].Value);
            int verse = int.Parse(match.Groups["verse"].Value);

            return (bookName, chapter, verse);
        }

        // If reference format is invalid, return default values
        return (string.Empty, 0, 0);
    }

    // Method to read a scripture reference and its text
    public void ReadScripture(string reference, string text)
    {
        var parts = SplitReference(reference);
        _book = parts.bookName;
        _chapter = parts.chapter;
        _verse = parts.verse;
        _text = text;
    }

    // Override ToString for easy output of the scripture in a readable format
    public override string ToString()
    {
        return $"{_book} {_chapter}:{_verse} - {_text}";
    }
}
