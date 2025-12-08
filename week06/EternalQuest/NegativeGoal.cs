public class NegativeGoal : Goal
{
    public NegativeGoal(string name, string description, int points)
        : base(name, description, points) { }

    public override int RecordEvent()
    {
        return -Points; // Lose points when triggered
    }

    public override string GetStatus()
    {
        return "[!]";
    }
}
