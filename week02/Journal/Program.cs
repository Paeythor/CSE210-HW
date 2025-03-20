using System;

public class Program
{
    public static void Main()
    {
        Journal journal = new Journal();
        bool running = true;

        while (running)
        {
            Console.Clear();
            Console.WriteLine("Welcome to your Journal Program!");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display all journal entries");
            Console.WriteLine("3. Save journal to a file");
            Console.WriteLine("4. Load journal from a file");
            Console.WriteLine("5. Exit");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.WriteLine("Please write your response:");
                    string response = Console.ReadLine();
                    journal.AddEntry(response);
                    Console.WriteLine("Entry added.");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    break;

                case "2":
                    journal.DisplayEntries();
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    break;

                case "3":
                    Console.WriteLine("Enter filename to save journal:");
                    string saveFile = Console.ReadLine();
                    journal.SaveToFile(saveFile);
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    break;

                case "4":
                    Console.WriteLine("Enter filename to load journal:");
                    string loadFile = Console.ReadLine();
                    journal.LoadFromFile(loadFile);
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    break;

                case "5":
                    running = false;
                    Console.WriteLine("Goodbye!");
                    break;

                default:
                    Console.WriteLine("Invalid option, please try again.");
                    break;
            }
        }
    }
}
