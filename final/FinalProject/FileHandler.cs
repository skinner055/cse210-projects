using System;
using System.Collections.Generic;
using System.IO;

public class FileHandler
{
    private const string DirectoryName = "Archive";

    public FileHandler()
    {
        if (!Directory.Exists(DirectoryName))
        {
            Directory.CreateDirectory(DirectoryName);
        }
    }

    public void SaveToFile(string filename, List<Expense> expenses, double budget)
    {
        string path = Path.Combine(DirectoryName, filename);
        using (StreamWriter writer = new StreamWriter(path))
        {
            writer.WriteLine(budget);

            foreach (Expense e in expenses)
            {
                string type = e.GetTypeName();
                string name = e.GetName();
                double amount = e.GetAmount();
                bool completed = e.IsCompleted();

                string extra = "";

                if (e is LimitedExpense le)
                {
                    extra = le.GetPaymentsLeft().ToString();
                }
                writer.WriteLine($"{type}|{name}|{amount}|{completed}|{extra}");
            }
        }
    }

    public Tuple<List<Expense>, double> LoadFromFile(string filename)
    {
        string path = Path.Combine(DirectoryName, filename);
        List<Expense> expenses = new List<Expense>();
        double budget = 0;

        if (!File.Exists(path))
        {
            return new Tuple<List<Expense>, double>(expenses, budget);
        }

        using (StreamReader reader = new StreamReader(path))
        {
            string line = reader.ReadLine();
            if (line != null)
            {
                budget = double.Parse(line);
            }

            while ((line = reader.ReadLine()) != null)
            {
                string[] parts = line.Split('|');
                string type = parts[0];
                string name = parts[1];
                double amount = double.Parse(parts[2]);
                bool completed = bool.Parse(parts[3]);
                string extra = parts.Length > 4 ? parts[4] : "";

                Expense e;

                if (type == "OneTimeExpense")
                {
                    e = new OneTimeExpense(name, amount);
                }
                else if (type == "RecurringExpense")
                {
                    e = new RecurringExpense(name, amount);
                }
                else if (type == "LimitedExpense")
                {
                    int paymentsLeft = int.Parse(extra);
                    e = new LimitedExpense(name, amount, paymentsLeft);
                }
                else
                {
                    continue;
                }

                if (completed)
                    e.MarkComplete();

                expenses.Add(e);
            }
        }

        return new Tuple<List<Expense>, double>(expenses, budget);
    }

    public List<string> GetAllMonthFiles()
    {
        List<string> files = new List<string>();
        if (!Directory.Exists(DirectoryName))
        {
            return files;
        }

        string[] fileArray = Directory.GetFiles(DirectoryName, "month*.txt");
        Array.Sort(fileArray);

        foreach (string f in fileArray)
        {
            files.Add(Path.GetFileName(f));
        }

        return files;
    }
}