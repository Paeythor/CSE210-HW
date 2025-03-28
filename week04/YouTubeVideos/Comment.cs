using System;

public class Comment
{
    private string commenter;
    private string text;

    // Constructor
    public Comment(string commenter, string text)
    {
        this.commenter = commenter;
        this.text = text;
    }

    // Method to display comment details
    public void DisplayInfo()
    {
        Console.WriteLine($"- {commenter}: {text}");
    }
}