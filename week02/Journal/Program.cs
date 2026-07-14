// Entry.cs
public class Entry {
    public string Prompt { get; set; }
    public string Response { get; set; }
    public string Date { get; set; }

    public void Display() {
        Console.WriteLine($"{Date} - {Prompt}");
        Console.WriteLine(Response);
        Console.WriteLine();
    }
}

// PromptGenerator.cs
public class PromptGenerator {
    private List<string> _prompts = new List<string> {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?"
    };

    public string GetRandomPrompt() {
        Random rand = new Random();
        return _prompts[rand.Next(_prompts.Count)];
    }
}

// Journal.cs
public class Journal {
    private List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry entry) {
        _entries.Add(entry);
    }

    public void DisplayAll() {
        foreach (Entry e in _entries) {
            e.Display();
        }
    }

    public void SaveToFile(string filename) {
        using (StreamWriter outputFile = new StreamWriter(filename)) {
            foreach (Entry e in _entries) {
                outputFile.WriteLine($"{e.Date}|{e.Prompt}|{e.Response}");
            }
        }
    }

    public void LoadFromFile(string filename) {
        _entries.Clear();
        string[] lines = File.ReadAllLines(filename);
        foreach (string line in lines) {
            string[] parts = line.Split('|');
            Entry e = new Entry {
                Date = parts[0],
                Prompt = parts[1],
                Response = parts[2]
            };
            _entries.Add(e);
        }
    }
}

// Program.cs
class Program {
    static void Main(string[] args) {
        Journal journal = new Journal();
        PromptGenerator generator = new PromptGenerator();
        bool running = true;

        while (running) {
            Console.WriteLine("1. Write new entry");
            Console.WriteLine("2. Display journal");
            Console.WriteLine("3. Save journal");
            Console.WriteLine("4. Load journal");
            Console.WriteLine("5. Quit");
            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            switch (choice) {
                case "1":
                    string prompt = generator.GetRandomPrompt();
                    Console.WriteLine(prompt);
                    string response = Console.ReadLine();
                    Entry entry = new Entry {
                        Prompt = prompt,
                        Response = response,
                        Date = DateTime.Now.ToShortDateString()
                    };
                    journal.AddEntry(entry);
                    break;
                case "2":
                    journal.DisplayAll();
                    break;
                case "3":
                    Console.Write("Enter filename: ");
                    string saveFile = Console.ReadLine();
                    journal.SaveToFile(saveFile);
                    break;
                case "4":
                    Console.Write("Enter filename: ");
                    string loadFile = Console.ReadLine();
                    journal.LoadFromFile(loadFile);
                    break;
                case "5":
                    running = false;
                    break;
            }
        }
    }
}
