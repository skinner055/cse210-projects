using System.IO;
using System.Linq;

public class MonthManager
{
    private int _currentMonth;

    public MonthManager()
    {
        var files = Directory.GetFiles("Archive", "month*.txt");

        if (files.Length == 0)
        {
            _currentMonth = 1;
        }
        else
        {
            int max = files
                .Select(f => int.Parse(Path.GetFileNameWithoutExtension(f).Replace("month", "")))
                .Max();

            _currentMonth = max + 1;
        }
    }

    public int GetCurrentMonth()
    {
        return _currentMonth;
    }

    public void IncrementMonth()
    {
        _currentMonth++;
    }

    public string GetMonthFileName()
    {
        return $"month{_currentMonth}.txt";
    }
}