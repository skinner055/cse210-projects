using System;

public class UserInterface
{
    public void DisplayMenu()
    {
        Console.WriteLine("\n==== Expense Tracker ====");
        Console.WriteLine("1. Set Monthly Budget");
        Console.WriteLine("2. Add Expense");
        Console.WriteLine("3. Mark Expense Complete");
        Console.WriteLine("4. View Current Expenses");
        Console.WriteLine("5. View Archive");
        Console.WriteLine("6. End Month");
        Console.WriteLine("7. Load Archive");
        Console.WriteLine("8. Quit");
    }

    public int GetUserChoice()
    {
        while (true)
        {
            Console.Write("Select an option: ");
            string input = Console.ReadLine();

            int choice;
            if (int.TryParse(input, out choice) && choice >= 1 && choice <= 8)
            {
                return choice;
            }

            Console.WriteLine("Invalid input. Please enter a number from 1–8.");
        }
    }

    public Expense PromptForExpense()
    {
        return null;
    }

    public void DisplayExpenses(System.Collections.Generic.List<Expense> expenses)
    {
    }

    public void DisplayMessage(string message)
    {
        Console.WriteLine(message);
    }
}