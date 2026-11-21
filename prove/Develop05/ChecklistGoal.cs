
public class ChecklistGoal : Goal
{
    private int _targetCount;
    private int _completedCount;
    private int _bonusPoints;

    public ChecklistGoal(string name, string description, int points,
        int targetCount, int bonusPoints)
        : base(name, description, points)
    {
        _targetCount = targetCount;
        _completedCount = 0;
        _bonusPoints = bonusPoints;
    }

    public override void RecordEvent()
    {
        if (_completedCount < _targetCount)
        {
            _completedCount++;
        }
    }

    public override bool IsComplete()
    {
        return _completedCount >= _targetCount;
    }

    public int GetBonusPoints()
    {
        return _bonusPoints;
    }

    public int GetCompletedCount()
    {
        return _completedCount;
    }

    public int GetTargetCount()
    {
        return _targetCount;
    }

    public override string GetDetailsString()
    {
        string checkbox = IsComplete() ? "[X]" : "[ ]";

        return $"{checkbox} {GetName()} ({GetDescription()}) -- Completed {_completedCount}/{_targetCount} times";
    }

    public override string GetStringRepresentation()
    {
        return $"ChecklistGoal:{GetName()},{GetDescription()},{GetPoints()},{_targetCount},{_completedCount},{_bonusPoints}";
    }
}
