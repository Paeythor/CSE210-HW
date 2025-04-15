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
                Console.WriteLine($"Congratulations! You completed the goal '{goal.GetDetailsString()}' and earned {checklistGoal.GetBonus()} bonus points.");
            }
            else
            {
                _score += goal.GetPoints();
                Console.WriteLine($"Congratulations! You completed the goal '{goal.GetDetailsString()}' and earned {goal.GetPoints()} points.");
            }

            Console.WriteLine($"Your total score is now: {_score} points.");
        }
        else
        {
            Console.WriteLine($"You're making progress on '{goal.GetDetailsString()}'! Keep going!");
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
            writer.WriteLine(_score);
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
        if (lines.Length == 0)
        {
            Console.WriteLine("The file is empty.");
            return;
        }

        try
        {
            _score = int.Parse(lines[0]);
        }
        catch
        {
            Console.WriteLine("Failed to read score. Defaulting to 0.");
            _score = 0;
        }

        for (int i = 1; i < lines.Length; i++)
        {
            try
            {
                var parts = lines[i].Split(':');
                string type = parts[0];
                string[] details = parts[1].Split(',');
                Goal goal = CreateGoalFromString(type, details);
                _goals.Add(goal);
            }
            catch
            {
                Console.WriteLine($"Failed to parse line: {lines[i]}");
            }
        }

        Console.WriteLine("Goals loaded successfully.");
    }    private Goal CreateGoalFromString(string type, string[] details)
    {
        switch (type)
        {
            case "SimpleGoal":
                return new SimpleGoal(details[0], details[1], int.Parse(details[2]), bool.Parse(details[3]));
            case "EternalGoal":
                return new EternalGoal(details[0], details[1], int.Parse(details[2]));
            case "ChecklistGoal":
                return new ChecklistGoal(
                    details[0],
                    details[1],
                    int.Parse(details[2]),
                    int.Parse(details[3]),
                    int.Parse(details[4]),
                    int.Parse(details[5])
                );
            default:
                throw new Exception("Unknown goal type.");
        }
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
        int points = PromptForInt("Enter points: ");

        switch (choice)
        {
            case "1":
                AddGoal(new SimpleGoal(name, desc, points));
                break;
            case "2":
                AddGoal(new EternalGoal(name, desc, points));
                break;
            case "3":
                int target = PromptForInt("Enter target count: ");
                int completed = PromptForInt("Enter amount already completed: ");
                int bonus = PromptForInt("Enter bonus points: ");
                AddGoal(new ChecklistGoal(name, desc, points, target, completed, bonus));
                break;
            default:
                Console.WriteLine("Invalid choice.");
                break;
        }
    }

    private int PromptForInt(string message)
    {
        while (true)
        {
            Console.Write(message);
            string input = Console.ReadLine();
            if (int.TryParse(input, out int result))
                return result;

            Console.WriteLine("Invalid number. Try again.");
        }
    }

    public void ShowGoalFileFormatInstructions()
    {
        Console.WriteLine("\n--- GOAL FILE FORMAT GUIDE ---");
        Console.WriteLine("First line = Total Score");
        Console.WriteLine("Then use the following formats:");
        Console.WriteLine("SimpleGoal:Name,Description,Points,IsComplete");
        Console.WriteLine("EternalGoal:Name,Description,Points");
        Console.WriteLine("ChecklistGoal:Name,Description,Points,Target,AmountCompleted,Bonus");
        Console.WriteLine("Example:");
        Console.WriteLine("100");
        Console.WriteLine("SimpleGoal:Read Book,Read a C# book,50,False");
        Console.WriteLine("EternalGoal:Run Daily,Go for a daily jog,10");
        Console.WriteLine("ChecklistGoal:Workout,Complete 10 workouts,20,10,3,100");
        Console.WriteLine("--------------------------------\n");
    }

    public void MarkGoalAsComplete(int index)
    {
        if (index < 0 || index >= _goals.Count)
        {
            Console.WriteLine("Invalid index. Please choose a valid goal.");
            return;
        }

        var goal = _goals[index];

        if (goal is SimpleGoal simpleGoal)
        {
            simpleGoal.MarkAsComplete();
        }
        else
        {
            Console.WriteLine("This goal cannot be marked as complete directly.");
        }
    }

    public void ShowMenu()
    {
        Console.WriteLine("Goal Manager Menu:");
        Console.WriteLine("1. Add Goal");
        Console.WriteLine("2. List Goals");
        Console.WriteLine("3. Record Event");
        Console.WriteLine("4. Mark Goal as Complete");
        Console.WriteLine("5. Display Total Score");
        Console.WriteLine("6. Save Goals");
        Console.WriteLine("7. Load Goals");
        Console.WriteLine("8. Exit");

        Console.Write("Choose an option: ");
        string choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                PromptAndAddGoal();
                break;
            case "2":
                ListGoals();
                break;
            case "3":
                Console.Write("Enter the index of the goal to record an event: ");
                int recordIndex = int.Parse(Console.ReadLine());
                RecordEvent(recordIndex);
                break;
            case "4":
                Console.Write("Enter the index of the goal to mark as complete: ");
                int completeIndex = int.Parse(Console.ReadLine());
                MarkGoalAsComplete(completeIndex);
                break;
            case "5":
                DisplayScore();
                break;
            case "6":
                Console.Write("Enter filename to save goals: ");
                string saveFile = Console.ReadLine();
                SaveGoals(saveFile);
                break;
            case "7":
                Console.Write("Enter filename to load goals: ");
                string loadFile = Console.ReadLine();
                LoadGoals(loadFile);
                break;
            case "8":
                Environment.Exit(0);
                break;
            default:
                Console.WriteLine("Invalid option.");
                break;
        }
    }
}
