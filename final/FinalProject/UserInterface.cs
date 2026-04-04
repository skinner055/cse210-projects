using System;
using System.Collections.Generic;

public class UserInterface
{
    public void DisplayMenu(double budget, double spent, double remaining)
    {
        Console.WriteLine("\n==== Expense Tracker ====");
        Console.WriteLine($"Current Budget: ${budget}");
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

    public int GetUserChoice()
    {
        Console.Write("Select a choice: ");
        return int.Parse(Console.ReadLine());
    }

    public Expense PromptForExpense()
    {
        Console.WriteLine("Select expense type:");
        Console.WriteLine("1. One-Time");
        Console.WriteLine("2. Recurring");
        Console.WriteLine("3. Limited");

        int type = int.Parse(Console.ReadLine());

        Console.Write("Name: ");
        string name = Console.ReadLine();

        Console.Write("Amount: ");
        double amount = double.Parse(Console.ReadLine());

        if (type == 1)
        {
            return new OneTimeExpense(name, amount);
        }
        else if (type == 2)
        {
            return new RecurringExpense(name, amount);
        }
        else
        {
            Console.Write("Number of payments: ");
            int payments = int.Parse(Console.ReadLine());
            return new LimitedExpense(name, amount, payments);
        }
    }

    public void DisplayExpenses(List<Expense> expenses)
    {
        if (expenses.Count == 0)
        {
            Console.WriteLine("No expenses.");
            return;
        }

        for (int i = 0; i < expenses.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {expenses[i].GetDetails()}");
        }
    }

    public void DisplayMessage(string message)
    {
        Console.WriteLine(message);
    }
}