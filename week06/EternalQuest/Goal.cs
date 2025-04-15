using System;

public abstract class Goal
{
    protected string _shortName;
    protected string _description;
    protected int _points;

    public Goal(string shortName, string description, int points)
    {
        _shortName = shortName;
        _description = description;
        _points = points;
    }

    public abstract void RecordEvent();
    public abstract bool IsComplete();

    public virtual int GetPoints()
    {
        return _points;
    }

    public virtual string GetDetailsString()
    {
        return IsComplete()
            ? $"[X] {_shortName}: {_description} - {_points} points"
            : $"[ ] {_shortName}: {_description} - {_points} points";
    }

    public abstract string GetStringRepresentation();
}
