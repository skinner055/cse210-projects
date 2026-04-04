using System;
using System.Collections.Generic;

public class ExpenseManager
{
    private List<Expense> _expenses = new List<Expense>();
    private Budget _budget = new Budget(0);
    private FileHandler _fileHandler = new FileHandler();
    private MonthManager _monthManager = new MonthManager();
    private UserInterface _ui = new UserInterface();

    public ExpenseManager()
    {
        int lastMonth = _monthManager.GetCurrentMonth() - 1;

        if (lastMonth > 0)
        {
            string filename = $"month{lastMonth}.txt";
            var data = _fileHandler.LoadFromFile(filename);

            List<Expense> loadedExpenses = data.Item1;
            double lastBudget = data.Item2;

            List<Expense> nextMonthExpenses = new List<Expense>();

            foreach (Expense e in loadedExpenses)
            {
                e.ProcessEndOfMonth();

                if (!e.IsArchived())
                {
                    nextMonthExpenses.Add(e);
                }
            }

            _expenses = nextMonthExpenses;
            _budget.SetBudget(lastBudget);
        }
    }

    public void DisplayMenu()
    {
        double spent = CalculateTotalSpent();
        double remaining = _budget.CalculateRemaining(spent);

        Console.WriteLine("\n==== Expense Tracker ====");
        Console.WriteLine($"Current Month: {_monthManager.GetCurrentMonth()}");
        Console.WriteLine($"Current Budget: ${_budget.GetBudget()}");
        Console.WriteLine($"Spent: ${spent}");
        Console.WriteLine($"Remaining: ${remaining}");

        Console.WriteLine("1. Set Monthly Budget");
        Console.WriteLine("2. Add Expense");
        Console.WriteLine("3. Mark Expense Complete");
        Console.WriteLine("4. View Current Expenses");
        Console.WriteLine("5. View Archive");
        Console.WriteLine("6. End Month");
        Console.WriteLine("7. Quit");
    }

    public void SetBudget()
    {
        Console.Write("Enter budget: ");
        double amount = double.Parse(Console.ReadLine());
        _budget.SetBudget(amount);
    }

    public void AddExpense()
    {
        Expense expense = _ui.PromptForExpense();
        _expenses.Add(expense);
    }

    public void MarkExpense()
    {
        _ui.DisplayExpenses(_expenses);

        Console.Write("Which expense? ");
        int index = int.Parse(Console.ReadLine()) - 1;

        if (index >= 0 && index < _expenses.Count)
        {
            _expenses[index].MarkComplete();
        }
    }

    public void ViewExpenses()
    {
        _ui.DisplayExpenses(_expenses);
    }

    public void ViewArchive()
    {
        List<string> files = _fileHandler.GetAllMonthFiles();

        if (files.Count == 0)
        {
            Console.WriteLine("No archive data.");
            return;
        }

        for (int i = 0; i < files.Count; i++)
        {
            Console.WriteLine($"{i + 1}. Month {i + 1}");
        }

        Console.Write("Select month: ");
        int choice = int.Parse(Console.ReadLine()) - 1;

        if (choice >= 0 && choice < files.Count)
        {
            var data = _fileHandler.LoadFromFile(files[choice]);

            List<Expense> expenses = data.Item1;
            double budget = data.Item2;

            Console.WriteLine($"\n==== Month {choice + 1} Summary ====");
            _ui.DisplayExpenses(expenses);

            double spent = 0;
            foreach (Expense e in expenses)
            {
                if (e.IsCompleted())
                    spent += e.GetAmount();
            }

            Console.WriteLine($"\nBudget: ${budget}");
            Console.WriteLine($"Spent: ${spent}");
        }
    }

    public void EndMonth()
    {
        double total = CalculateTotalSpent();
        string filename = _monthManager.GetMonthFileName();

        _fileHandler.SaveToFile(filename, _expenses, _budget.GetBudget());

        ProcessEndOfMonth();
        _monthManager.IncrementMonth();

        Console.WriteLine($"Saved as {filename}");
    }

    public double CalculateTotalSpent()
    {
        double total = 0;
        foreach (Expense e in _expenses)
        {
            if (e.IsCompleted())
            {
                total += e.GetAmount();
            }
        }
        return total;
    }

    public void ProcessEndOfMonth()
    {
        List<Expense> updated = new List<Expense>();

        foreach (Expense e in _expenses)
        {
            if (e is OneTimeExpense)
            {
                if (!e.IsCompleted())
                    updated.Add(e);
            }
            else if (e is RecurringExpense)
            {
                e.ProcessEndOfMonth();
                updated.Add(e);
            }
            else if (e is LimitedExpense le)
            {
                if (e.IsCompleted())
                    le.ProcessEndOfMonth();

                if (!le.IsArchived())
                    updated.Add(le);
            }
        }

        _expenses = updated;
    }
}