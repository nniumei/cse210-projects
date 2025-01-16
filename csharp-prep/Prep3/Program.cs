using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        bool playAgain = true;

        while (playAgain)
        {
            Random randomGenerator = new Random();
            int number = randomGenerator.Next(1, 101); // 1 to 100 inclusive
            List<int> guesses = new List<int>();

            Console.WriteLine("Guess the magic number! I'm thinking of a number between 1 and 100.");
            int guess;

            // It's the first guess
            while (true)
            {
                string input = Console.ReadLine();
                if (int.TryParse(input, out guess))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("I didn't quite catch that. Please enter a number, no special characters or letters.");
                }
            }

            // Start the loop
            while (guess != number)
            {
                guesses.Add(guess); // Track guesses

                if (guess < number)
                {
                    Console.WriteLine("Too low! Guess again!");
                }
                else if (guess > number)
                {
                    Console.WriteLine("Too high! Guess again!");
                }

                // Get next guess
                string input = Console.ReadLine();
                if (!int.TryParse(input, out guess))
                {
                    Console.WriteLine("These new fangled translator chips- They don't make em' like they used to.");
                    Console.WriteLine("Try again using a number, no special characters.");
                }
            }

            // When the guess is correct
            Console.WriteLine("That's it!");
            Console.WriteLine("That's the number!");

            // Display all the guesses
            Console.WriteLine("You guessed these numbers before you got it right:");
            foreach (int g in guesses)
            {
                Console.WriteLine(g);
            }

            // Ask if the user wants to play again
            string response;
            do
            {
                Console.Write("Wanna keep going? (yes/no): ");
                response = Console.ReadLine().ToLower();
            } while (response != "yes" && response != "no");

            if (response == "no")
            {
                Console.WriteLine("Aww. Thanks for playing anyways!");
                playAgain = false;
            }
        }
    }
}
