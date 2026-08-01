using System;
using System.Collections.Generic;

class Comment
{
    public string CommenterName { get; set; }
    public string Text { get; set; }

    public Comment(string commenterName, string text)
    {
        CommenterName = commenterName;
        Text = text;
    }
}

class Video
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int LengthInSeconds { get; set; }
    private List<Comment> comments = new List<Comment>();

    public Video(string title, string author, int lengthInSeconds)
    {
        Title = title;
        Author = author;
        LengthInSeconds = lengthInSeconds;
    }

    public void AddComment(Comment comment)
    {
        comments.Add(comment);
    }

    public int GetNumberOfComments()
    {
        return comments.Count;
    }

    private string FormatLength()
    {
        int minutes = LengthInSeconds / 60;
        int seconds = LengthInSeconds % 60;
        return $"{minutes} min {seconds} sec";
    }

    public void DisplayVideoInfo()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("=======================================");
        Console.WriteLine($"🎬 Title: {Title}");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"👤 Author: {Author}");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"⏱ Length: {FormatLength()}");
        Console.ResetColor();

        Console.WriteLine($"💬 Number of Comments: {GetNumberOfComments()}");
        Console.WriteLine("Comments:");
        Console.WriteLine("---------------------------------------");

        foreach (var comment in comments)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"- {comment.CommenterName}: \"{comment.Text}\"");
        }

        Console.ResetColor();
        Console.WriteLine("=======================================\n");
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Create videos
        Video video1 = new Video("Return Of The gods#", "VICTORIA", 600);
        Video video2 = new Video("Cooking local Pasta", "PROSPER", 900);
        Video video3 = new Video("Travel Vlog: Nigeria", "EZE", 1200);

        // Add comments to video1
        video1.AddComment(new Comment("Chibueze", "Great Movie!"));
        video1.AddComment(new Comment("Prince", "Very Interesting, thanks."));
        video1.AddComment(new Comment("Joy", "When are we expecting the part two?"));

        // Add comments to video2
        video2.AddComment(new Comment("Anna", "Looks delicious!"));
        video2.AddComment(new Comment("Udeme", "I tried this recipe, amazing."));
        video2.AddComment(new Comment("Lawrence", "Can you share vegetarian options?"));

        // Add comments to video3
        video3.AddComment(new Comment("David", "Nigeria looks beautiful."));
        video3.AddComment(new Comment("Joy", "Loved the Cultural Festivals."));
        video3.AddComment(new Comment("Uche", "Beautiful Women!"));

        // Put videos in a list
        List<Video> videos = new List<Video> { video1, video2, video3 };

        // Display info for each video
        foreach (var video in videos)
        {
            video.DisplayVideoInfo();
        }

        // Summary statistics (extra creativity)
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("📊 Summary Report");
        Console.WriteLine($"Total Videos: {videos.Count}");
        int totalComments = 0;
        foreach (var v in videos) totalComments += v.GetNumberOfComments();
        Console.WriteLine($"Total Comments: {totalComments}");
        Console.WriteLine($"Average Comments per Video: {(double)totalComments / videos.Count:F2}");
        Console.ResetColor();
    }
}
