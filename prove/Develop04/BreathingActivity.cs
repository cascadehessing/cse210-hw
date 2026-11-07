public class BreathingActivity : Activity
{
    public BreathingActivity()
    {
        _name = "Breathing Activity";
        _description = "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.";
    }
public void Run()
{
    DisplayStartingMessage();

    DateTime startTime = DateTime.Now;

    while ((DateTime.Now - startTime).TotalSeconds < _duration)
    {
        Console.WriteLine();
        Console.Write("Breathe in...");
        ShowCountDown(4);

        Console.WriteLine();
        Console.Write("Breathe out...");
        ShowCountDown(6);

        Console.WriteLine();
    }

    DisplayEndingMessage();
}
}