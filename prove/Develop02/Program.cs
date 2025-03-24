using System;
using System.Collections.Generic;
using System.IO; 

namespace PersonalJournalApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Journal myJournal = new Journal();
            bool running = true;

            while (running)
            {
                Console.WriteLine("\n--- Journal Application ---");
                Console.WriteLine("1) Create a new journal entry");
                Console.WriteLine("2) View all journal entries");
                Console.WriteLine("3) Save journal to a file");
                Console.WriteLine("4) Load journal from a file");
                Console.WriteLine("5) Exit");
                Console.Write("Select an option (1-5): ");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        myJournal.NewEntry();
                        break;
                    case "2":
                        myJournal.ShowEntries();
                        break;
                    case "3":
                        Console.Write("Enter filename to save to: ");
                        string savePath = Console.ReadLine();
                        myJournal.Save(savePath);
                        break;
                    case "4":
                        Console.Write("Enter filename to load from: ");
                        string loadPath = Console.ReadLine();
                        myJournal.Load(loadPath);
                        break;
                    case "5":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid selection, please try again.");
                        break;
                }
            }
        }
    }

    class Journal
    {
        private List<JournalEntry> entries = new List<JournalEntry>();
        private Random randomizer = new Random();

        private List<string> prompts = new List<string>
        {
            "What was a small win you had today?",
            "What made you smile today?",
            "What did you learn about yourself today?",
            "How did you handle a challenge today?",
            "What are you grateful for today?"
        };

        public void NewEntry()
        {
            string selectedPrompt = prompts[randomizer.Next(prompts.Count)];
            Console.WriteLine($"\nPrompt: {selectedPrompt}");
            Console.Write("Your response: ");
            string response = Console.ReadLine();
            string currentDate = DateTime.Now.ToString("yyyy-MM-dd");

            entries.Add(new JournalEntry(currentDate, selectedPrompt, response));
            Console.WriteLine("Your entry has been added.\n");
        }

        public void ShowEntries()
        {
            if (entries.Count == 0)
            {
                Console.WriteLine("No journal entries yet.");
                return;
            }

            foreach (var entry in entries)
            {
                Console.WriteLine(entry.FormatEntry());
            }
        }

        public void Save(string filename)
        {
            using (StreamWriter writer = new StreamWriter(filename))
            {
                foreach (var entry in entries)
                {
                    writer.WriteLine($"{entry.Date}||{entry.Prompt}||{entry.Response}");
                }
            }
            Console.WriteLine("Journal successfully saved.");
        }

        public void Load(string filename)
        {
            if (!File.Exists(filename))
            {
                Console.WriteLine("Error: File not found.");
                return;
            }

            entries.Clear();
            var lines = File.ReadAllLines(filename);

            foreach (var line in lines)
            {
                var parts = line.Split("||");
                if (parts.Length == 3)
                {
                    entries.Add(new JournalEntry(parts[0], parts[1], parts[2]));
                }
            }

            Console.WriteLine("Journal successfully loaded.");
        }
    }

    class JournalEntry
    {
        public string Date { get; }
        public string Prompt { get; }
        public string Response { get; }

        public JournalEntry(string date, string prompt, string response)
        {
            Date = date;
            Prompt = prompt;
            Response = response;
        }

        public string FormatEntry()
        {
            return $"\nDate: {Date}\nPrompt: {Prompt}\nResponse: {Response}\n";
        }
    }
}