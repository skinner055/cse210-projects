public class Budget
{
    private double _monthlyBudget;

    public Budget(double amount)
    {
        _monthlyBudget = amount;
    }

    public void SetBudget(double amount)
    {
        _monthlyBudget = amount;
    }

    public double GetBudget()
    {
        return _monthlyBudget;
    }

    public double CalculateRemaining(double totalSpent)
    {
        return _monthlyBudget - totalSpent;
    }

    public bool IsOverBudget(double totalSpent)
    {
        return totalSpent > _monthlyBudget;
    }
}