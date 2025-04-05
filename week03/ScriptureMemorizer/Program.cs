using System;
using System.Collections.Generic;


class Program
{
    static void Main(string[] args)
    {
        int _count = 0;

        while (true)
        {
            StandardWorks library = new StandardWorks();
            Console.WriteLine("What are the Verses, Chapters and/or Books do you seek to master? (i.e. Ether 12:27)");
            string input = Console.ReadLine();
            if (input.Trim().ToLower() == "quit")
            {
                Console.WriteLine("Now leaving the program...");
                break;
            }
            Console.WriteLine("What portion of the text percentage-wise (1-100) would you like to start with?");
            int startDifficulty = int.Parse(Console.ReadLine());
            Console.WriteLine("Thank you so much for your entry. Seeking your scripture diligently....");

            var scriptureList = library.DefineLibrary(input);
            if (scriptureList.Count == 0)
            {
                Console.WriteLine("No matches found in the scriptures for that. Please try again.");
                continue;
            }
            while (_count < scriptureList.Count)
            {
                Console.WriteLine("Scripture: " + scriptureList[_count].GetText());
                var scripture = scriptureList[_count];
                var game = new ScriptureMasteryGame(scripture, startDifficulty);
                bool next = game.Start();

                if (next)
                {
                    _count++;
                }
                else
                {
                    break; 
                }
            }
            Console.WriteLine("Do you want to try more scriptures? (y/n)");
            string retryInput = Console.ReadLine();
            if (retryInput.ToLower() != "y")
            {
                break;
            }
            _count = 0;
        }
    }
}
