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
        int inputNumber = 1;

        bool result = CheckIfPowerOfTwo(inputNumber);
        Console.WriteLine("Input = " + inputNumber);
        Console.WriteLine("Is Power Of Two = " + result);
        Console.WriteLine();

        inputNumber = 16;

        result = CheckIfPowerOfTwo(inputNumber);
        Console.WriteLine("Input = " + inputNumber);
        Console.WriteLine("Is Power Of Two = " + result);
        Console.WriteLine();

        inputNumber = 3;

        result = CheckIfPowerOfTwo(inputNumber);
        Console.WriteLine("Input = " + inputNumber);
        Console.WriteLine("Is Power Of Two = " + result);
    }
}