using System;

public class LimitedExpense : Expense
{
    private int _remainingPayments;

    public LimitedExpense(string name, double amount, int payments)
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