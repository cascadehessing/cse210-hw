
using System.Collections.Generic;
using System.Threading;

public class Activity
{
    protected string _name;
    protected string _description;
    protected int _duration;

    public Activity()
    {
        
    }
    public void DisplayStartingMessage()
{
    Console.WriteLine($"Welcome to the {_name}.");
    Console.WriteLine();
    Console.WriteLine(_description);
    Console.WriteLine();

    Console.Write("How long, in seconds, would you like for your session? ");
    _duration = int.Parse(Console.ReadLine());

    Console.Clear();

    Console.WriteLine("Get ready...");
    ShowSpinner(3);
}
public void ShowCountDown(int seconds)
{
    for (int i = seconds; i > 0; i--)
    {
        Console.Write(i);
        Thread.Sleep(1000);
        Console.Write("\b \b");
    }
}
public void ShowSpinner(int seconds)
{
    List<string> animationStrings = new List<string>();
    animationStrings.Add("|");
    animationStrings.Add("/");
    animationStrings.Add("-");
    animationStrings.Add("\\");

    DateTime startTime = DateTime.Now;

    while ((DateTime.Now - startTime).TotalSeconds < seconds)
    {
        foreach (string s in animationStrings)
        {
            Console.Write(s);
            Thread.Sleep(250);
            Console.Write("\b \b");
        }
    }
}
public void DisplayEndingMessage()
{
    Console.WriteLine();
    Console.WriteLine("Good job!");
    Console.WriteLine($"You have completed another {_duration} seconds of the {_name}.");
    ShowSpinner(3);
    Console.WriteLine();
}
}