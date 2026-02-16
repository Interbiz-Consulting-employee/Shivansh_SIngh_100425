using System;
using System.Collections.Generic;

public class LogicalQuestion70
{
      static void Main(string[] args)
        {
            int[] arr1 = {100, 4, 200, 1, 3, 2 };

            Console.WriteLine(" Input : " + LongestConsecutive(arr1).Length + " Start : " + LongestConsecutive(arr1).Start);

            int[] arr2 = {1, 2, 2, 3};

            Console.WriteLine(" Input : " + LongestConsecutive(arr2).Length + " Start : " + LongestConsecutive(arr2).Start);

            int[] arr3 = {0, -1, 1, 2, -2, -3};

            Console.WriteLine(" Input : " + LongestConsecutive(arr3).Length + " Start : " + LongestConsecutive(arr3).Start);

        }
    public static (int Length, int Start) LongestConsecutive(int[] nums)
    {
        if (nums == null || nums.Length == 0)
            return (0, 0);

        Dictionary<int, int> map = new Dictionary<int, int>();
        int maxLength = 0;
        int bestStart = 0;

        foreach (int num in nums)
        {
            if (map.ContainsKey(num))
                continue; 

            int left = map.ContainsKey(num - 1) ? map[num - 1] : 0;
            int right = map.ContainsKey(num + 1) ? map[num + 1] : 0;

            int currentLength = left + right + 1;

            map[num] = currentLength;

            if (left > 0)
                map[num - left] = currentLength;
            else
                map[num] = currentLength;

            if (right > 0)
                map[num + right] = currentLength;
            else
                map[num] = currentLength;

            int start = num - left;

            if (currentLength > maxLength ||
               (currentLength == maxLength && start < bestStart))
            {
                maxLength = currentLength;
                bestStart = start;
            }
        }

        return (maxLength, bestStart);
    }
}
