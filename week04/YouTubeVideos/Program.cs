using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<Video> videos = new List<Video>();

        // Creating videos
        Video video1 = new Video("C# abstract classes", "Bro Code", 141);
        video1.AddComment(new Comment("redblade79x", "I have my first technical interview later this week. Your videos have been the biggest help over anything else I’ve seen on YouTube in getting me prepared. The analogies make plenty of sense and are succinct. Great job!"));
        video1.AddComment(new Comment("leonvieira3877", "Quick and simple, nice refresher/introduction to the concept. Much appreciated."));
        video1.AddComment(new Comment("Fraps224", "Your explanations are awesome"));

        Video video2 = new Video("Object-Oriented Programming, Simplified", "Programming with Mosh", 453);
        video2.AddComment(new Comment("chrisaga6253", "1:02 Encapsulation 3:29 Abstraction 4:41 Inheritance 5:27 Polymorphism"));
        video2.AddComment(new Comment("PavanKumar-pn2tc", "Encapsulation: grouping related variables and functions operating on them (Reduce complexity). Abstraction: hiding complex data and methods from user (simple interface). Polymorphism: many forms .. to avoid long if-else statements. Inheritance: inherit the qualities of a code (to remove redundant code)."));
        video2.AddComment(new Comment("dizelvinable", "Finally an example of OOP without a car! Thank you."));

        Video video3 = new Video("C# abstract classes and methods in 8 minutes", "tutorialsEU - C#", 499);
        video3.AddComment(new Comment("Drougar108", "Thank you! I had 4 hours of sleep and I needed to get some more abstract and interface info into my brain, and as it is this week's class subject, I'm trying to cram it in there."));
        video3.AddComment(new Comment("dennisdevink5667", "Clear and fast! Thanks!"));
        video3.AddComment(new Comment("sanjaytharan622", "This one is a lifesaver! Thanks a lot."));

        // Adding videos to list
        videos.Add(video1);
        videos.Add(video2);
        videos.Add(video3);

        // Displaying videos and comments
        foreach (var video in videos)
        {
            video.DisplayInfo();
        }
    }
}