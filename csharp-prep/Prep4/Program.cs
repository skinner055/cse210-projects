using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        int num = -1;
        List<int> nums = new List<int>();

        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        while (num != 0)
        {
            Console.WriteLine("Enter number: ");
            num = Convert.ToInt32(Console.ReadLine());
            if (num != 0)
            {
                nums.Add(num);
            }
        }

        int sum = 0;
        foreach (int i in nums)
        {
            sum += i;
        }
        Console.WriteLine($"The sum is: {sum}");

        float average = ((float)sum) / nums.Count;
        Console.WriteLine($"The average is: {average}");

        int max = nums[0];
        foreach (int i in nums)
        {
            if (i > max)
            {
                max = i;
            }
        }

        Console.WriteLine($"The max is: {max}");
    }
}