class Program
{
    static void Main(string[] args)
    {
        // Test Base Class
        Assignment a1 = new Assignment("Iruka Nkechi Miracle", "Multiplication");
        Console.WriteLine(a1.GetSummary());
        Console.WriteLine();

        // Test Math Assignment
        MathAssignment m1 = new MathAssignment("Milagro", "Fractions", "7.3", "8-19");
        Console.WriteLine(m1.GetSummary());
        Console.WriteLine(m1.GetHomeworkList());
        Console.WriteLine();

        // Test Writing Assignment
        WritingAssignment w1 = new WritingAssignment("Miracle Iruka", "Nigerian History", "The Beginning of the Growth of Milagro");
        Console.WriteLine(w1.GetSummary());
        Console.WriteLine(w1.GetWritingInformation());
    }
}
