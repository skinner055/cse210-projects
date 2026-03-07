using System;

class Program
{
    private string _choice;

    public void DisplayMenu()
    {
        Console.WriteLine("Menu Options:");
        Console.WriteLine("  1. Start breathing activity");
        Console.WriteLine("  2. Start reflecting activity");
        Console.WriteLine("  3. Start listing activity");
        Console.WriteLine("  4. Quit");
        Console.Write("Select a choice from the menu: ");
    }

    public void Run()
    {
        do
        {
            Console.Clear();
            DisplayMenu();
            _choice = Console.ReadLine();

            if (_choice == "1")
            {
                BreathingActivity activity = new BreathingActivity();
                activity.Run();
            }
            else if (_choice == "2")
            {
                ReflectionActivity activity = new ReflectionActivity();
                activity.Run();
            }
            else if (_choice == "3")
            {
                ListingActivity activity = new ListingActivity();
                activity.Run();
            }

        } while (_choice != "4");

        Console.WriteLine("Goodbye!");
    }

    static void Main(string[] args)
    {
        Program program = new Program();
        program.Run();
    }
}