using System;

class Program
{
    /*
     EXCEEDED REQUIREMENTS:
     - Added Negative Goals (lose points for bad habits)
     - Added Streak System (daily bonuses)
     - Added Badge/Levels logic
     - Multi-class architecture with polymorphism beyond requirements
     - Expanded save/load system to handle extra data
    */

    static void Main(string[] args)
    {
        GoalManager gm = new();
        bool running = true;

        while (running)
        {
            Console.WriteLine("\n=== Eternal Quest Menu ===");
            Console.WriteLine("1. Create Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Record Event");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Load");
            Console.WriteLine("6. Quit");

            Console.Write("Choose: ");
            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    CreateGoal(gm);
                    break;

                case "2":
                    gm.ListGoals();
                    break;

                case "3":
                    Console.Write("Goal number: ");
                    gm.RecordEvent(int.Parse(Console.ReadLine()) - 1);
                    break;

                case "4":
                    Console.Write("Filename: ");
                    gm.Save(Console.ReadLine());
                    break;

                case "5":
                    Console.Write("Filename: ");
                    gm.Load(Console.ReadLine());
                    break;

                case "6":
                    running = false;
                    break;
            }
        }
    }

    static void CreateGoal(GoalManager gm)
    {
        Console.WriteLine("\nGoal Types:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.WriteLine("4. Negative Goal");

        Console.Write("Type: ");
        string t = Console.ReadLine();

        Console.Write("Name: ");
        string n = Console.ReadLine();

        Console.Write("Description: ");
        string d = Console.ReadLine();

        Console.Write("Points: ");
        int p = int.Parse(Console.ReadLine());

        if (t == "1")
            gm.AddGoal(new SimpleGoal(n, d, p));
        else if (t == "2")
            gm.AddGoal(new EternalGoal(n, d, p));
        else if (t == "3")
        {
            Console.Write("Target count: ");
            int tc = int.Parse(Console.ReadLine());
            Console.Write("Bonus: ");
            int b = int.Parse(Console.ReadLine());

            gm.AddGoal(new ChecklistGoal(n, d, p, tc, b));
        }
        else if (t == "4")
            gm.AddGoal(new NegativeGoal(n, d, p));
    }
}
