using System;
using System.IO;

class Program
{
    static void Main()
    {
        Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();
        
        bool exitProgram = false;

        while (!exitProgram)
        {
            Console.Clear();
            Console.WriteLine("Journal Program");
            Console.WriteLine("1. Write a New Entry");
            Console.WriteLine("2. Display Journal");
            Console.WriteLine("3. Save Journal to File");
            Console.WriteLine("4. Load Journal from File");
            Console.WriteLine("5. Exit");
            Console.Write("Select an option: ");
            
            string option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    WriteNewEntry(journal, promptGenerator);
                    break;
                case "2":
                    DisplayJournal(journal);
                    break;
                case "3":
                    SaveJournal(journal);
                    break;
                case "4":
                    LoadJournal(journal);
                    break;
                case "5":
                    exitProgram = true;
                    break;
                default:
                    Console.WriteLine("Invalid option. Try again.");
                    break;
            }
        }
    }

    // Write a new journal entry
    static void WriteNewEntry(Journal journal, PromptGenerator promptGenerator)
    {
        string prompt = promptGenerator.GetRandomPrompt();
        Console.WriteLine("\nPrompt: " + prompt);
        Console.Write("Your response: ");
        string response = Console.ReadLine();
        
        Entry newEntry = new Entry(prompt, response);
        journal.AddEntry(newEntry);
        
        Console.WriteLine("Entry added successfully!");
        Console.ReadLine();  // Pause for user to read the message
    }

    // Display all journal entries
    static void DisplayJournal(Journal journal)
    {
        Console.WriteLine("\nYour Journal Entries:\n");
        journal.DisplayAll();
        Console.ReadLine();  // Pause for user to read the entries
    }

    // Save the journal entries to a file
    static void SaveJournal(Journal journal)
    {
        Console.Write("\nEnter filename to save journal: ");
        string filename = Console.ReadLine();
        
        journal.SaveToFile(filename);
        Console.WriteLine("Journal saved successfully!");
        Console.ReadLine();  // Pause for user to read the message
    }

    // Load the journal entries from a file
    static void LoadJournal(Journal journal)
    {
        Console.Write("\nEnter filename to load journal: ");
        string filename = Console.ReadLine();
        
        journal.LoadFromFile(filename);
        Console.WriteLine("Journal loaded successfully!");
        Console.ReadLine();  // Pause for user to read the message
    }
}
