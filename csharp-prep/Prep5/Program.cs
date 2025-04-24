using System;

class Program
{
    static void Main(string[] args)
    {
        DisplayWelcomeMessage();

        string userName = PromptUserName();
        int userNumber = PromptUserNumber();

        int squaredNumber = SquareNumber(userNumber);

        DisplayResult(userName, squaredNumber);
    }

    static void DisplayWelcomeMessage()
    {
        Console.WriteLine("Welcome to this thing!");
    }

    static string PromptUserName()
    {
        Console.Write("Please gimmie your name: ");
        string name = Console.ReadLine();

        return name;
    }

    static int PromptUserNumber()
    {
        int number;

        // This should help with invalids
        while (true)
        {
            Console.Write("Please gimmie your favorite number: ");
            string input = Console.ReadLine();

            // Parsing the inputs to an integer
            if (int.TryParse(input, out number))
            {
                return number;
            }
            else
            {
                Console.WriteLine("That's not a number, silly. Please try again.");
            }
        }
    }

    static int SquareNumber(int number)
    {
        int square = number * number;
        return square;
    }

    static void DisplayResult(string name, int square)
    {
        Console.WriteLine($"{name}, the square of that number is {square}");
    }
}
