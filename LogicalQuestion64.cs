using System;
using System.Collections.Generic;

class Program
{
    public static void Main()
    {
        int[] sortedArr1 = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
        int[] sortedArr2 = { 2, 3, 4, 4, 5, 11, 12 };

        List<int> resultArr = UnionArrays(sortedArr1, sortedArr2);

        foreach (int n in resultArr)
            Console.Write(" " + n);

        Console.WriteLine();
        Console.WriteLine("*********");
    }

    public static List<int> UnionArrays(int[] arr1, int[] arr2)
    {
        int i = 0, j = 0;
        List<int> result = new List<int>();

        while (i < arr1.Length && j < arr2.Length)
        {
            if (arr1[i] < arr2[j])
            {
                if (!result.Contains(arr1[i]))
                    result.Add(arr1[i]);
                i++;
            }
            else if (arr1[i] > arr2[j])
            {
                if (!result.Contains(arr2[j]))
                    result.Add(arr2[j]);
                j++;
            }
            else 
            {
                if (!result.Contains(arr1[i]))
                    result.Add(arr1[i]);
                i++;
                j++;
            }
        }

        while (i < arr1.Length)
        {
            if (!result.Contains(arr1[i]))
                result.Add(arr1[i]);
            i++;
        }

        while (j < arr2.Length)
        {
            if (!result.Contains(arr2[j]))
                result.Add(arr2[j]);
            j++;
        }

        return result;
    }
}
