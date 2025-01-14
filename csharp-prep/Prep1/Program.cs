using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your first name? ");
        string firstName = Console.ReadLine();
        
        Console.Write("What is your last name? ");
        string lastName = Console.ReadLine();

        Console.Write($"Hello, {firstName} {lastName}! How are you today? ");
        string response = Console.ReadLine();

        Console.WriteLine($"You said that {response}. You know I'm just a computer program, right? I have no time for menial small talk.");

    }
}