using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace MindfulnessApp
{
    public class ListingActivity : Activity
    {
        private string[] _prompts = new[]
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };

        public ListingActivity()
            : base(
                  "Listing Activity",
                  "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
        { }

        protected override void RunActivity()
        {
            Console.WriteLine();

            int duration = GetDurationSeconds();
            if (duration == 0)
            {
                Console.WriteLine("No time selected. Returning to menu.");
                return;
            }

            // Select a random prompt
            string prompt = _prompts[_random.Next(_prompts.Length)];
            Console.WriteLine("List as many responses as you can to the following prompt:");
            Console.WriteLine();
            Console.WriteLine($"*** {prompt} ***");
            Console.WriteLine();

            // Give them a short countdown to prepare (e.g., 5 seconds)
            Console.WriteLine("You have a few seconds to think. Get ready...");
            ShowCountdown(5);

            // Now collect user entries until duration expires
            List<string> items = new List<string>();
            Stopwatch sw = Stopwatch.StartNew();

            Console.WriteLine($"Start listing items. You have {duration} seconds. Press Enter after each item.");
            while (sw.Elapsed.TotalSeconds < duration)
            {
                // Give the user a prompt (non-timed per input but we check elapsed after each entry)
                Console.Write("> ");
                // If user blocks on input longer than remaining time, they will still be counted; that's acceptable.
                string entry = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(entry))
                {
                    items.Add(entry.Trim());
                }

                if (sw.Elapsed.TotalSeconds >= duration)
                {
                    break;
                }
            }

            sw.Stop();

            Console.WriteLine();
            Console.WriteLine($"You listed {items.Count} items. Great job!");
            if (items.Count > 0)
            {
                Console.WriteLine("Here's what you entered:");
                foreach (var it in items)
                {
                    Console.WriteLine($" - {it}");
                }
            }
        }
    }
}
