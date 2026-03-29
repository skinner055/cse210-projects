using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        ExpenseManager manager = new ExpenseManager();
        Budget budget = new Budget(0);
        FileHandler fileHandler = new FileHandler();
        MonthManager monthManager = new MonthManager();
        UserInterface ui = new UserInterface();

        bool running = true;

        while (running)
        {
            ui.DisplayMenu();
            int choice = ui.GetUserChoice();

            if (choice == 1)
            {
                Console.Write("Enter budget: ");
                double amount = double.Parse(Console.ReadLine());
                budget.SetBudget(amount);
            }
            else if (choice == 2)
            {
                Expense expense = ui.PromptForExpense();
                manager.AddExpense(expense);
            }
            else if (choice == 3)
            {
                ui.DisplayExpenses(manager.GetAllExpenses());

                Console.Write("Which expense to mark complete? ");
                int index = int.Parse(Console.ReadLine()) - 1;

                manager.MarkExpenseComplete(index);
            }
            else if (choice == 4)
            {
                ui.DisplayExpenses(manager.GetAllExpenses());
            }
            else if (choice == 5)
            {
                List<string> files = fileHandler.GetAllMonthFiles();

                foreach (string file in files)
                {
                    Console.WriteLine(file);
                }
            }
            else if (choice == 6)
            {
                double total = manager.CalculateTotalSpent();

                string filename = $"month{monthManager.GetCurrentMonth()}.txt";

                fileHandler.SaveToFile(filename, manager.GetAllExpenses(), budget.GetBudget());

                manager.ProcessEndOfMonth();
                monthManager.IncrementMonth();

                Console.WriteLine("Month ended and saved.");
            }
            else if (choice == 7)
            {
                Console.Write("Enter filename: ");
                string filename = Console.ReadLine();

                var data = fileHandler.LoadFromFile(filename);

                ui.DisplayExpenses(data.Item1);

                double remaining = budget.CalculateRemaining(data.Item2);
                Console.WriteLine($"Remaining: {remaining}");
            }
            else if (choice == 8)
            {
                running = false;
            }
        }
    }
}