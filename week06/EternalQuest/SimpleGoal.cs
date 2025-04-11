public class SimpleGoal : Goal
{
    private bool _isComplete;

    
    public SimpleGoal(string shortName, string description, int points)
        : base(shortName, description, points)
    {
        _isComplete = false;
    }

    
    public override void RecordEvent()
    {
        _isComplete = true;
        Console.WriteLine($"Goal '{_shortName}' completed! {_points} points earned.");
    }

    
    public override bool IsComplete()
    {
        return _isComplete;
    }

    
    public override string GetStringRepresentation()
    {
        return $"SimpleGoal:{_shortName},{_description},{_points},{_isComplete}";
    }

    
    public override string GetDetailsString()
    {
        
        return IsComplete() 
            ? $"[X] {_shortName}: {_description}" 
            : $"[ ] {_shortName}: {_description}";
    }
}
