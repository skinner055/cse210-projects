using System;

public class OneTimeExpense : Expense
{
    public OneTimeExpense(string name, double amount)
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