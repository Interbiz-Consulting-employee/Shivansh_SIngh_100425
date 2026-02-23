using System;

public class LogicalQuestion72
{
    public static int MinEatingSpeed(int[] nums, int h)
    {
        int left = 1;
        int right = 0;

            for (int i = 0; i < nums.Length; i++)
         {
            if( nums[i]>right )
                right = nums[i];
        }

        while (left < right)
        {
            int mid = left + (right - left) / 2;
            int hours = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                  hours += (nums[i] + mid - 1) / mid;
            }

            if (hours <= h)
                right = mid; 

            else
                left = mid + 1; 
        }

        return left;
    }

    public static void Main(string[] args)
    {

        int[] nums1 = { 7, 15, 6, 3 };
        int h1 = 8;
        int result1 = MinEatingSpeed(nums1, h1);
        Console.WriteLine("Example 1 Output: " + result1); // Expected: 5

        int[] nums2 = { 25, 12, 8, 14, 19 };
        int h2 = 5;
        int result2 = MinEatingSpeed(nums2, h2);
        Console.WriteLine("Example 2 Output: " + result2); // Expected: 25
    }
}