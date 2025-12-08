public class ChecklistGoal : Goal
{
    private int _targetCount;
    private int _currentCount;
    private int _bonus;

    public ChecklistGoal(string name, string description, int points, int targetCount, int bonus)
        : base(name, description, points)
    {
        _targetCount = targetCount;
        _bonus = bonus;
        _currentCount = 0;
    }

    public override bool IsComplete => _currentCount >= _targetCount;

    public override int RecordEvent()
    {
        _currentCount++;

        if (_currentCount >= _targetCount)
        {
            // mark complete
            typeof(Goal)
                .GetMethod("MarkComplete", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                .Invoke(this, null);

            return Points + _bonus;
        }

        return Points;
    }

    public override string GetStatus()
    {
        return IsComplete ? $"[X] Completed {_currentCount}/{_targetCount}" :
                            $"[ ] Completed {_currentCount}/{_targetCount}";
    }

    public override string SaveString()
    {
        return $"{base.SaveString()}|{_targetCount}|{_currentCount}|{_bonus}";
    }
}
