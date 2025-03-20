public class Reference
{
    public string Text;

    // Constructor for a single verse
    public Reference(string reference)
    {
        this.Text = reference;
    }

    // Constructor for a range of verses (e.g., Proverbs 3:5-6)
    public Reference(string startReference, string endReference)
    {
        this.Text = startReference + " - " + endReference;
    }
}