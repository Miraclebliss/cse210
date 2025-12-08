public class SimpleGoal : Goal
{
    public SimpleGoal(string name, string description, int points)
        : base(name, description, points) { }

    public override int RecordEvent()
    {
        if (!IsComplete)
        {
            // Mark as done forever
            typeof(Goal)
                .GetMethod("MarkComplete", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                .Invoke(this, null);

            return Points;
        }
        return 0;
    }

    public override string GetStatus()
    {
        return IsComplete ? "[X]" : "[ ]";
    }
}
