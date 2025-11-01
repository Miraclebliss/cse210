using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise2 Project.");
        Console.WriteLine("What is your grade percentage? ");
        string input = Console.ReadLine();
        int gradePercentage = int.Parse(input);
        if (gradePercentage >= 90)
        {
            Console.WriteLine("Your Letter Grade is A.");
        }
        else if (gradePercentage >= 80)
        {
            Console.WriteLine("Your Letter Grade is B.");
        }
        else if (gradePercentage >= 70)
        {
            Console.WriteLine("Your Letter Grade is C.");
        }
        else if (gradePercentage >= 60)
        {
            Console.WriteLine("Your Letter Grade is D.");
        }
        else
        {
            Console.WriteLine("Your Letter Grade is F.");
        }

        Console.WriteLine("Your grade percentage is: " + gradePercentage + "%");
        
        if (gradePercentage >= 70)
        {
            Console.WriteLine("Congratulations! You have passed the course.");
        }

        else
        {
            Console.WriteLine("Unfortunately, you have not passed the course. Better luck next time!");
        }
    }
}