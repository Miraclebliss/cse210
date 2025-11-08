using System;
using System.Collections.Generic;
public class Resume
{
    public string _name;
    public List<Job> _jobs = new List<Job>(); // Initialize list directly

    // Method to display resume details
    public void Display()
    {
        Console.WriteLine($"Name: {_name}");
        Console.WriteLine("Jobs:");

        // Loop through all jobs in the list
        foreach (Job job in _jobs)
        {
            job.Display();
        }
    }
}