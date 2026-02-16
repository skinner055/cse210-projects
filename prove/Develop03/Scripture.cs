using System;
using System.Collections.Generic;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;
    private Random _random = new Random();

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();

        string[] parts = text.Split(" ");

        foreach (string part in parts)
        {
            _words.Add(new Word(part));
        }
    }

    public void Display()
    {
        Console.WriteLine(_reference.ToString());

        foreach (Word word in _words)
        {
            Console.Write(word.Display() + " ");
        }

        Console.WriteLine();
    }

    public void HideRandomWords(int count)
    {
        int hiddenThisRound = 0;

        while (hiddenThisRound < count && !AllWordsHidden())
        {
            int index = _random.Next(_words.Count);

            if (!_words[index].IsHidden())
            {
                _words[index].Hide();
                hiddenThisRound++;
            }
        }
    }

    public bool AllWordsHidden()
    {
        foreach (Word word in _words)
        {
            if (!word.IsHidden())
            {
                return false;
            }
        }

        return true;
    }
}