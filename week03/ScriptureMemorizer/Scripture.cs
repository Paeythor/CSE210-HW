using System;
using System.Collections.Generic;
using System.Linq;

class Scripture
{
    private Reference _reference;
    private List<Word> _words;
    private Random _random;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = text.Split(' ').Select(word => new Word(word)).ToList();
        _random = new Random();
    }

    public void HideRandomWords()
    {
        int wordsToHide = Math.Max(1, _words.Count / 5); // Hide about 20% of words each time

        for (int i = 0; i < wordsToHide; i++)
        {
            var visibleWords = _words.Where(w => !w.IsHidden).ToList();
            if (visibleWords.Count == 0) break;

            int index = _random.Next(visibleWords.Count);
            visibleWords[index].Hide();
        }
    }

    public string GetDisplayText()
    {
        string scriptureText = string.Join(" ", _words.Select(w => w.GetDisplayText()));
        return $"{_reference.GetDisplayText()} - {scriptureText}";
    }

    public bool AllWordsHidden()
    {
        return _words.All(w => w.IsHidden);
    }
}
