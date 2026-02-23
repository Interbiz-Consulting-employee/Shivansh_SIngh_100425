using System;

class Program
{
    static (int length, int start, int end) LongestZeroSumSubarray(int[] nums)
    {
        int n = nums.Length;
        int maxLen = 0;
        int start = -1, end = -1;

        for (int i = 0; i < n; i++)
        {
            int sum = 0;
            for (int j = i; j < n; j++)
            {
                sum += nums[j];

                if (sum == 0)
                {
                    int length = j - i + 1;
                    if (length > maxLen)
                    {
                        maxLen = length;
                        start = i;
                        end = j;
                    }
                }
            }
        }

        return (maxLen, start, end);
    }

    static void Main(string[] args)
    {
        int[] nums1 = {1, -1, 3, 2, -2, -3, 3};
        var result1 = LongestZeroSumSubarray(nums1);
        Console.WriteLine($"Length: {result1.length}, Start: {result1.start}, End: {result1.end}");

        int[] nums2 = {6, -2, -2,-2,5, 2, -2, -4};
        var result2 = LongestZeroSumSubarray(nums2);
        Console.WriteLine($"Length: {result2.length}, Start: {result2.start}, End: {result2.end}");

        int[] nums3 = {1, 2, 3};
        var result3 = LongestZeroSumSubarray(nums3);
        Console.WriteLine($"Length: {result3.length}, Start: {result3.start}, End: {result3.end}");
    }
}
