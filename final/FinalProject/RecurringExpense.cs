using System;

public class RecurringExpense : Expense
{
    private string _frequency;

    public RecurringExpense(string name, double amount, string frequency)
        : base(name, amount)
    {
    }

    public override void MarkComplete()
    {
    }

    public override void ProcessEndOfMonth()
    {
    }

    public override string GetDetails()
    {
        return "";
    }

    public override string Save()
    {
        return "";
    }
}