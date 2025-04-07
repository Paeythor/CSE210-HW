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

    // Abstract methods that must be implemented by derived classes
    public abstract void RecordEvent();
    public abstract bool IsComplete();

    // Virtual method to get the points of the goal
    public virtual int GetPoints()
    {
        return _points;
    }

    // Get the details of the goal: short name, description, and points
    public virtual string GetDetailsString()
    {
        // Including points and completion status
        return IsComplete() 
            ? $"[X] {_shortName}: {_description} - {_points} points" 
            : $"[ ] {_shortName}: {_description} - {_points} points";
    }

    // Abstract method for getting string representation of the goal for saving purposes
    public abstract string GetStringRepresentation();
}
