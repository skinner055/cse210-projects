using System;

class Program
{
    static void Main(string[] args)
    {
        Reference reference = new Reference("Proverbs", 3, 5, 6);

        string text = "Trust in the Lord with all thine heart and lean not unto thine own understanding; in all thy ways acknowledge him, and he shall direct thy paths.";

        Scripture scripture = new Scripture(reference, text);

        string input = "";

        while (input != "quit" && !scripture.AllWordsHidden())
        {
            Console.Clear();
            scripture.Display();

            Console.WriteLine("\nPress enter to continue or type a number to hide that many numbers. Type 'quit' to finish:");
            input = Console.ReadLine();

            if (input == "")
            {
                scripture.HideRandomWords(3);
            }
            else if (int.TryParse(input, out int number))
            {
                scripture.HideRandomWords(number);
            }
        }

        Console.Clear();
        scripture.Display();
        Console.WriteLine("\nProgram ended.");
    }
}
