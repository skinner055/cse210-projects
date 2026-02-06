using System;

public class Entry
{
    public string _date;
    public string _prompt;
    public string _response;

    public void DisplayEntry()
    {
        Console.WriteLine($"Date: {_date}");
        Console.WriteLine($"Prompt: {_prompt}");
        Console.WriteLine($"Response: {_response}");
        Console.WriteLine();
    }

    public string ToFileString()
    {
        return $"{_date}|{_prompt}|{_response}";
    }

    public static Entry FromFileString(string data)
    {
        string[] parts = data.Split("|");

        Entry entry = new Entry();
        entry._date = parts[0];
        entry._prompt = parts[1];
        entry._response = parts[2];

        return entry;
    }
}
