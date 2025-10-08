using System;
using System.Collections.Generic;
using System.IO;


class Entry
{
    public string _date;
    public string _prompt;
    public string _response;

    public void Display()
    {
        Console.WriteLine($"{_date}\n {_prompt}\n {_response}");
    }
}

class Journal
{
    public List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }

    public void DisplayAll()
    {
        foreach (Entry entry in _entries)
        {
            entry.Display();
            Console.WriteLine();
        }
    }

    public void SaveToFile(string file)
    {
        using (StreamWriter outputFile = new StreamWriter(file))
        {
            foreach (Entry entry in _entries)
            {
                outputFile.WriteLine($"{entry._date}~|~{entry._prompt}~|~{entry._response}");
            }
        }
    }

    public void LoadFromFile(string file)
    {
        string[] lines = System.IO.File.ReadAllLines(file);

        foreach (string line in lines)
        {
            string[] parts = line.Split("~|~");

            Entry newEntry = new Entry();
            newEntry._date = parts[0];
            newEntry._prompt = parts[1];
            newEntry._response = parts[2];

            _entries.Add(newEntry);
        }
    }
}

class PromptGenerator
{
    public List<string> _prompts = new List<string>();

    public string GetRandomPrompt()
    {
        Random random = new Random();
        int index = random.Next(_prompts.Count);
        return _prompts[index];
    }
}

class Program
{
    static void Main(string[] args)
    {
        Journal theJournal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();

        promptGenerator._prompts.Add("Who was the most interesting person I interacted with today?");
        promptGenerator._prompts.Add("What was the best part of my day?");
        promptGenerator._prompts.Add("How did I see the hand of the Lord in my life today?");
        promptGenerator._prompts.Add("What was the strongest emotion I felt today?");
        promptGenerator._prompts.Add("If I had one thing I could do over today, what would it be?");

        Console.WriteLine("Welcome to the Journal Program!");

        string choice = "";
        while (choice != "5")
        {
            Console.WriteLine("Please select one of the following choices:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do? ");
            choice = Console.ReadLine();

            if (choice == "1")
            {
                // Write a new entry
                Entry newEntry = new Entry();
                
                DateTime theCurrentTime = DateTime.Now;
                newEntry._date = theCurrentTime.ToShortDateString();

                string prompt = promptGenerator.GetRandomPrompt();
                Console.WriteLine(prompt);
                Console.Write("> ");
                newEntry._prompt = prompt;
                newEntry._response = Console.ReadLine();

                theJournal.AddEntry(newEntry);
            }
            else if (choice == "2")
            {
                // Display all entries
                theJournal.DisplayAll();
            }
            else if (choice == "3")
            {
                // Load from file
                Console.Write("What is the filename? ");
                string filename = Console.ReadLine();
                theJournal.LoadFromFile(filename);
            }
            else if (choice == "4")
            {
                // Save to file
                Console.Write("What is the filename? ");
                string filename = Console.ReadLine();
                theJournal.SaveToFile(filename);
            }
            else if (choice == "5")
            {
                Console.WriteLine("Goodbye!");
            }
        }
    }
}