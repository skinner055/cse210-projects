using System;

class Program
{
    static void Main(string[] args)
    {
        ExpenseManager manager = new ExpenseManager();
        bool running = true;

        while (running)
        {
            manager.DisplayMenu();

            Console.Write("Select a choice: ");
            string input = Console.ReadLine();
            int choice;

            if (!int.TryParse(input, out choice))
            {
                Console.WriteLine("Invalid input.");
                continue;
            }

            if (choice == 1)
            {
                manager.SetBudget();
            }
            else if (choice == 2)
            {
                manager.AddExpense();
            }
            else if (choice == 3)
            {
                manager.MarkExpense();
            }
            else if (choice == 4)
            {
                manager.ViewExpenses();
            }
            else if (choice == 5)
            {
                manager.ViewArchive();
            }
            else if (choice == 6)
            {
                manager.EndMonth();
            }
            else if (choice == 7)
            {
                running = false;
            }
            else
            {
                Console.WriteLine("Invalid choice.");
            }
        }
    }
}