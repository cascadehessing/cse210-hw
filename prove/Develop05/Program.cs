
using System;

class Program
{
    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();

        bool running = true;

        Console.WriteLine("Welcome to Eternal Quest!");

        while (running)
        {
            Console.WriteLine("\n----------------------------");
            Console.WriteLine($"You have {manager.GetScore()} points.");
            Console.WriteLine($"Current Rank: {GetRank(manager.GetScore())}");
            Console.WriteLine("----------------------------");

            Console.WriteLine("Menu Options:");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Save Goals");
            Console.WriteLine("4. Load Goals");
            Console.WriteLine("5. Record Event");
            Console.WriteLine("6. Quit");

            Console.Write("Select a choice from the menu: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateGoal(manager);
                    break;

                case "2":
                    manager.DisplayGoals();
                    break;

                case "3":
                    Console.Write("Enter filename: ");
                    string saveFile = Console.ReadLine();
                    manager.SaveGoals(saveFile);
                    break;

                case "4":
                    Console.Write("Enter filename: ");
                    string loadFile = Console.ReadLine();
                    manager.LoadGoals(loadFile);
                    break;

                case "5":
                    manager.DisplayGoals();

                    Console.Write("Which goal did you accomplish? ");
                    if (int.TryParse(Console.ReadLine(), out int goalNumber))
                    {
                        manager.RecordEvent(goalNumber);
                    }
                    else
                    {
                        Console.WriteLine("Please enter a valid number.");
                    }
                    break;

                case "6":
                    running = false;
                    Console.WriteLine("Thanks for playing Eternal Quest!");
                    break;

                default:
                    Console.WriteLine("Please select a valid option.");
                    break;
            }
        }
    }

    static void CreateGoal(GoalManager manager)
    {
        Console.WriteLine("\nWhat type of goal would you like to create?");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");

        Console.Write("Select a goal type: ");
        string type = Console.ReadLine();

        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();

        Console.Write("What is a short description? ");
        string description = Console.ReadLine();

        Console.Write("How many points is this goal worth? ");

        if (!int.TryParse(Console.ReadLine(), out int points) || points < 0)
        {
            Console.WriteLine("Please enter a valid nonnegative number.");
            return;
        }

        if (type == "1")
        {
            SimpleGoal goal = new SimpleGoal(name, description, points);
            manager.AddGoal(goal);
        }
        else if (type == "2")
        {
            EternalGoal goal = new EternalGoal(name, description, points);
            manager.AddGoal(goal);
        }
        else if (type == "3")
        {
            Console.Write("How many times must you complete this goal? ");

            if (!int.TryParse(Console.ReadLine(), out int target) || target <= 0)
            {
                Console.WriteLine("Please enter a valid positive number.");
                return;
            }

            Console.Write("How many bonus points will you receive? ");

            if (!int.TryParse(Console.ReadLine(), out int bonus) || bonus < 0)
            {
                Console.WriteLine("Please enter a valid nonnegative number.");
                return;
            }

            ChecklistGoal goal = new ChecklistGoal(
                name, description, points, target, bonus);

            manager.AddGoal(goal);
        }
        else
        {
            Console.WriteLine("Invalid goal type.");
            return;
        }

        Console.WriteLine("Goal created successfully!");
    }

    // Creative feature: Players earn new ranks as they accumulate points.
    static string GetRank(int score)
    {
        if (score >= 5000)
        {
            return "Eternal Champion";
        }
        else if (score >= 3000)
        {
            return "Master Adventurer";
        }
        else if (score >= 1500)
        {
            return "Quest Hero";
        }
        else if (score >= 500)
        {
            return "Rising Warrior";
        }
        else
        {
            return "Beginner Adventurer";
        }
    }
}
