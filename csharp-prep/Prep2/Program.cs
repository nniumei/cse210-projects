using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("What is your current grade percentage in this class? Just give me an estimate.");
        string answer = Console.ReadLine();
        int percentage = int.Parse(answer);
        string letter = "";
        if (percentage >= 90)
        {
            letter = "A";
        }
        else if (percentage >= 80)
        {
            letter = "B";
        }
        else if (percentage >= 70)
        {
            letter = "C";
        }
        else if (percentage >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }
        Console.WriteLine($"Your grade is: {letter}");

        if (percentage >= 70)
        {
            Console.WriteLine("You passed! Good stuff!");
        }
        else if (percentage >= 60)
        {
            Console.WriteLine("It's not close enough. You just lost out on those credits, silly.");
        }
        else
        {
            Console.WriteLine("Be better next time, okay? Can't have you wasting your tuition on poor performance.");
        }
    }
}
