using System;

class Program
{
    static int FindMin(int[] nums)
    {
        if (nums == null)
            throw new ArgumentNullException(nameof(nums), "Input array cannot be null.");
        if (nums.Length == 0)
            throw new ArgumentException("Input array cannot be empty.", nameof(nums));

        int left = 0;
        int right = nums.Length - 1;

        while (left < right)
        {
            int mid = left + (right - left) / 2;

            if (nums[mid] > nums[right])
            {
                left = mid + 1;
            }
            else
            {
                right = mid;
            }
        }

        return nums[left];
    }

    public static void Main()
    {
        int[][] numsInput = new int[][]
        {
            new int[] {3, 4, 5, 1, 2},
            new int[] {4, 5, 6, 7, 0, 1, 2},
            new int[] {11, 13, 15, 17},          
        };

        foreach (var nums in numsInput)
        {
            try
            {
                Console.WriteLine(FindMin(nums));
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error: {ex.Message}");
            }
        }
    }
}