using System;


class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();

        string choice = "";

        while (choice != "5")
        {
            Console.WriteLine("Welcome to My Journal!");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal");
            Console.WriteLine("4. Load the journal");
            Console.WriteLine("5. Quit");
            Console.Write("Choose an option: ");

            choice = Console.ReadLine();

            
if (choice == "1")
{
    Entry entry = new Entry();

    DateTime theCurrentTime = DateTime.Now;
    entry._date = theCurrentTime.ToShortDateString();

    entry._promptText = promptGenerator.GetRandomPrompt();

    Console.WriteLine(entry._promptText);
    Console.Write("> ");
    entry._entryText = Console.ReadLine();

    journal.AddEntry(entry);
}
else if (choice == "2")
{
    journal.DisplayAll();
}

else if (choice == "3")
{
    Console.Write("Enter filename: ");
    string filename = Console.ReadLine();

    journal.SaveToFile(filename);

    Console.WriteLine("Journal saved!");
}


else if (choice == "4")
{
    Console.Write("Enter filename: ");
    string filename = Console.ReadLine();

    journal.LoadFromFile(filename);

    Console.WriteLine("Journal loaded!");
}

else if (choice != "5")
{
    Console.WriteLine("Invalid choice. Please try again.");
}

        }
    }
}
