public class Word
{
    private string _text;            // The original word text
    private string _hiddenText;      // The hidden representation (e.g., underscores)
    private bool _isHidden;          // Indicates whether the word is hidden or not

    // Constructor that initializes the word with its text
    public Word(string text)
    {
        _text = text;
        _hiddenText = new string('_', text.Length);  // Hides the word by using underscores
        _isHidden = false;                            // By default, the word is not hidden
    }

    // Hides the word (replaces with underscores) and returns the hidden version
    public string Hide()
    {
        _isHidden = true;  // Mark the word as hidden
        return _hiddenText;
    }

    // Returns either the hidden text or the original text based on _isHidden
    public string GetDisplayText()
    {
        return _isHidden ? _hiddenText : _text;  // If hidden, return underscores; otherwise, return the word
    }

    // Getter for the original word text
    public string GetText()
    {
        return _text;
    }

    // Checks if the word is currently hidden
    public bool IsHidden()
    {
        return _isHidden;
    }

    // Optional: Add a method to reveal the word (if required)
    public string Reveal()
    {
        _isHidden = false;  // Mark the word as revealed
        return _text;
    }
}

