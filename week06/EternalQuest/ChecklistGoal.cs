using System;

public class ChecklistGoal : Goal
{
    public int Target { get; set; }
    public int AmountCompleted { get; set; }
    public int Bonus { get; set; }

    public ChecklistGoal(string name, string description, int points, int target, int amountCompleted, int bonus)
        : base(name, description, points)
    {
        Target = target;
        AmountCompleted = amountCompleted;
        Bonus = bonus;
    }

    public override void RecordEvent()
    {
        if (IsComplete())
        {
            Console.WriteLine($"Goal '{_shortName}' is already complete. No further events can be recorded.");
        }
        else
        {
            AmountCompleted++;
            Console.WriteLine($"Event recorded for goal '{_shortName}'. Progress: {AmountCompleted}/{Target}");
        }
    }

    public override bool IsComplete()
    {
        return AmountCompleted >= Target;
    }

    public override string GetStringRepresentation()
    {
        return $"ChecklistGoal:{_shortName},{_description},{_points},{Target},{AmountCompleted},{Bonus}";
    }

    public override string GetDetailsString()
    {
        string completionStatus = IsComplete() ? "[Complete]" : "[In Progress]";
        return $"{_shortName} ({_description}) - Completed {AmountCompleted}/{Target} times. {completionStatus} Bonus: {Bonus} points.";
    }

    public int GetBonus()
    {
        return Bonus;
    }
}
