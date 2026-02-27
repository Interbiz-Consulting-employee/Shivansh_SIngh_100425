using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        int n1 = 100;
        int[] arr1 = {1, 2, 4, 5, 10, 20, 50, 100};
        Console.WriteLine(FindMissingDivisor(n1, arr1));  // 25

        int n2 = 36;
        int[] arr2 = {2, 3, 4, 6, 9, 12, 18, 36};
        Console.WriteLine(FindMissingDivisor(n2, arr2));  // 1

        int n3 = 84;
        int[] arr3 = {1, 2, 3, 4, 6, 7, 12, 14, 21, 84};
        Console.WriteLine(FindMissingDivisor(n3, arr3));  // 28
    }

    static int FindMissingDivisor(int n, int[] arr)
    {
        HashSet<int> set = new HashSet<int>(arr);
        for (int i = 1; i * i <= n; i++)
        {
            if (n % i == 0)
            {
                int div1 = i;
                int div2 = n / i;

                if (!set.Contains(div1))
                    return div1;
                if (!set.Contains(div2))
                    return div2;
            }
        }

        return -1; 
    }
}