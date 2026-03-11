
using System;

class GameChecker
{
   public class Solution
{
    public static bool Nim(int n)
    {
        return n % 4 != 0;
    }
}
    static void Main()
    {
        int inputNumber;

        Console.WriteLine("Nim Game Checker");
        while (true)
        {
            Console.Write("Enter the number of stones: ");
            string userInput = Console.ReadLine();

            if (!int.TryParse(userInput, out inputNumber))
            {
                Console.WriteLine("Invalid input. Please enter a valid integer.\n");
                continue;
            }

            if (inputNumber <= 0)
            {
                Console.WriteLine("Please enter a number greater than 0.\n");
                continue;
            }

            break;
        }

        bool result = Solution.Nim(inputNumber);

        Console.WriteLine();
        Console.WriteLine("Input = " + inputNumber);
        Console.WriteLine("Can Win Nim = " + result);
    }
}