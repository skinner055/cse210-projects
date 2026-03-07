using System;

public class BreathingActivity : Activity
{
    public BreathingActivity() : base("Breathing", "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {
    }

    public void Run()
    {
        Start();

        int totalTime = GetDuration();
        int elapsed = 0;

        while (elapsed < totalTime)
        {
            Console.WriteLine();
            Console.WriteLine("Breathe in...");
            ShowCountdown(4);
            

            Console.WriteLine("Now breathe out...");
            ShowCountdown(6);

            elapsed += 10;
        }

        End();
    }
}