using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score = 0;

    public int GetTotalScore()
    {
        return _score;
    }
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
        if (index < 0 || index >= _goals.Count)
        {
            Console.WriteLine("Invalid index. Please choose a valid goal.");
            return;
        }

        var goal = _goals[index];
        goal.RecordEvent();

        if (goal.IsComplete())
        {
            if (goal is ChecklistGoal checklistGoal)
            {
                _score += checklistGoal.GetBonus();
            }
            else
            {
                _score += goal.GetPoints();
            }
        }
    }

    public void ListGoals()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals available.");
            return;
        }

        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i}. {_goals[i].GetDetailsString()}");
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

        Console.WriteLine("Goals saved successfully.");
    }

    public void LoadGoals(string filename)
    {
        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found.");
            return;
        }

        _goals.Clear();
        var lines = File.ReadAllLines(filename);

        foreach (var line in lines)
        {
            var parts = line.Split(':');
            var type = parts[0];
            var details = parts[1].Split(',');

            try
            {
                if (type == "SimpleGoal")
                {
                    string name = details[0];
                    string desc = details[1];
                    int points = int.Parse(details[2]);
                    bool isComplete = bool.Parse(details[3]);
                    var goal = new SimpleGoal(name, desc, points);
                    if (isComplete) goal.RecordEvent();
                    _goals.Add(goal);
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
            catch
            {
                Console.WriteLine($"Failed to parse goal: {line}");
            }
        }

        Console.WriteLine("Goals loaded successfully.");
    }

    public void PromptAndAddGoal()
    {
        Console.WriteLine("Choose goal type:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("Enter option (1-3): ");
        string choice = Console.ReadLine();

        Console.Write("Enter goal name: ");
        string name = Console.ReadLine();
        Console.Write("Enter description: ");
        string desc = Console.ReadLine();
        Console.Write("Enter points: ");
        int points = int.Parse(Console.ReadLine());

        switch (choice)
        {
            case "1":
                AddGoal(new SimpleGoal(name, desc, points));
                break;
            case "2":
                AddGoal(new EternalGoal(name, desc, points));
                break;
            case "3":
                Console.Write("Enter target count: ");
                int target = int.Parse(Console.ReadLine());
                Console.Write("Enter amount already completed: ");
                int completed = int.Parse(Console.ReadLine());
                Console.Write("Enter bonus points: ");
                int bonus = int.Parse(Console.ReadLine());
                AddGoal(new ChecklistGoal(name, desc, points, target, completed, bonus));
                break;
            default:
                Console.WriteLine("Invalid choice.");
                break;
        }
    }

    public void ShowGoalFileFormatInstructions()
    {
        Console.WriteLine("\n--- GOAL FILE FORMAT GUIDE ---");
        Console.WriteLine("To manually add goals in a text file, use the following formats:");
        Console.WriteLine("SimpleGoal:Name,Description,Points,IsComplete");
        Console.WriteLine("EternalGoal:Name,Description,Points");
        Console.WriteLine("ChecklistGoal:Name,Description,Points,Target,AmountCompleted,Bonus");
        Console.WriteLine("Example:");
        Console.WriteLine("SimpleGoal:Read Book,Read a C# book,50,False");
        Console.WriteLine("EternalGoal:Run Daily,Go for a daily jog,10");
        Console.WriteLine("ChecklistGoal:Workout,Complete 10 workouts,20,10,3,100");
        Console.WriteLine("--------------------------------\n");
    }
}