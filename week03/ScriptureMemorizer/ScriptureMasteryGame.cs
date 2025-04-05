using System;
using System.Linq;
using System.Collections.Generic;

public class ScriptureMasteryGame
{
    private string _originalScripture;
    private Scripture _scripture;
    private List<Word> _words = new List<Word>();
    private int _difficulty;
    private List<Word> _visableWords = new List<Word>();
    private List<Word> _hiddenWords = new List<Word>();
    private Random _random = new Random();

    public ScriptureMasteryGame(Scripture scripture, int difficulty)
    {
        _scripture = scripture;
        _difficulty = difficulty;
        _words = scripture.GetWords();  // Gets words from the scripture
        _originalScripture = string.Join(" ", _words.Select(word => word.GetDisplayText()));  // Constructs the full scripture
        foreach (var word in _words)
        {
            _visableWords.Add(word);  // Initially all words are visible
        }
    }

    public Boolean Start()
    {
        Boolean _failed = false;
        Boolean _next = false;
        string hiddenScripture;
        hiddenScripture = HideWords(_difficulty);  // Hide words based on difficulty

        while (!_next)
        {
            if (_difficulty == 0)  // Mastery level: full recall
            {
                Console.Clear();
                Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n\n");
                Console.WriteLine("Mastery Level: Can you say it back outloud?");
                Console.Write("\nType in from Memory: ");
                string userAnswer = Console.ReadLine();
                if (userAnswer.Trim().ToLower() == "quit")
                {
                    Environment.Exit(0);
                }
                if (CheckAnswer(userAnswer))  // Check if the user's input matches the original
                {
                    Console.WriteLine("\nExcelsior! You did it! You a memory Master!");
                }
                else
                {
                    Console.WriteLine("\nSadly that is wrong. Never Give up! Never Surrender! Try Again!");
                    Console.WriteLine($"Correct answer: {_originalScripture}");
                    _failed = true;
                }

                Console.WriteLine("\nWhat next:");
                Console.WriteLine("1.) A new scripture");
                Console.WriteLine("2.) Repeat Scripture");
                Console.WriteLine("3.) Leave");
                Console.Write("Please type your choice: ");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        _failed = false;
                        return _next = true;
                    case "2":
                        break;
                    case "3":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice, please write the number corresponding to the selection you desire.");
                        break;
                }

                break; 
            }
            else  // Partial visibility mode
            {
                Console.Clear();
                Console.WriteLine($"Type 'Leave' to Exit\n{_difficulty}% Visable Scripture:\n{_scripture.GetBook()} {_scripture.GetChapter()}:{_scripture.GetVerse()}\n{hiddenScripture}\n");

                Console.Write("Type in from Memory: ");
                string userAnswer = Console.ReadLine();
                if (userAnswer.Trim().ToLower() == "quit" || _difficulty == 0)
                {
                    Environment.Exit(0);
                }
                if (string.IsNullOrWhiteSpace(userAnswer))
                {
                    hiddenScripture = HideWord();  // Hide another word if the answer is empty
                    continue;
                }
                if (CheckAnswer(userAnswer))
                {
                    Console.WriteLine("\nExcelsior! You did it! You a memory Master!");
                }
                else
                {
                    Console.WriteLine("\nSadly that is wrong. Never Give up! Never Surrender! Try Again!");
                    Console.WriteLine($"Correct answer: {_originalScripture}");
                    _failed = true;
                }

                Console.WriteLine("\nWould you like to:");
                Console.WriteLine("1.) Work with the next Scripture");
                if (_failed)
                {
                    Console.WriteLine("2.) Retry this scripture");
                }
                else
                {
                    Console.WriteLine("2.) Increase difficulty with this scripture");
                }
                Console.WriteLine("3.) Quit");
                Console.Write("Input your selection: ");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        _failed = false;
                        return _next = true;
                    case "2":
                        if (_failed) _failed = false;
                        else _difficulty = Math.Min(_difficulty - 10, 5);  // Increase difficulty
                        break;
                    case "3":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice, please write the number corresponding to the selection you desire.");
                        break;
                }
            }
        }
        return _next = true;
    }

    private string HideWord()
    {
        int index = _random.Next(_visableWords.Count);
        Word wordToHide = _visableWords[index]; 
        _visableWords.RemoveAt(index); 
        _hiddenWords.Add(wordToHide); 
        wordToHide.Hide();  // Hide the word visually

        _difficulty = _visableWords.Count * 100 / _words.Count;  // Adjust difficulty based on remaining visible words

        Console.WriteLine($"Hiding word: {wordToHide.GetDisplayText()}");
        Console.WriteLine($"Remaining visible words: {_visableWords.Count}");
        Console.WriteLine($"Difficulty: {_difficulty}%");

        return string.Join(" ", _words.Select(word => word.GetDisplayText()));
    }

    private string HideWords(int percentToHide)
    {
        string[] words = _originalScripture.Split(' ');
        int wordsToHide = (int)(words.Length * percentToHide / 100.0);

        for (int i = 0; i < wordsToHide; i++)
        {
            HideWord();
        }

        return string.Join(" ", _words.Select(word => word.GetDisplayText()));
    }

    private bool CheckAnswer(string answer)
    {
        return answer.Trim().Equals(_originalScripture.Trim(), StringComparison.OrdinalIgnoreCase);
    }
}
