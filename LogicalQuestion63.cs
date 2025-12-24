using System;

class Program
{
    static void Main()
    {
        Pattarn(5);
    }

    public static void Pattarn(int n)
    { for (int i = 1; i <= n; i++)
        {
            for (int j = 1; j < i; j++)
            {
                Console.Write(" ");
            }
           for (int k = 1; k <= i; k++)
            {
                Console.Write("*");
            }

            Console.WriteLine();
        }

        for (int i = n - 1; i >= 1; i--)
        {
            for (int j = 1; j < i; j++)
            {
                Console.Write(" ");
            }
            for (int k = 1; k <= i; k++)
            {
                Console.Write("*");
            }
            Console.WriteLine();
        }
    }

    }

