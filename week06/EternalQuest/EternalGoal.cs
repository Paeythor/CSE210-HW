public class EternalGoal : Goal
{
    public EternalGoal(string shortName, string description, int points)
        : base(shortName, description, points)
    {
    }

    public override void RecordEvent()
    {
        Console.WriteLine($"Goal '{_shortName}' recorded. {_points} points earned.");
        // Eternal Goals don't change completion status, as they are always active.
    }
    

    public override bool IsComplete()
    {
        return false; 
    }

    public override string GetStringRepresentation()
    {
        return $"EternalGoal:{_shortName},{_description},{_points}";
    }
}
