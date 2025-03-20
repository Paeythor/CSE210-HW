public class Word
{
    public string Text;
    public bool IsHidden;

    public Word(string text)
    {
        Text = text;
        IsHidden = false;
    }

    // Hide the word by setting IsHidden to true
    public void Hide()
    {
        IsHidden = true;
    }
}
