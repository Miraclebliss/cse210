using System;

public abstract class Goal
{
    private string _name;
    private string _description;
    private int _points;
    private bool _completed;

    public string Name => _name;
    public string Description => _description;
    public int Points => _points;
    public virtual bool IsComplete => _completed;

    public Goal(string name, string description, int points)
    {
        _name = name;
        _description = description;
        _points = points;
        _completed = false;
    }

    public abstract int RecordEvent();
    public abstract string GetStatus();

    public virtual string SaveString()
    {
        return $"{GetType().Name}|{Name}|{Description}|{Points}|{IsComplete}";
    }

    protected void MarkComplete()
    {
        _completed = true;
    }
}
