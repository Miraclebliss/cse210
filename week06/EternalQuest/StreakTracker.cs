using System;

public class StreakTracker
{
    private int _streak;
    private DateTime _lastRecorded;

    public int Streak => _streak;

    public StreakTracker()
    {
        _streak = 0;
        _lastRecorded = DateTime.MinValue;
    }

    public int UpdateStreak()
    {
        if (_lastRecorded.Date == DateTime.Now.Date)
        {
            return 0;
        }
        else if (_lastRecorded.Date == DateTime.Now.AddDays(-1).Date)
        {
            _streak++;
        }
        else
        {
            _streak = 1;
        }

        _lastRecorded = DateTime.Now;
        return _streak * 10; // reward intensifies
    }
}
