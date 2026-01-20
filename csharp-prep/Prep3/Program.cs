using System;
using System.Runtime.InteropServices;

class Program
{
    static void Main(string[] args)
    {
        int win = 0;
        int count = 0;
        // Console.WriteLine("What is the magic number? ");
        // int number = Convert.ToInt32(Console.ReadLine());
        Random rg = new Random();
        int number = rg.Next(1, 101);
        while (win == 0)
        {
            count += 1;
            Console.WriteLine("What is your guess? ");
            int guess = Convert.ToInt32(Console.ReadLine());
            if (guess > number)
            {
                Console.WriteLine("Lower");
            }
            else if (guess < number)
            {
                Console.WriteLine("Higher");
            }
            else if (guess == number)
            {
                Console.WriteLine($"You guessed it in {count} guesses!");
                win = 1;
            }
        }
    }
}