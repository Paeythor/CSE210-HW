using System;
using System.Collections.Generic;

public class Resume
{
    // Member variables for the person's name and their list of jobs
    public string _name;
    public List<Job> _jobs;

    // Constructor to initialize the resume with a name and an empty job list
    public Resume(string name)
    {
        _name = name;
        _jobs = new List<Job>(); // Initialize the job list
    }

    // Method to display the resume details
    public void Display()
    {
        // Display the name of the person
        Console.WriteLine($"Name: {_name}");

        // Display all jobs in the resume
        Console.WriteLine("Jobs:");
        foreach (Job job in _jobs)
        {
            job.Display(); // Call the Display method of each job in the list
        }
    }
}