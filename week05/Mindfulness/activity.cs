using System;
using System.Diagnostics;
using System.Threading;

namespace MindfulnessApp
{
    // Base class for all activities
    public abstract class Activity
    {
        // Encapsulated member variables (private)
        private string _name;
        private string _description;
        private int _durationSeconds;

        protected Random _random = new Random();

        // Constructor
        protected Activity(string name, string description)
        {
            _name = name;
            _description = description;
            _durationSeconds = 0;
        }

        // Public getters
        public string GetName() => _name;
        public string GetDescription() => _description;
        public int GetDurationSeconds() => _durationSeconds;

        // Sets duration (called after prompting user)
        public void SetDurationSeconds(int seconds)
        {
            if (seconds < 0) seconds = 0;
            _durationSeconds = seconds;
        }

        // Template: Start runs the standard flow for all activities
        public void Start()
        {
            ShowStartingMessage();
            AskForDuration();
            PrepareToBegin();
            RunActivity();                // implemented by subclasses
            ShowEndingMessage();
        }

        // Standard starting message and prompt
        protected void ShowStartingMessage()
        {
            Console.Clear();
            Console.WriteLine($"*** {_name} ***");
            Console.WriteLine();
            Console.WriteLine(_description);
            Console.WriteLine();
        }

        // Prompt user for duration in seconds and set it
        protected void AskForDuration()
        {
            while (true)
            {
                Console.Write("Enter the duration of the activity in seconds: ");
                string input = Console.ReadLine();
                if (int.TryParse(input, out int seconds) && seconds >= 0)
                {
                    SetDurationSeconds(seconds);
                    break;
                }
                Console.WriteLine("Please enter a non-negative integer for seconds.");
            }
        }

        // Tell the user to prepare and pause for a short animated wait
        protected void PrepareToBegin()
        {
            Console.WriteLine();
            Console.WriteLine("Get ready...");
            ShowSpinner(3); // pause for 3 seconds with animation
        }

        // Ending message with pause and summary
        protected void ShowEndingMessage()
        {
            Console.WriteLine();
            Console.WriteLine("Well done!");
            ShowSpinner(2);
            Console.WriteLine($"You have completed the {GetName()} for {GetDurationSeconds()} seconds.");
            ShowSpinner(3);
        }

        // Abstract method each activity implements
        protected abstract void RunActivity();

        // Utility: spinner animation (seconds)
        protected void ShowSpinner(int seconds)
        {
            Stopwatch sw = Stopwatch.StartNew();
            string[] spinner = new[] { "|", "/", "-", "\\" };
            int i = 0;
            while (sw.Elapsed.TotalSeconds < seconds)
            {
                Console.Write(spinner[i % spinner.Length]);
                Thread.Sleep(250);
                Console.Write("\b");
                i++;
            }
            sw.Stop();
            Console.WriteLine();
        }

        // Utility: countdown display (seconds)
        protected void ShowCountdown(int seconds)
        {
            for (int i = seconds; i >= 1; i--)
            {
                Console.Write($"{i} ");
                Thread.Sleep(1000);
            }
            Console.WriteLine();
        }
    }
}
