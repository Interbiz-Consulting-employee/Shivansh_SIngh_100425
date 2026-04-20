using System;
using System.Collections.Generic;

class Program
{
static List<int> MajorityElement(int[] nums)
{
    List<int> result = new List<int>();
    int n = nums.Length;

    for (int i = 0; i < n; i++)
    {
        if (result.Contains(nums[i])) 
        continue; 

        int count = 0;

        for (int j = 0; j < n; j++)
        {
            if (nums[j] == nums[i])
                count++;
        }

        if (count > n / 3)
            result.Add(nums[i]);
    }

    return result;
}
    public static void Main()
    {
        var testCases = new int[][]
        {
            new int[] { 1, 2, 1, 1, 3, 2 },
            new int[] { 1, 2, 1, 1, 3, 2, 2 }
        };

        foreach (int[]? nums in testCases)
        {
            List<int>? result = MajorityElement(nums);
            Console.WriteLine($"[{string.Join(", ", result)}]");
        }
    }
}