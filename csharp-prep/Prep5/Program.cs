using System;

class Program
{
    static void Main(string[] args)
    {
        DisplayWelcome();

        string name = PromptUserName();
        int num = PromptUserNumber();

        int square = SquareNumber(num);

        int year;
        PromptUserBirthYear(out year);

        DisplayResult(name, square, year);
    }
    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the program!");
    }

    static string PromptUserName()
    {
        Console.WriteLine("Please enter your name: ");
        string name = Console.ReadLine();

        return name;
    }

    static int PromptUserNumber()
    {
        Console.WriteLine("Please enter your favorite number: ");
        int num = Convert.ToInt32(Console.ReadLine());

        return num;
    }

    static void PromptUserBirthYear(out int year)
    {
        Console.Write($"Please enter the year you were born: ");
        year = Convert.ToInt32(Console.ReadLine());
    }
    static int SquareNumber(int num)
    {
        int square = num * num;
        return square;
    }

    static void DisplayResult(string name, int square, int year)
    {
        Console.WriteLine($"{name}, the square of your number is {square}.");
        Console.WriteLine($"{name}, you will turn {2026 - year} years old this year.");
    }
}