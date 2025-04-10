using System;

class Program
{
    static void Main()
    {
        GoalManager manager = new GoalManager();
        bool running = true;

        while (running)
        {
            Console.Clear();
            Console.WriteLine("Goal Management System");
            Console.WriteLine("-----------------------");
            Console.WriteLine("1. Add Simple Goal");
            Console.WriteLine("2. Add Eternal Goal");
            Console.WriteLine("3. Add Checklist Goal");
            Console.WriteLine("4. List Goals");
            Console.WriteLine("5. Record Event");
            Console.WriteLine("6. Display Score");
            Console.WriteLine("7. Save Goals");
            Console.WriteLine("8. Load Goals");
            Console.WriteLine("9. Exit");
            Console.Write("Choose an option (1-9): ");
            
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddSimpleGoal(manager);
                    break;
                case "2":
                    AddEternalGoal(manager);
                    break;
                case "3":
                    AddChecklistGoal(manager);
                    break;
                case "4":
                    manager.ListGoals();
                    break;
                case "5":
                    RecordEvent(manager);
                    break;
                case "6":
                    manager.DisplayScore();
                    break;
                case "7":
                    SaveGoals(manager);
                    break;
                case "8":
                    LoadGoals(manager);
                    break;
                case "9":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }

            if (running)
            {
                Console.WriteLine("\nPress Enter to continue...");
                Console.ReadLine();
            }
        }
    }

    static void AddSimpleGoal(GoalManager manager)
    {
        Console.Write("Enter goal short name: ");
        string shortName = Console.ReadLine();
        Console.Write("Enter goal description: ");
        string description = Console.ReadLine();
        Console.Write("Enter points for the goal: ");
        int points = int.Parse(Console.ReadLine());

        SimpleGoal goal = new SimpleGoal(shortName, description, points);
        manager.AddGoal(goal);
        Console.WriteLine("Simple Goal added successfully.");
    }

    static void AddEternalGoal(GoalManager manager)
    {
        Console.Write("Enter goal short name: ");
        string shortName = Console.ReadLine();
        Console.Write("Enter goal description: ");
        string description = Console.ReadLine();
        Console.Write("Enter points for the goal: ");
        int points = int.Parse(Console.ReadLine());

        EternalGoal goal = new EternalGoal(shortName, description, points);
        manager.AddGoal(goal);
        Console.WriteLine("Eternal Goal added successfully.");
    }

    static void AddChecklistGoal(GoalManager manager)
    {
        Console.Write("Enter goal short name: ");
        string shortName = Console.ReadLine();
        Console.Write("Enter goal description: ");
        string description = Console.ReadLine();
        Console.Write("Enter points for the goal: ");
        int points = int.Parse(Console.ReadLine());
        Console.Write("Enter target for the goal: ");
        int target = int.Parse(Console.ReadLine());
        Console.Write("Enter amount completed: ");
        int amountCompleted = int.Parse(Console.ReadLine());
        Console.Write("Enter bonus points: ");
        int bonus = int.Parse(Console.ReadLine());

        ChecklistGoal goal = new ChecklistGoal(shortName, description, points, target, amountCompleted, bonus);
        manager.AddGoal(goal);
        Console.WriteLine("Checklist Goal added successfully.");
    }
    static void RecordEvent(GoalManager manager)
    {
        Console.Write("Enter the index of the goal to record an event: ");
        int index = int.Parse(Console.ReadLine());
        manager.RecordEvent(index);
        Console.WriteLine("Event recorded successfully.");
    }

    static void SaveGoals(GoalManager manager)
    {
        Console.Write("Enter the filename to save goals: ");
        string filename = Console.ReadLine();
        manager.SaveGoals(filename);
        Console.WriteLine("Goals saved successfully.");
    }

    static void LoadGoals(GoalManager manager)
    {
        Console.Write("Enter the filename to load goals: ");
        string filename = Console.ReadLine();
        manager.LoadGoals(filename);
        Console.WriteLine("Goals loaded successfully.");
    }
}
