public class SimpleGoal : Goal
{
    private bool _isComplete;

    // Constructor for SimpleGoal
    public SimpleGoal(string shortName, string description, int points)
        : base(shortName, description, points)
    {
        _isComplete = false;
    }

    // Implement the RecordEvent method
    public override void RecordEvent()
    {
        _isComplete = true;
        Console.WriteLine($"Goal '{_shortName}' completed! {_points} points earned.");
    }

    // Implement the IsComplete method
    public override bool IsComplete()
    {
        return _isComplete;
    }

    // Implement the GetStringRepresentation method
    public override string GetStringRepresentation()
    {
        return $"SimpleGoal:{_shortName},{_description},{_points},{_isComplete}";
    }

    // Implement the GetDetailsString method
    public override string GetDetailsString()
    {
        // This will display the goal's name and description, with [X] for completed or [ ] for not
        return IsComplete() 
            ? $"[X] {_shortName}: {_description}" 
            : $"[ ] {_shortName}: {_description}";
    }
}
