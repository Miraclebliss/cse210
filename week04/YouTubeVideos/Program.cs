using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Video video1 = new Video("How to Cook Jollof Rice", "Chef Tunde", 540);
        Video video2 = new Video("C# Basics Tutorial", "CodeHub", 900);
        Video video3 = new Video("Lagos Street Food Tour", "TravelWithMila", 750);

        video1.AddComment(new Comment("Ada", "Loved the recipe!"));
        video1.AddComment(new Comment("Kunle", "Very easy to follow!"));
        video1.AddComment(new Comment("Sarah", "Please make fried rice next."));

        video2.AddComment(new Comment("John", "Very beginner friendly."));
        video2.AddComment(new Comment("Bisi", "Thanks for this lesson!"));
        video2.AddComment(new Comment("Tobi", "Can you make an OOP video?"));

        video3.AddComment(new Comment("Kingsley", "I miss Lagos now 😭"));
        video3.AddComment(new Comment("Mariam", "The street food looks amazing!"));
        video3.AddComment(new Comment("Sam", "Make part 2!"));

        List<Video> videos = new List<Video> { video1, video2, video3 };

        foreach (Video video in videos)
        {
            Console.WriteLine("\n---------------------------------");
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length: {video.LengthInSeconds} seconds");
            Console.WriteLine($"Comments ({video.GetCommentCount()}):");

            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($" - {comment.CommenterName}: {comment.CommentText}");
            }
        }
    }
}
