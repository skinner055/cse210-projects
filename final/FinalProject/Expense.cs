using System;

public abstract class Expense
{
    protected string _name;
    protected double _amount;
    protected bool _isCompleted;
    protected bool _isArchived;

    public Expense(string name, double amount)
    {
    }

    public virtual void MarkComplete()
    {
    }

    public bool IsCompleted()
    {
        return false;
    }

    public bool IsArchived()
    {
        return false;
    }

    public virtual void ProcessEndOfMonth()
    {
    }

    public virtual string GetDetails()
    {
        return "";
    }

    public void SetName(string name)
    {
    }

    public void SetAmount(double amount)
    {
    }

    public virtual string Save()
    {
        return "";
    }
}