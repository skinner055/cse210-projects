using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Write an adjective: ");
        string word1 = Console.ReadLine();
        Console.WriteLine("Write a noun: ");
        string word2 = Console.ReadLine();
        Console.WriteLine("Write a verb, past tense: ");
        string word3 = Console.ReadLine();
        Console.WriteLine("Write a place: ");
        string word4 = Console.ReadLine();
        Console.WriteLine("Write a body part: ");
        string word5 = Console.ReadLine();
        Console.WriteLine("Write an exclamation: ");
        string word6 = Console.ReadLine();

        Console.WriteLine($"Last weekend started off as a very {word1.ToUpper()} day. I carefully packed my {word2.ToUpper()}, knowing I might need it later. Without warning, I {word3.ToUpper()} out the door and headed straight to {word4.ToUpper()}.");
        Console.WriteLine($"Along the way, strange things kept happening, but I didn’t stop. When I finally arrived, everyone stared at me in silence. Suddenly, I raised my {word5.ToUpper()} and yelled, “{word6.ToUpper()}!”");
        Console.WriteLine("After that moment, nothing was ever the same, and people still talk about it to this day.");
    }
}