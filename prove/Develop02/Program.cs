using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Journal myJournal = new Journal();
        PromptGenerator promptGen = new PromptGenerator();

        bool running = true;
        Console.WriteLine("Welcome to the Journal Program!");

        while (running)
        {
            Console.WriteLine("Please select one of the following choices:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Save");
            Console.WriteLine("4. Load");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do? ");
            string input = Console.ReadLine();
            int choice;

            if (int.TryParse(input, out choice))
            {
                if (choice == 1)
                {
                    string prompt = promptGen.GetRandomPrompt();
                    Console.WriteLine(prompt);
                    Console.Write("> ");
                    string response = Console.ReadLine();

                    Entry newEntry = new Entry();
                    newEntry._prompt = prompt;
                    newEntry._response = response;
                    newEntry._date = DateTime.Now.ToShortDateString();

                    myJournal.AddEntry(newEntry);
                    Console.WriteLine($"Entry added. Total entries: {myJournal._entries.Count}");
                }
                else if (choice == 2)
                {
                    myJournal.DisplayAll();
                }
                else if (choice == 3)
                {
                    Console.Write("Enter filename: ");
                    string filename = Console.ReadLine();
                    myJournal.SaveToFile(filename);
                    Console.WriteLine($"Journal saved. Total entries: {myJournal._entries.Count}");
                }
                else if (choice == 4)
                {
                    Console.Write("Enter filename: ");
                    string filename = Console.ReadLine();
                    myJournal.LoadFromFile(filename);
                    Console.WriteLine($"Journal loaded. Total entries: {myJournal._entries.Count}");
                }
                else if (choice == 5)
                {
                    running = false;
                    Console.WriteLine("Goodbye!");
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please try again.");
                }
            }
            else
            {
                Console.WriteLine("Please enter a valid number.");
            }

            Console.WriteLine();
        }
    }
}
