using System;

using System;

class Program
{
    static void Main(string[] args)
    {
        // Test all three constructors
        Fraction fraction1 = new Fraction();
        Console.WriteLine($"Fraction 1: {fraction1.GetFractionString()} = {fraction1.GetDecimalValue()}");

        Fraction fraction2 = new Fraction(5,1);
        Console.WriteLine($"Fraction 2: {fraction2.GetFractionString()} = {fraction2.GetDecimalValue()}");

        Fraction fraction3 = new Fraction(3, 4);
        Console.WriteLine($"Fraction 3: {fraction3.GetFractionString()} = {fraction3.GetDecimalValue()}");

        // Test getters and setters
        Console.WriteLine("\nTesting getters and setters:");
        
        Fraction testFraction = new Fraction(2, 3);
        Console.WriteLine($"Original: {testFraction.GetFractionString()} = {testFraction.GetDecimalValue()}");
        
        // Use setters to change values
        testFraction.SetTop(7);
        testFraction.SetBottom(8);
        
        // Use getters to retrieve new values
        Console.WriteLine($"After changes - Top: {testFraction.GetTop()}, Bottom: {testFraction.GetBottom()}");
        Console.WriteLine($"Updated: {testFraction.GetFractionString()} = {testFraction.GetDecimalValue()}");

        // Test additional fractions
        Console.WriteLine("\nAdditional fractions:");
        Fraction fraction4 = new Fraction(1, 3);
        Console.WriteLine($"Fraction 4: {fraction4.GetFractionString()} = {fraction4.GetDecimalValue()}");

        // Create 6/7 using setters
        Fraction fraction5 = new Fraction();
        fraction5.SetTop(6);
        fraction5.SetBottom(7);
        Console.WriteLine($"Fraction 5: {fraction5.GetFractionString()} = {fraction5.GetDecimalValue()}");
    }
}