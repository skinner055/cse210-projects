using System;

public abstract class Expense
{
    protected string _name;
    protected double _amount;
    protected bool _isCompleted;
    protected bool _isArchived;

    public Expense(string name, double amount)
    {
        _name = name;
        _amount = amount;
        _isCompleted = false;
        _isArchived = false;
    }

    public virtual void MarkComplete()
    {
        _isCompleted = true;
    }

    public bool IsCompleted()
    {
        return _isCompleted;
    }

    public bool IsArchived()
    {
        return _isArchived;
    }

    public double GetAmount()
    {
        return _amount;
    }

    public string GetName()
    {
        return _name;
    }

    public virtual void ProcessEndOfMonth()
    {
        _isArchived = true;
    }

    public virtual string GetTypeName()
    {
        return GetType().Name;
    }

    public virtual string GetDetails()
    {
        string status = _isCompleted ? "[X]" : "[ ]";
        return $"{status} {_name} - ${_amount}";
    }

    public void SetName(string name)
    {
        _name = name;
    }

    public void SetAmount(double amount)
    {
        _amount = amount;
    }
}