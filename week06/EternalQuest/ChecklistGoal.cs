using System;

public class ChecklistGoal : Goal
{
    public int Target { get; set; }
    public int AmountCompleted { get; set; }
    public int Bonus { get; set; }

    // Constructor for ChecklistGoal
    public ChecklistGoal(string name, string description, int points, int target, int amountCompleted, int bonus)
        : base(name, description, points)  // Pass points to the base constructor
    {
        Target = target;
        AmountCompleted = amountCompleted;
        Bonus = bonus;
    }

    // Implement the RecordEvent method
    public override void RecordEvent()
    {
        AmountCompleted++;
    }

    // Implement the IsComplete method
    public override bool IsComplete()
    {
        return AmountCompleted >= Target;
    }

    // Implement the GetStringRepresentation method
    public override string GetStringRepresentation()
    {
        return $"ChecklistGoal:{_shortName},{_description},{_points},{Target},{AmountCompleted},{Bonus}";
    }

    // Implement the GetDetailsString method
    public override string GetDetailsString()
    {
        return $"{_shortName} ({_description}) - Completed {AmountCompleted}/{Target} times";
    }

    // Return bonus points for the ChecklistGoal
    public int GetBonus()
    {
        return Bonus;
    }
}
