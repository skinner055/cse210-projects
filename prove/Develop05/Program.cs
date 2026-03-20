using System;

class Program
{
    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();
        bool running = true;

        while (running)
        {
            manager.DisplayScore();

            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Save Goals");
            Console.WriteLine("  4. Load Goals");
            Console.WriteLine("  5. Record Event");
            Console.WriteLine("  6. Quit");

            Console.Write("Select a choice from the menu: ");
            string input = Console.ReadLine();
            int choice;

            if (!int.TryParse(input, out choice))
            {
                Console.WriteLine("Invalid input. Please enter a number from 1 to 6.");
                continue;
            }

            if (choice == 1)
            {
                manager.CreateGoal();
            }
            else if (choice == 2)
            {
                manager.ListGoals();
            }
            else if (choice == 3)
            {
                manager.SaveGoals();
            }
            else if (choice == 4)
            {
                manager.LoadGoals();
            }
            else if (choice == 5)
            {
                manager.RecordEvent();
            }
            else if (choice == 6)
            {
                running = false;
            }
            else
            {
                Console.WriteLine("Invalid choice. Please enter a number from 1 to 6.");
            }
        }
    }
}