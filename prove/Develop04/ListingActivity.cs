
using System;
using System.Collections.Generic;

public class ListingActivity : Activity
{
    private List<string> _prompts;

    public ListingActivity()
    {
        _name = "Listing Activity";

        _description = "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.";

        _prompts = new List<string>
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?",
            "What are things that you are grateful for?"
        };
    }

    public void Run()
    {
        DisplayStartingMessage();

        Console.WriteLine("List as many responses as you can to the following prompt:");
        GetRandomPrompt();

        Console.Write("You may begin in: ");
        ShowCountDown(5);

        Console.WriteLine();

        List<string> items = GetListFromUser();

        Console.WriteLine();
        Console.WriteLine($"You listed {items.Count} items!");

        DisplayEndingMessage();
    }

    private void GetRandomPrompt()
    {
        Random random = new Random();

        int index = random.Next(_prompts.Count);

        Console.WriteLine();
        Console.WriteLine($"--- {_prompts[index]} ---");
        Console.WriteLine();
    }

    private List<string> GetListFromUser()
    {
        List<string> items = new List<string>();

        DateTime startTime = DateTime.Now;

        while ((DateTime.Now - startTime).TotalSeconds < _duration)
        {
            Console.Write("> ");

            string answer = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(answer))
            {
                items.Add(answer);
            }
        }

        return items;
    }
}
