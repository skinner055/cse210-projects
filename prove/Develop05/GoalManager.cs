using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score = 0;

    public void DisplayScore()
    {
        int level = _score / 1000;
        int nextLevel = 1000 - (_score % 1000);
        Console.WriteLine($"\nYou have {_score} points.");
        Console.WriteLine($"Your level: {level}");
        Console.WriteLine($"Points to next level: {nextLevel}\n");   
    }

    private int GetPositiveInt(string prompt)
    {
        int value;
        while (true)
        {
            Console.Write(prompt);
            if (int.TryParse(Console.ReadLine(), out value) && value > 0)
            {
                return value;
            }
            Console.WriteLine("Invalid input. Please enter a number greater than 0.");
        }
    }

    public void CreateGoal()
    {
        Console.WriteLine("The types of Goals are:");
        Console.WriteLine("  1. Simple Goal");
        Console.WriteLine("  2. Eternal Goal");
        Console.WriteLine("  3. Checklist Goal");

        int type;
        while (true)
        {
            Console.Write("Which type of goal would you like to create? ");
            if (int.TryParse(Console.ReadLine(), out type) && type >= 1 && type <= 3)
            {
                break;
            }
            Console.WriteLine("Invalid choice. Try again.");
        }

        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();

        Console.Write("What is a short description of it? ");
        string desc = Console.ReadLine();

        int points = GetPositiveInt("What is the amount of points associated with this goal? ");

        if (type == 1)
        {
            _goals.Add(new SimpleGoal(name, desc, points));
        }
        else if (type == 2)
        {
            _goals.Add(new EternalGoal(name, desc, points));
        }
        else if (type == 3)
        {
            int target = GetPositiveInt("How many times does this goal need to be accomplished for a bonus? ");
            int bonus = GetPositiveInt("What is the bonus for accomplishing it that many times? ");

            _goals.Add(new ChecklistGoal(name, desc, points, target, bonus));
        }
    }

    public void ListGoals()
    {
        Console.WriteLine("\nYour Goals:");

        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetStatus()} {_goals[i].GetDetails()}");
        }
    }

    public void RecordEvent()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals available.");
            return;
        }

        ListGoals();

        int index;
        while (true)
        {
            Console.Write("Which goal did you accomplish? ");
            if (int.TryParse(Console.ReadLine(), out int number) &&
                number >= 1 && number <= _goals.Count)
            {
                index = number - 1;
                break;
            }
            Console.WriteLine("Invalid input. Please try again.");
        }

        int pointsEarned = _goals[index].RecordEvent();
        _score += pointsEarned;

        Console.WriteLine($"You earned {pointsEarned} points!");
    }

    public void SaveGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        using (StreamWriter output = new StreamWriter(filename))
        {
            output.WriteLine(_score);

            foreach (Goal g in _goals)
            {
                output.WriteLine(g.Save());
            }
        }
    }

    public void LoadGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found!");
            return;
        }

        string[] lines = File.ReadAllLines(filename);
        _goals.Clear();

        _score = int.Parse(lines[0]);

        for (int i = 1; i < lines.Length; i++)
        {
            string line = lines[i];

            string[] mainParts = line.Split(':');
            string type = mainParts[0];
            string[] parts = mainParts[1].Split(',');

            if (type == "Simple")
            {
                SimpleGoal g = new SimpleGoal(parts[0], parts[1], int.Parse(parts[2]));
                g.SetComplete(bool.Parse(parts[3]));
                _goals.Add(g);
            }
            else if (type == "Eternal")
            {
                _goals.Add(new EternalGoal(parts[0], parts[1], int.Parse(parts[2])));
            }
            else if (type == "Checklist")
            {
                ChecklistGoal g = new ChecklistGoal(
                    parts[0],
                    parts[1],
                    int.Parse(parts[2]),
                    int.Parse(parts[4]),
                    int.Parse(parts[5])
                );

                g.SetCurrentCount(int.Parse(parts[3]));
                _goals.Add(g);
            }
        }
    }
}