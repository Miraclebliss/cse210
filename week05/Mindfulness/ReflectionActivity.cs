using System;
using System.Diagnostics;
using System.Threading;

namespace MindfulnessApp
{
    public class ReflectionActivity : Activity
    {
        private string[] _prompts = new[]
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        };

        private string[] _questions = new[]
        {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?"
        };

        public ReflectionActivity()
            : base(
                  "Reflection Activity",
                  "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.")
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

            // Pick a random prompt
            string prompt = _prompts[_random.Next(_prompts.Length)];
            Console.WriteLine("Consider the following prompt:");
            Console.WriteLine();
            Console.WriteLine($"--- {prompt} ---");
            Console.WriteLine();
            Console.WriteLine("When you have something in mind, press Enter to continue.");
            Console.ReadLine();

            Stopwatch sw = Stopwatch.StartNew();
            Console.WriteLine();
            Console.WriteLine("Now consider the following questions related to your experience:");
            Console.WriteLine();

            while (sw.Elapsed.TotalSeconds < duration)
            {
                // choose a random question
                string question = _questions[_random.Next(_questions.Length)];
                Console.WriteLine($"- {question}");
                // pause and show spinner for reflection time (e.g., 5 seconds or remaining)
                int remaining = (int)Math.Max(0, duration - sw.Elapsed.TotalSeconds);
                int pause = Math.Min(5, Math.Max(1, remaining));
                ShowSpinner(pause);
            }

            sw.Stop();
        }
    }
}
