public class ChecklistGoal : Goal
{
    private int _targetCount;
    private int _currentCount;
    private int _bonus;

    public ChecklistGoal(string name, string description, int points, int targetCount, int bonus)
        : base(name, description, points)
    {
        _targetCount = targetCount;
        _bonus = bonus;
        _currentCount = 0;
    }

    public override int RecordEvent()
    {
        _currentCount++;

        if (_currentCount >= _targetCount)
        {
            return _points + _bonus;
        }

        return _points;
    }

    public override bool IsComplete()
    {
        return _currentCount >= _targetCount;
    }

    public override string GetStatus()
    {
        return $"[{(_currentCount >= _targetCount ? "X" : " ")}]";
    }

    public override string GetDetails()
    {
        return $"{_name} ({_description}) -- Currently Completed: {_currentCount}/{_targetCount}";
    }

    public void SetCurrentCount(int count)
    {
        _currentCount = count;
    }

    public override string Save()
    {
        return $"Checklist:{_name},{_description},{_points},{_currentCount},{_targetCount},{_bonus}";
    }
}