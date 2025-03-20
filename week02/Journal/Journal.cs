using System;
using System.Collections.Generic;
using System.IO;

class Journal
{
    private List<Entry> _entries;

    public Journal()
    {
        _entries = new List<Entry>();
    }

    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }

    public void DisplayAll()
    {
        foreach (var entry in _entries)
        {
            entry.Display();
            Console.WriteLine();
        }
    }

    public void SaveToFile(string filename)
    {
        using (StreamWriter file = new StreamWriter(filename))
        {
            foreach (var entry in _entries)
            {
                file.WriteLine(entry.ToString());
            }
        }
    }

    public void LoadFromFile(string filename)
    {
        _entries.Clear();
        foreach (var line in File.ReadLines(filename))
        {
            var parts = line.Split('|');
            if (parts.Length == 3)
            {
                string prompt = parts[0];
                string response = parts[1];
                Entry entry = new Entry(prompt, response);
                _entries.Add(entry);
            }
        }
    }
}
