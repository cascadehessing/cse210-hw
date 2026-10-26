using System;

public class ScriptureGenerator
{
    private Random _random = new Random();
    public Scripture GetRandomScripture()
    {
        int choice = _random.Next(3);

        if (choice == 0)
        {
            Reference reference = new Reference("John", 3, 16, 16);
            string text = "For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life.";
            return CreateScripture(reference, text);
        }
        else if (choice == 1)
        {
            Reference reference = new Reference("Proverbs", 3, 5, 6);
            string text = "Trust in the Lord with all thine heart; and lean not unto thine own understanding. In all thy ways acknowledge him, and he shall direct thy paths.";
            return CreateScripture(reference, text);
        }
        else
        {
            Reference reference = new Reference("Mosiah", 2, 17, 17);
            string text = "And behold, I tell you these things that ye may learn wisdom; that ye may learn that when ye are in the service of your fellow beings ye are only in the service of your God.";
            return CreateScripture(reference, text);
        }
    }

    private Scripture CreateScripture(Reference reference, string text)
    {
        List<Word> words = new List<Word>();

        foreach (string word in text.Split(' '))
        {
            words.Add(new Word(word));
        }

        return new Scripture(reference, words);
    }
}