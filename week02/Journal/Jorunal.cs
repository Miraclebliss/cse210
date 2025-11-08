using System;
using System.Collections.Generic;
public class Journal
{
    public List<Entry> _entries;
    public List<string> _prompts;

    public Journal()
    {
        _entries = new List<Entry>();
        _prompts = new List<string>()
        {
            "What moment today am I most proud of?",
            "Who made my day better, and how?",
            "What’s one thing I did today that aligned with my goals?",
            "What did I avoid today that I probably should’ve faced?",
            "What new idea or insight came to me today?",
            "How did I show kindness today?",
            "What energized me the most today?",
            "What drained my energy today?",
            "What fear did I face or manage today?",
            "What beauty did I notice around me today?",
            "Who inspired me today?",
            "What’s one thing I learned about myself today?",
            "How did I take care of my body today?",
            "What would I name today if it were a chapter in my story?",
            "What surprised me today — good or bad?",
            "Did I express gratitude or love to someone today?",
            "What conversation stuck with me today?",
            "What small victory did I celebrate today?",
            "What would I like to remember about today a year from now?",
            "How did I practice patience today?"
        };
    }
    public void AddEntry(Entry entry)
    {
        _entries.Add(entry);

    }
    public void DisplayAll()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("No entries to display.");
            return;
        }
        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }

    public void SaveToFile(string filename)
    {
        try
        {
            using (StreamWriter outputFile = new StreamWriter(filename))
            {
                foreach (Entry entry in _entries)
                {
                    outputFile.WriteLine($"{entry._date}|{entry._promptText}|{entry._entryText}");
                }
            }
            Console.WriteLine($"Journal saved to {filename} successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving file: {ex.Message}");
        }
    }

    public void LoadFromFile(string filename)
    {
        try
        {
            if (!File.Exists(filename))
            {
                Console.WriteLine("File not found.");
                return;
            }

            _entries.Clear();
            string[] lines = File.ReadAllLines(filename);

            foreach (string line in lines)
            {
                string[] parts = line.Split('|');
                
                if (parts.Length >= 3)
                {
                    Entry loadedEntry = new Entry
                    {
                        _date = parts[0],
                        _promptText = parts[1],
                        _entryText = parts[2]
                    };
                    _entries.Add(loadedEntry);
                }
            }
            Console.WriteLine($"Journal loaded from {filename} successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading file: {ex.Message}");
        }
    }

    public string GetRandomPrompt()
    {
        Random random = new Random();
        int index = random.Next(_prompts.Count);
        return _prompts[index];
    }
}

    
    

    