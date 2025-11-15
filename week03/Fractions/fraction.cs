using System;
public class Fraction
{
    // Numerator of the fraction
    private int _top;

    // Denominator of the fraction. Must not be zero.
    private int _bottom;

    // Default constructor. Initializes the fraction to 1/1.
    public Fraction()
    {
        _top = 1;
        _bottom = 1;
    }

    // Constructs a fraction with the specified numerator and denominator.
    // Throws <see cref="ArgumentException"/> if the denominator is zero.
    
    // <param name="top">Numerator (integer)</param>
    // <param name="bottom">Denominator (integer, non-zero)</param>
    public Fraction(int top, int bottom)
    {
        if (bottom == 0) throw new ArgumentException("Denominator cannot be zero.", nameof(bottom));
        _top = top;
        _bottom = bottom;
    }

    // Returns the fraction as a string in the form "top/bottom".
    public string GetFractionString()
    {
        return $"{_top}/{_bottom}";
    }

    // Returns the decimal value of the fraction (as a double).
    public double GetDecimalValue()
    {
        // Cast to double first to ensure floating-point division
        return (double)_top / _bottom;
    }

    // Gets the numerator (top) value.
    public int GetTop() => _top;

    /// Gets the denominator (bottom) value.
    public int GetBottom() => _bottom;

    /// Sets the numerator (top) value.
    /// <param name="value">New numerator</param>
    public void SetTop(int value) => _top = value;

    // Sets the denominator (bottom) value. Throws <see cref="ArgumentException"/>
    // if an attempt is made to set the denominator to zero.
    // <param name="value">New denominator (non-zero)</param>
    public void SetBottom(int value)
    {
        if (value == 0) throw new ArgumentException("Denominator cannot be zero.", nameof(value));
        _bottom = value;
    }
}
