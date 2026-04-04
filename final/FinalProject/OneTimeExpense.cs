using System;

public class OneTimeExpense : Expense
{
    public OneTimeExpense(string name, double amount) : base(name, amount)
    {
    }

    public override string GetDetails()
    {
        string status = _isCompleted ? "[X]" : "[ ]";
        return $"{status} [One-Time] {_name} - ${_amount}";
    }
}