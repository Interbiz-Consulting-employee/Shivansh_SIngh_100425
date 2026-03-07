using System;

class PowerOfTwoChecker
{
    public static bool CheckIfPowerOfTwo(int inputNumber)
    {
        if (inputNumber <= 0)
        {
            return false;
        }

        return (inputNumber & (inputNumber - 1)) == 0;
    }

    static void Main()
    {
        int inputNumber;

        Console.WriteLine("Power Of Two Checker");
        while (true)
        {
            Console.Write("Enter a positive integer: ");
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

        bool result = CheckIfPowerOfTwo(inputNumber);

        Console.WriteLine();
        Console.WriteLine("Input = " + inputNumber);
        Console.WriteLine("Is Power Of Two = " + result);
    }
}