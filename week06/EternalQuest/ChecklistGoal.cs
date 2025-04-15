using System;

public class ChecklistGoal : Goal
{
    private int _target;
    private int _completed;
    private int _bonus;

    public ChecklistGoal(string shortName, string description, int points, int target, int completed, int bonus)
        : base(shortName, description, points)
    {
        _target = target;
        _completed = completed;
        _bonus = bonus;
    }

    public override void RecordEvent()
    {
        if (_completed < _target)
        {
            _completed++;
        }
    }

    public override bool IsComplete()
    {
        return _completed >= _target;
    }

    public override int GetPoints()
    {
        return IsComplete() ? _points + _bonus : _points;
    }

    public int GetBonus()
    {
        return _bonus;
    }

    public override string GetStringRepresentation()
    {
        return $"ChecklistGoal:{_shortName},{_description},{_points},{_target},{_completed},{_bonus}";
    }
}
