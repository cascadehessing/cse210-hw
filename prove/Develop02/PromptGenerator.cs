using System.Collections.Generic;
public class PromptGenerator
{
    public List<string> _prompts = new List<string>
    {
        "What was the best part of my day?",
        "What is something new I learned today?",
        "Who helped me today?",
        "What am I grateful for today?",
        "What could I improve tomorrow?"
    };

    
public string GetRandomPrompt()
{
    Random random = new Random();
    int index = random.Next(_prompts.Count);
    return _prompts[index];
}

}
