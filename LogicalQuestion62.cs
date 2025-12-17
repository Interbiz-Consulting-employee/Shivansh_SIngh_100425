using System;

class Program
{
    static void Main()
    {
        int[] arr1 = { 4, 3, 2, 6 };
        int[] arr2 = {100};

        Console.WriteLine("Max value for 1st array : "+ MaxValue(arr1)); // output:26
        Console.WriteLine("Max value for 2nd array : "+ MaxValue(arr2)); // output:0
    }

    public static int MaxValue(int[] arr)
    {
        int[] sum = new int[arr.Length];
        int k = 0;

        while (k < arr.Length)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                sum[k] = sum[k] + (arr[i] * ((i + k) % arr.Length));
            }
            k++;
        }
        int max=0;
        for (int i = 0; i < arr.Length; i++)
        {
            if (sum[i]>max)
                max = sum[i];
        }

        return max;
    }
}
