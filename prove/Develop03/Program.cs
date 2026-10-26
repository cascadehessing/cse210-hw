using System;

class Program
{
    static void Main(string[] args)
    {
        ScriptureGenerator generator = new ScriptureGenerator();
        Scripture scripture = generator.GetRandomScripture();
        while (true)
        {
            Console.Clear();

            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine();

            if (scripture.IsCompletelyHidden())
            {
                break;
            }
            Console.WriteLine("Press Enter to hide more words or type 'quit' to exit.");
            string input = Console.ReadLine();

            if (input != null && input.ToLower()== "quit")
            {
                break;
            }

            scripture.HideRandomWords(3);
        }
        Console.WriteLine("Good job practicing!");
    }
}