
using System;
using System.Collections.Generic;

public class Video
{
    private string title;
    private string author;
    private int length; // Length in seconds
    private List<Comment> comments;

    // Constructor
    public Video(string title, string author, int length)
    {
        this.title = title;
        this.author = author;
        this.length = length;
        this.comments = new List<Comment>();
    }

    // Method to add a comment
    public void AddComment(Comment comment)
    {
        comments.Add(comment);
    }

    // Method to get the number of comments
    public int GetCommentCount()
    {
        return comments.Count;
    }

    // Method to display video details and comments
    public void DisplayInfo()
    {
        Console.WriteLine($"Title: {title}");
        Console.WriteLine($"Author: {author}");
        Console.WriteLine($"Length: {length} seconds");
        Console.WriteLine($"Comments ({GetCommentCount()}):");

        foreach (var comment in comments)
        {
            comment.DisplayInfo();
        }

        Console.WriteLine("---------------------------------------------------");
    }
}
