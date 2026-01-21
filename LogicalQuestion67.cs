using System;

class Program
{
    static void Main()
    {
        int[] arr = {3,0,1};
        Console.WriteLine("Missing student id in {3,0,1} is : " + MissingStudentID(arr));
         int[] arr1 = {0,1};
        Console.WriteLine("Missing student id in {0,1} is : " + MissingStudentID(arr1));
         int[] arr2 = {9,6,4,2,3,5,7,0,1};
        Console.WriteLine("Missing student id in {9,6,4,2,3,5,7,0,1} is : " + MissingStudentID(arr2));
         int[] arr3 = {0};
        Console.WriteLine("Missing student id in {0} is : " + MissingStudentID(arr3));
         int[] arr4 = {1};
        Console.WriteLine("Missing student id in {1} is : " + MissingStudentID(arr4));
    }

    public static int MissingStudentID(int[] arr)
    { 
        int n = arr.Length; 
        int expectedTotalOfStudentID = n * (n + 1) / 2;
        int actualTotalOfStudentID = 0;
        foreach(int num in arr)
            actualTotalOfStudentID += num;
        return expectedTotalOfStudentID - actualTotalOfStudentID;
    }
}
