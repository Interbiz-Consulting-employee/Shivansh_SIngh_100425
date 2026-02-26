using System;

public class LogicalQuestion73
{
public class Solution
{
    public int ClimbStairs(int n)
    {   if(n<=0) 
            return 0;

        if (n <= 2)
            return n;

        int first = 1;   
        int second = 2; 

        for (int i = 3; i <= n; i++)
        {
            int third = first + second;
            first = second;
            second = third;
        }

        return second;
    }
}

   public static void Main(string[] args)
{
    Solution solution = new Solution();
    Console.WriteLine("Enter the number of stairs:");
    try
    {
        int n = int.Parse(Console.ReadLine());
        int result = solution.ClimbStairs(n);
        Console.WriteLine($"Number of ways to climb {n} stairs: {result}"); 
    }    
    catch (FormatException)
    {
        Console.WriteLine("Invalid input. Please enter a valid integer.");
        return;
    }
    }
}