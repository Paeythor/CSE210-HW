public class Assignment
{
    private string _studentName;
    private string _topic;

    public Assignment(string studentName, string topic)
    {
        _studentName = studentName;
        _topic = topic;
    // Get a summary of the assignment
    }public string GetSummary() 
    {
        return $"{_studentName} - {_topic}";
    }
    // Protected getter for _studentName, to be used in derived classes
    protected string GetStudentName()
    {
        return _studentName;
    }
}