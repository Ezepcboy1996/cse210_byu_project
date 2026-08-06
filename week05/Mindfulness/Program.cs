// Exceeding Requirements:
// 1. Added logging feature to track completed activities in activity_log.txt.
// 2. Extended menu system with "View Activity Log" option so users can review their history.
// 3. Enhanced animations (spinner cycles and countdown) for more engaging user experience.

using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

abstract class Activity
{
    protected string name;
    protected string description;
    protected int duration;

    public Activity(string name, string description)
    {
        this.name = name;
        this.description = description;
    }

    public void StartMessage()
    {
        Console.WriteLine($"\n=== Starting {name} Activity ===");
        Console.WriteLine(description);
        Console.Write("Enter duration in seconds: ");
        duration = int.Parse(Console.ReadLine());
        Console.WriteLine("Prepare to begin...");
        ShowSpinner(3);
    }

    public void EndMessage()
    {
        Console.WriteLine("\nWell done!");
        ShowSpinner(2);
        Console.WriteLine($"You completed {name} for {duration} seconds.");
        ShowSpinner(3);

        LogActivity(); // <-- exceeded requirement: logging
    }

    protected void ShowSpinner(int seconds)
    {
        string[] spinner = { "/", "-", "\\", "|" };
        for (int i = 0; i < seconds * 4; i++)
        {
            Console.Write(spinner[i % spinner.Length]);
            Thread.Sleep(250);
            Console.Write("\b");
        }
        Console.WriteLine();
    }

    protected void Countdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i + " ");
            Thread.Sleep(1000);
        }
        Console.WriteLine();
    }

    private void LogActivity()
    {
        string logEntry = $"{DateTime.Now}: Completed {name} for {duration} seconds.";
        File.AppendAllText("activity_log.txt", logEntry + Environment.NewLine);
    }

    public abstract void Run();
}

class BreathingActivity : Activity
{
    public BreathingActivity() : base("Breathing", 
        "This activity will help you relax by walking you through breathing in and out slowly.") {}

    public override void Run()
    {
        StartMessage();
        int elapsed = 0;
        while (elapsed < duration)
        {
            Console.WriteLine("Breathe in...");
            Countdown(3);
            elapsed += 3;
            Console.WriteLine("Breathe out...");
            Countdown(3);
            elapsed += 3;
        }
        EndMessage();
    }
}

class ReflectingActivity : Activity
{
    private List<string> prompts = new List<string> {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private List<string> questions = new List<string> {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience?",
        "What did you learn about yourself?",
        "How can you keep this in mind in the future?"
    };

    public ReflectingActivity() : base("Reflection",
        "This activity will help you reflect on times in your life when you have shown strength and resilience.") {}

    public override void Run()
    {
        StartMessage();
        Random rand = new Random();
        Console.WriteLine(prompts[rand.Next(prompts.Count)]);
        int elapsed = 0;
        while (elapsed < duration)
        {
            Console.WriteLine(questions[rand.Next(questions.Count)]);
            ShowSpinner(3);
            elapsed += 3;
        }
        EndMessage();
    }
}

class ListingActivity : Activity
{
    private List<string> prompts = new List<string> {
        "What did you learn recently at church?",
        "Who influenced you the most?",
        "Who are people that you have helped this week?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity() : base("Listing",
        "This activity will help you reflect on the good things in your life by listing as many items as you can.") {}

    public override void Run()
    {
        StartMessage();
        Random rand = new Random();
        Console.WriteLine(prompts[rand.Next(prompts.Count)]);
        Console.WriteLine("You will begin listing in a few seconds...");
        Countdown(3);

        List<string> items = new List<string>();
        DateTime endTime = DateTime.Now.AddSeconds(duration);

        while (DateTime.Now < endTime)
        {
            Console.Write("Enter item: ");
            items.Add(Console.ReadLine());
        }

        Console.WriteLine($"You listed {items.Count} items!");
        EndMessage();
    }
}

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\nChoose an activity:");
            Console.WriteLine("1. Breathing");
            Console.WriteLine("2. Reflection");
            Console.WriteLine("3. Listing");
            Console.WriteLine("4. View Activity Log"); // <-- exceeded requirement
            Console.WriteLine("5. Quit");

            string choice = Console.ReadLine();
            Activity activity = null;

            switch (choice)
            {
                case "1": activity = new BreathingActivity(); break;
                case "2": activity = new ReflectingActivity(); break;
                case "3": activity = new ListingActivity(); break;
                case "4": ShowLog(); break;
                case "5": return;
            }

            activity?.Run();
        }
    }

    private static void ShowLog()
    {
        Console.WriteLine("\n=== Activity Log ===");
        if (File.Exists("activity_log.txt"))
        {
            string[] logEntries = File.ReadAllLines("activity_log.txt");
            foreach (string entry in logEntries)
            {
                Console.WriteLine(entry);
            }
        }
        else
        {
            Console.WriteLine("No log file found yet.");
        }
        Console.WriteLine("====================");
    }
}
