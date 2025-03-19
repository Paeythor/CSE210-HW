public class Job
{
    // Member variables to hold the job details.
    public string _jobTitle;
    public string _company;
    public int _startYear;
    public int _endYear;

    // Constructor to initialize the job details.
    public Job(string jobTitle, string company, int startYear, int endYear)
    {
        _jobTitle = jobTitle;
        _company = company;
        _startYear = startYear;
        _endYear = endYear;
    }

    // Method to display the job details in a specific format.
    public void Display()
    {
        // Display job details as: Job Title (Company) StartYear-EndYear
        Console.WriteLine($"{_jobTitle} ({_company}) {_startYear}-{_endYear}");
    }
}