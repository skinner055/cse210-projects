using System;

class Program
{
    static void Main(string[] args)
    {
        string letter;
        Console.WriteLine("What is your grade percentage? ");
        int grade = Convert.ToInt32(Console.ReadLine());
        // Or you can do this:
        // string answer = Console.ReadLine();
        // int grade = int.Parse(answer);
        if (grade >= 90)
            {
                letter = "A";
            }
        else if (grade < 90 && grade >= 80)
            {
                letter = "B";
            }
        else if (grade < 80 && grade >= 70) 
            {
                letter = "C";
            }
        else if (grade < 70 && grade >= 60) 
            {
                letter = "D";
            } 
        else
            {
                letter = "F";
            }
        Console.WriteLine($"Your grade is {letter}.");
        if (grade >= 70)
            {
                Console.WriteLine("Congratulations! You Passed!");
            }
        else
            {
                Console.WriteLine("Better Luck Next Time.");
            }
    }
}