using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    public void AddGoal(Goal goal)
    {
        _goals.Add(goal);
    }

    public void RecordEvent(int index)
    {
        var goal = _goals[index];
        goal.RecordEvent();

        // Adjusted logic to properly add points
        if (goal.IsComplete())
        {
            // For ChecklistGoal, add the bonus points
            if (goal is ChecklistGoal checklistGoal)
            {
                _score += checklistGoal.GetBonus();  // Use GetBonus() for ChecklistGoal
            }
            else
            {
                _score += goal.GetPoints();  // For other goal types, use GetPoints() to add points
            }
        }
    }

    public void ListGoals()
    {
        foreach (var goal in _goals)
        {
            Console.WriteLine(goal.GetDetailsString());
        }
    }

    public void DisplayScore()
    {
        Console.WriteLine($"Your total score is: {_score}");
    }

    public void SaveGoals(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (var goal in _goals)
            {
                writer.WriteLine(goal.GetStringRepresentation());
            }
        }
    }

    public void LoadGoals(string filename)
    {
        var lines = File.ReadAllLines(filename);
        foreach (var line in lines)
        {
            var parts = line.Split(":");
            var type = parts[0];
            var details = parts[1].Split(",");

            if (type == "SimpleGoal")
            {
                _goals.Add(new SimpleGoal(details[0], details[1], int.Parse(details[2])));
            }
            else if (type == "EternalGoal")
            {
                _goals.Add(new EternalGoal(details[0], details[1], int.Parse(details[2])));
            }
            else if (type == "ChecklistGoal")
            {
                _goals.Add(new ChecklistGoal(details[0], details[1], int.Parse(details[2]), int.Parse(details[3]), int.Parse(details[4]), int.Parse(details[5])));
            }
        }
    }
}
