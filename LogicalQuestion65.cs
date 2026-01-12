using System;

class Program
{
    static void Main()
    {
        Console.WriteLine(CountAndSay(4));  // Output: 1211
        Console.WriteLine(CountAndSay(1));  // Output: 1
    }

    public static string CountAndSay(int n)
    {
        string result = "1";  
        for (int i = 2; i <= n; i++)
        {
            string next = "";
            int count = 1;

            for (int j = 0; j < result.Length; j++)
            {
                if (j + 1 < result.Length && result[j] == result[j + 1])
                {
                    count++;
                }
                else
                {
                    next += count.ToString() + result[j];
                    count = 1; 
                }
            }

            result = next; 
        }

        return result;
    }
}
