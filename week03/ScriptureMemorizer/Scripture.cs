// Scripture.cs
using System;
using System.Collections.Generic;
using System.Linq;

class Scripture
{
    private Reference _reference;
    private List<Word> _words;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = text.Split(' ').Select(word => new Word(word)).ToList();
    }

    public string GetDisplayText()
    {
        string referenceText = _reference.ToString();
        string scriptureText = string.Join(" ", _words.Select(word => word.GetDisplayText()));
        return $"{referenceText} - {scriptureText}";
    }

    public void HideRandomWords()
    {
        Random random = new Random();
        var visibleWords = _words.Where(word => !word.IsHidden).ToList();
        if (visibleWords.Count == 0) return;

        int wordsToHide = Math.Max(1, visibleWords.Count / 4); // Hide 25% of remaining words
        for (int i = 0; i < wordsToHide; i++)
        {
            visibleWords[random.Next(visibleWords.Count)].Hide();
        }
    }

    public bool AllWordsHidden()
    {
        return _words.All(word => word.IsHidden);
    }
}
