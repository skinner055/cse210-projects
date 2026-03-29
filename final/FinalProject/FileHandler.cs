using System;
using System.Collections.Generic;

public class FileHandler
{
    public void SaveToFile(string filename, List<Expense> expenses, double budget)
    {
    }

    public (List<Expense>, double) LoadFromFile(string filename)
    {
        return (new List<Expense>(), 0.0);
    }

    public List<string> GetAllMonthFiles()
    {
        return new List<string>();
    }
}