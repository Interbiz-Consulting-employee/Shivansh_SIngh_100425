using System;

class Program
{
    static int EquilibriumIndex(int[] arr)
    {
        int totalSum = 0;
        foreach (int num in arr)
            totalSum += num;

        int leftSum = 0;

        for (int i = 0; i < arr.Length; i++)
        {
            totalSum -= arr[i]; 

            if (leftSum == totalSum)
                return i;

            leftSum += arr[i];
        }

        return -1; 
    }
    public static void Main()
    {
        int[] arr1 = {1, 3, 5, 2, 2};
        int[] arr2 = {1, 2, 3};
        int[] arr3 = {2, 4, 2};
        int[] arr4 = {0, -3, 5, -4, -2, 3, 1, 0};

        Console.WriteLine(EquilibriumIndex(arr1)); 
        Console.WriteLine(EquilibriumIndex(arr2)); 
        Console.WriteLine(EquilibriumIndex(arr3)); 
        Console.WriteLine(EquilibriumIndex(arr4)); 
    }
}
