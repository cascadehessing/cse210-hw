
using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    public int GetScore()
    {
        return _score;
    }

    public void AddGoal(Goal goal)
    {
        _goals.Add(goal);
    }

    public void DisplayGoals()
    {
        Console.WriteLine("\nYour Goals:");

        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    public void RecordEvent(int goalNumber)
    {
        int index = goalNumber - 1;

        if (index < 0 || index >= _goals.Count)
        {
            Console.WriteLine("Invalid goal number.");
            return;
        }

        Goal goal = _goals[index];

        if (goal is SimpleGoal && goal.IsComplete())
        {
            Console.WriteLine("This goal has already been completed!");
            return;
        }

        if (goal is ChecklistGoal && goal.IsComplete())
        {
            Console.WriteLine("This checklist is already complete!");
            return;
        }

        goal.RecordEvent();

        _score += goal.GetPoints();

        Console.WriteLine($"Congratulations! You earned {goal.GetPoints()} points!");

        if (goal is ChecklistGoal checklist)
        {
            if (checklist.IsComplete())
            {
                _score += checklist.GetBonusPoints();

                Console.WriteLine(
                    $"You completed your checklist! Bonus: {checklist.GetBonusPoints()} points!");
            }
        }

        Console.WriteLine($"Your total score is {_score}.");
    }

    public void SaveGoals(string filename)
    {
        List<string> lines = new List<string>();

        lines.Add($"Score:{_score}");

        foreach (Goal goal in _goals)
        {
            lines.Add(goal.GetStringRepresentation());
        }

        File.WriteAllLines(filename, lines);

        Console.WriteLine("Goals saved successfully!");
    }

    public void LoadGoals(string filename)
    {
        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found.");
            return;
        }

        string[] lines = File.ReadAllLines(filename);

        _goals.Clear();

        foreach (string line in lines)
        {
            if (line.StartsWith("Score:"))
            {
                _score = int.Parse(line.Substring(6));
                continue;
            }

            string[] parts = line.Split(':', 2);
            string type = parts[0];
            string[] data = parts[1].Split(',');

            if (type == "SimpleGoal")
            {
                SimpleGoal goal = new SimpleGoal(
                    data[0], data[1], int.Parse(data[2]));

                if (bool.Parse(data[3]))
                {
                    goal.RecordEvent();
                }

                _goals.Add(goal);
            }
            else if (type == "EternalGoal")
            {
                EternalGoal goal = new EternalGoal(
                    data[0], data[1], int.Parse(data[2]));

                _goals.Add(goal);
            }
            else if (type == "ChecklistGoal")
            {
                ChecklistGoal goal = new ChecklistGoal(
                    data[0],
                    data[1],
                    int.Parse(data[2]),
                    int.Parse(data[3]),
                    int.Parse(data[5]));

                int completed = int.Parse(data[4]);

                for (int i = 0; i < completed; i++)
                {
                    goal.RecordEvent();
                }

                _goals.Add(goal);
            }
        }

        Console.WriteLine("Goals loaded successfully!");
    }
}
