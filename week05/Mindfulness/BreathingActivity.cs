using System;
using System.Diagnostics;
using System.Threading;

namespace MindfulnessApp
{
    public class BreathingActivity : Activity
    {
        public BreathingActivity()
            : base(
                  "Breathing Activity",
                  "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
        { }

        // Breathing alternates between "Breathe in..." and "Breathe out..."
        protected override void RunActivity()
        {
            Console.WriteLine();
            Console.WriteLine("Focus on your breathing.");
            Console.WriteLine();

            int duration = GetDurationSeconds();
            if (duration == 0)
            {
                Console.WriteLine("No time selected. Returning to menu.");
                return;
            }

            Stopwatch sw = Stopwatch.StartNew();
            bool breatheIn = true;

            // We'll use a small, consistent pause for each breath cycle (4 seconds)
            // but we check elapsed time to stop when duration is reached.
            int breathCycleSeconds = 4;

            while (sw.Elapsed.TotalSeconds < duration)
            {
                if (breatheIn)
                {
                    Console.WriteLine("Breathe in...");
                }
                else
                {
                    Console.WriteLine("Breathe out...");
                }

                // show countdown for the breath cycle or the remaining time (whichever is smaller)
                int remaining = (int)Math.Max(0, duration - sw.Elapsed.TotalSeconds);
                int countdown = Math.Min(breathCycleSeconds, Math.Max(1, remaining));
                ShowCountdown(countdown);

                breatheIn = !breatheIn;
            }

            sw.Stop();
        }
    }
}
