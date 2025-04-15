using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main()
    {
        GoalManager manager = new GoalManager();
        bool running = true;

        while (running)
        {
            Console.Clear();
            Console.WriteLine($"Current Score: {manager.GetTotalScore()} points");
            Console.WriteLine();
            Console.WriteLine("Menu Options");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Save Goals");
            Console.WriteLine("4. Load Goals");
            Console.WriteLine("5. Record Event");
            Console.WriteLine("6. Quit");
            Console.Write("Select a choice from the menu: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateNewGoal(manager);
                    break;
                case "2":
                    manager.ListGoals();
                    break;
                case "3":
                    SaveGoals(manager);
                    break;
                case "4":
                    LoadGoals(manager);
                    break;
                case "5":
                    RecordEvent(manager);
                    break;
                case "6":
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

    static void CreateNewGoal(GoalManager manager)
    {
        Console.Clear();
        Console.WriteLine("The Types of Goals are:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("Which type of goal would you like to create? ");

        string goalType = Console.ReadLine();

        switch (goalType)
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
            default:
                Console.WriteLine("Invalid option. Returning to main menu.");
                break;
        }
    }

    static int PromptForInt(string message)
    {
        while (true)
        {
            Console.Write(message);
            string input = Console.ReadLine();
            if (int.TryParse(input, out int result))
            {
                return result;
            }
            Console.WriteLine("Invalid input. Please enter a valid number.");
        }
    }

    static void AddSimpleGoal(GoalManager manager)
    {
        Console.Write("Enter goal short name: ");
        string shortName = Console.ReadLine();
        Console.Write("Enter goal description: ");
        string description = Console.ReadLine();
        int points = PromptForInt("Enter points for the goal: ");

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
        int points = PromptForInt("Enter points for the goal: ");

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
        int points = PromptForInt("Enter points for the goal: ");
        int target = PromptForInt("Enter target for the goal: ");
        int amountCompleted = PromptForInt("Enter amount completed: ");
        int bonus = PromptForInt("Enter bonus points: ");

        ChecklistGoal goal = new ChecklistGoal(shortName, description, points, target, amountCompleted, bonus);
        manager.AddGoal(goal);
        Console.WriteLine("Checklist Goal added successfully.");
    }

    static void RecordEvent(GoalManager manager)
    {
        int index = PromptForInt("Enter the index of the goal to record an event: ");
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
