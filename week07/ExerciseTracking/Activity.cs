using System;

public abstract class Activity
{
    private string _date;
    private int _lengthMinutes;

    public Activity(string date, int lengthMinutes)
    {
        _date = date;
        _lengthMinutes = lengthMinutes;
    }

    public string GetDate()
    {
        return _date;
    }

    public int GetLengthMinutes()
    {
        return _lengthMinutes;
    }

    // ABSTRACT METHODS (must be overridden)
    public abstract double GetDistance(); // miles or km
    public abstract double GetSpeed();    // mph or kph
    public abstract double GetPace();     // min per mile or min per km

    // VIRTUAL SUMMARY USING POLYMORPHISM
    public virtual string GetSummary()
    {
        return $"{_date} {GetType().Name} ({_lengthMinutes} min) - " +
               $"Distance {GetDistance():0.0}, " +
               $"Speed {GetSpeed():0.0}, " +
               $"Pace {GetPace():0.00}";
    }
}
