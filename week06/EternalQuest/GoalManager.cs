using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    public int Score { get; private set; }
    private List<Goal> _goals = new();
    private StreakTracker _streaks = new();

    public void AddGoal(Goal goal)
    {
        _goals.Add(goal);
    }

    public void ListGoals()
    {
        Console.WriteLine("\n=== Your Goals ===");
        int i = 1;
        foreach (var g in _goals)
        {
            Console.WriteLine($"{i}. {g.GetStatus()} {g.Name} - {g.Description}");
            i++;
        }
    }

    public void Save(string filename)
    {
        using StreamWriter sw = new(filename);
        sw.WriteLine(Score);
        foreach (var g in _goals)
            sw.WriteLine(g.SaveString());
    }

    public void Load(string filename)
    {
        if (!File.Exists(filename)) return;

        string[] lines = File.ReadAllLines(filename);
        Score = int.Parse(lines[0]);

        for (int i = 1; i < lines.Length; i++)
        {
            string[] data = lines[i].Split('|');
            string type = data[0];
            string name = data[1];
            string desc = data[2];
            int points = int.Parse(data[3]);

            if (type == "SimpleGoal")
                AddGoal(new SimpleGoal(name, desc, points));

            else if (type == "EternalGoal")
                AddGoal(new EternalGoal(name, desc, points));

            else if (type == "ChecklistGoal")
            {
                int target = int.Parse(data[5]);
                int current = int.Parse(data[6]);
                int bonus = int.Parse(data[7]);

                var cg = new ChecklistGoal(name, desc, points, target, bonus);

                // “hack” — load progress by simulating events
                for (int c = 0; c < current; c++)
                    cg.RecordEvent();

                AddGoal(cg);
            }
            else if (type == "NegativeGoal")
                AddGoal(new NegativeGoal(name, desc, points));
        }
    }

    public void RecordEvent(int index)
    {
        var goal = _goals[index];

        int basePoints = goal.RecordEvent();
        int streakBonus = _streaks.UpdateStreak();

        Score += basePoints + streakBonus;

        Console.WriteLine($"\n🔥 You earned {basePoints} pts!");
        if (streakBonus > 0)
            Console.WriteLine($"🔥 Streak bonus: {streakBonus} pts!");

        Console.WriteLine($"✨ Total Score: {Score}\n");
    }
}
