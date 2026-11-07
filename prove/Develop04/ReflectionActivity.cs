
using System;
using System.Collections.Generic;

public class ReflectionActivity : Activity
{
    private List<string> _prompts;
    private List<string> _questions;

    public ReflectionActivity()
    {
        _name = "Reflection Activity";

        _description = "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.";

        _prompts = new List<string>
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless.",
            "Think of a time when you overcame a challenge."
        };

        _questions = new List<string>
        {
            "Why was this experience meaningful to you?",
            "How did you feel when it was complete?",
            "What made this experience special?",
            "What did you learn about yourself?",
            "How can you use this experience in the future?",
            "What could you learn from this experience?",
            "What made this experience difficult?",
            "How did you show strength during this experience?"
        };
    }

    public void Run()
    {
        DisplayStartingMessage();

        DisplayPrompt();

        DisplayQuestions();

        DisplayEndingMessage();
    }

    private void DisplayPrompt()
    {
        Random random = new Random();

        int index = random.Next(_prompts.Count);

        string prompt = _prompts[index];

        Console.WriteLine("Consider the following prompt:");
        Console.WriteLine();
        Console.WriteLine($"--- {prompt} ---");
        Console.WriteLine();
        Console.WriteLine("When you have something in mind, press Enter to continue.");

        Console.ReadLine();

        Console.WriteLine("Now ponder on each of the following questions as they relate to this experience.");
        Console.Write("You may begin in: ");

        ShowCountDown(5);
        Console.WriteLine();
    }

    private void DisplayQuestions()
    {
        DateTime startTime = DateTime.Now;

        Random random = new Random();

        while ((DateTime.Now - startTime).TotalSeconds < _duration)
        {
            int index = random.Next(_questions.Count);

            string question = _questions[index];

            Console.Write($"> {question} ");

            double elapsed = (DateTime.Now - startTime).TotalSeconds;
            int remaining = (int)Math.Ceiling(_duration - elapsed);

            if (remaining > 0)
            {
                ShowSpinner(Math.Min(10, remaining));
            }

            Console.WriteLine();
        }
    }
}
