using System;

public class RecurringExpense : Expense
{
    public RecurringExpense(string name, double amount) : base(name, amount)
    {
    }

    public override void ProcessEndOfMonth()
    {
        _isCompleted = false;
    }

    public override string GetDetails()
    {
        string status = _isCompleted ? "[X]" : "[ ]";
        return $"{status} [Recurring] {_name} - ${_amount}";
    }
}