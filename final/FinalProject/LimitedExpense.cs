public class LimitedExpense : Expense
{
    private int _paymentsLeft;

    public LimitedExpense(string name, double amount, int payments) : base(name, amount)
    {
        _paymentsLeft = payments;
    }

    public override void ProcessEndOfMonth()
    {
        if (_isCompleted && _paymentsLeft > 0)
        {
            _paymentsLeft--;
        }

        _isArchived = _paymentsLeft == 0;

        _isCompleted = false;
    }

    public int GetPaymentsLeft()
    {
        return _paymentsLeft;
    }

    public override string GetDetails()
    {
        string status = _isCompleted ? "[X]" : "[ ]";
        return $"{status} [Limited: {_paymentsLeft} left] {_name} - ${_amount}";
    }
}